using BookStare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStare.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
