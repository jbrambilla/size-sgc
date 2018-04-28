using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("api/category")]
        public async Task<IActionResult> Get()
        {
            var categories = Mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAll().ToAsyncEnumerable().ToList());
            return new OkObjectResult(categories);
        }

        [HttpGet]
        [Route("api/category/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);

            if (category == null)
                return NotFound($"category in id {id} not found");

            return new OkObjectResult(Mapper.Map<CategoryViewModel>(category));
        }

        [HttpPost]
        [Route("api/category")]
        public async Task<IActionResult> Post([FromBody]CategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = Mapper.Map<Category>(model);

            await _categoryRepository.Create(category);

            return new OkObjectResult(category);
        }
    }
}