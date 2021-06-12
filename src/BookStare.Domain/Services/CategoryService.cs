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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookService _bookService;

        public CategoryService(ICategoryRepository categoryRepository, IBookService bookService)
        {
            _categoryRepository = categoryRepository;
            _bookService = bookService;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> Add(Category category)
        {
            if (_categoryRepository.Search(q => q.Name == category.Name).Result.Any())
                return null;

            await _categoryRepository.Add(category);
            return category;
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }

        public async Task<Category> GetById(int ID)
        {
            return await _categoryRepository.GetByID(ID);
        }

        public async Task<bool> Remove(Category category)
        {
            var books = await _bookService.GetBooksByCategory(category.ID);
            if (books.Any())
            {
                return false;
            }
            await _categoryRepository.Remove(category);
            return true;
        }

        public async Task<IEnumerable<Category>> Search(string searchValue)
        {
            return await _categoryRepository.Search(q => q.Name.Contains(searchValue));
        }

        public async Task<Category> Update(Category category)
        {
            if (_categoryRepository.Search(q => q.Name == category.Name && q.ID != category.ID).Result.Any())
                return null;

            await _categoryRepository.Update(category);
            return category;
        }
    }
}
