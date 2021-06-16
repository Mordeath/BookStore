using AutoMapper;
using BookStare.Domain.Models;
using BookStore.API.Dtos.Category;
using BookStore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryService _icategoryService;
        private readonly IMapper _mapper;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _icategoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = _icategoryService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CategoryResultDto>>(categories));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByID(int ID)
        {
            var categotyByID = _icategoryService.GetById(ID);

            if (categotyByID == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CategoryResultDto>>(categotyByID);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto addDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var category = _mapper.Map<Category>(addDto);
            var categoryResult = await _icategoryService.Add(category);

            if (categoryResult == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<CategoryResultDto>(categoryResult));
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CategoryEditDto editDto)
        {
            if (id != editDto.ID)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
                return BadRequest();

            await _icategoryService.Update(_mapper.Map<Category>(editDto));
            return Ok(editDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var categoty = await _icategoryService.GetById(id);
            if (categoty == null)
            {
                return NotFound();
            }
            var result = await _icategoryService.Remove(categoty);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [Route("search/{category")]
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Search(string category)
        {
            var categories = _mapper.Map<List<Category>>(await _icategoryService.Search(category));
            if (categories == null || categories.Count == 0)
            {
                return NotFound("None category was found!");
            }
            return Ok(category);
        }
    }
}
