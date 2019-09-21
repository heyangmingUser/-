using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContoSoEFAndMVC.Models;
using ContoSoEFAndMVC.Data;
using ContoSoEFAndMVC.Models.SchoolViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ContoSoEFAndMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly SchoolContext _context;

        public HomeController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> About()
        {
            //IQueryable<EnrollmentDateGroup> data =
            //    from student in _context.Students
            //    group student by student.EnrollmentDate into dateGroup
            //    select new EnrollmentDateGroup()
            //    {
            //        EnrollmentDate = dateGroup.Key,
            //        StudentCount = dateGroup.Count()
            //    };
            //return View(await data.AsNoTracking().ToListAsync());
            List<EnrollmentDateGroup> groups = new List<EnrollmentDateGroup>();
            //获取连接
            var conn = _context.Database.GetDbConnection();
            //打开连接
            await conn.OpenAsync();

            try
            {
                using (var command=conn.CreateCommand())
                {
                    string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
                                    + "FROM Person "
                                    + "WHERE Discriminator = 'Student' "
                                    + "GROUP BY EnrollmentDate";
                    //获取对数据源要运行的数据或者文本
                    command.CommandText = query;
                    //执行读数据的命令
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    //开始读数据
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new EnrollmentDateGroup { EnrollmentDate = reader.GetDateTime(0), StudentCount = reader.GetInt32(1) };
                            groups.Add(row);
                        }
                    }
                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }
            return View(groups);
        }
    }
}
