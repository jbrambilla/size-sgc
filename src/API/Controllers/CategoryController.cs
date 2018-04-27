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