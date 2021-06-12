using BookStare.Domain.Models;

namespace BookStore.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(Context.BookStoreDbContext db) : base(db)
        {

        }
    }
}
