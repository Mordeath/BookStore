using BookStare.Domain.Interfaces;
using BookStare.Domain.Models;

namespace BookStore.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context.BookStoreDbContext db) : base(db)
        {

        }
    }
}
