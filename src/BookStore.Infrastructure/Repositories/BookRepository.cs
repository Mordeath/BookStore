using BookStare.Domain.Interfaces;
using BookStare.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(Context.BookStoreDbContext db) : base(db) { }

        public override async Task<List<Book>> GetAll()
        {
            return await Db.Books.AsNoTracking().Include(q => q.Categoty)
                  .OrderBy(b => b.Name).ToListAsync();
        }

        public override async Task<Book> GetByID(int ID)
        {
            return await Db.Books.AsNoTracking().Where(q => q.ID == ID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
        {
            return await Search(q => q.CategoryID == categoryId);
        }

        public async Task<IEnumerable<Book>> SearchBookwithCategory(string searchValue)
        {
            return await Db.Books.AsNoTracking().Include(b => b.Categoty)
                .Where(q => q.Name.Contains(searchValue) ||
                            q.Authot.Contains(searchValue) ||
                            q.Description.Contains(searchValue) ||
                            q.Categoty.Name.Contains(searchValue)).ToListAsync();
        }
    }
}
