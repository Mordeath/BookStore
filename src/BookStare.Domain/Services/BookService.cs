using BookStare.Domain.Interfaces;
using BookStare.Domain.Models;
using BookStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookReposiroty;

        public BookService(IBookRepository bookRepository)
        {
            _bookReposiroty = bookRepository;
        }

        public async Task<Book> Add(Book book)
        {
            if (_bookReposiroty.Search(q=>q.Name == book.Name).Result.Any())
            {
                return null;
            }
            await _bookReposiroty.Add(book);
            return book;
        }

        public void Dispose()
        {
            _bookReposiroty?.Dispose();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookReposiroty.GetAll();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryID)
        {
            return await _bookReposiroty.GetBooksByCategory(categoryID);
        }

        public async Task<Book> GetByID(int ID)
        {
            return await _bookReposiroty.GetByID(ID);
        }

        public async Task<bool> Remove(Book book)
        {
            await _bookReposiroty.Remove(book);
            return true;
        }

        public async Task<IEnumerable<Book>> Search(string bookName)
        {
            return await _bookReposiroty.Search(q => q.Name.Contains(bookName));
        }

        public async Task<IEnumerable<Book>> SearchBookWithCategory(string searchValue)
        {
            return await _bookReposiroty.SearchBookwithCategory(searchValue);
        }

        public async Task<Book> Update(Book book)
        {
            if (_bookReposiroty.Search(q=>q.Name == book.Name && q.ID != book.ID).Result.Any())
            {
                return null;
            }
            await _bookReposiroty.Update(book);
            return book;
        }
    }
}
