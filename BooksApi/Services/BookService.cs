using BooksApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _book;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _book = database.GetCollection<Book>(settings.BooksCollectionName);
        }
        //获取所有
        public List<Book> Get() => _book.Find(r => true).ToList();
        //获取指定
        public Book Get(string id) => _book.Find<Book>(r => r.Id == id).FirstOrDefault();
        //添加新的
        public Book Create(Book book)
        {
            _book.InsertOne(book);
            return book;
        }
        //更新
        public void Update(string id, Book bookIn) => _book.ReplaceOne(book => book.Id == id, bookIn);
        //删除
        public void Remove(Book bookIn) =>_book.DeleteOne(book => book.Id == bookIn.Id);
        //删除
        public void Remove(string id) =>_book.DeleteOne(book => book.Id == id);
    }
}
