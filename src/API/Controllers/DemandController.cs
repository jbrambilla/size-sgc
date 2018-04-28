using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class DemandController : Controller
    {
        private readonly IRepository<Demand> _demandRepository;
        private readonly IRepository<Category> _categoryRepository;

        public DemandController(IRepository<Demand> demandRepository, IRepository<Category> categoryRepository)
        {
            _demandRepository = demandRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("api/demand/all")]
        public async Task<IActionResult> GetAll()
        {
            var demands = Mapper.Map<IEnumerable<DemandViewModel>>(await _demandRepository.GetAll().Include(d => d.Category).ToAsyncEnumerable().ToList());
            return new OkObjectResult(demands);
        }

        [HttpGet]
        [Route("api/demand/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var demand = await _demandRepository.GetAll().Include(d => d.Category).FirstOrDefaultAsync(d => d.Id == id);

            if (demand == null)
                return NotFound($"demand in id {id} not found");

            return new OkObjectResult(Mapper.Map<DemandViewModel>(demand));
        }

        [HttpPost]
        [Route("api/demand")]
        public async Task<IActionResult> Post([FromBody]DemandViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = model.Category.Id > 0 ? _categoryRepository.GetById(model.Category.Id) : null;

            var demand = Mapper.Map<Demand>(model);

            demand.Category = category == null ? demand.Category : await category;

            await _demandRepository.Create(demand);

            return new OkObjectResult(demand);
        }

        [HttpPut]
        [Route("api/demand/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]DemandViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = model.Category.Id > 0 ? _categoryRepository.GetById(model.Category.Id) : null;

            var demand = await _demandRepository.GetById(id);

            demand = Mapper.Map(model, demand, typeof(DemandViewModel), typeof(Demand)) as Demand;

            demand.Category = category == null ? demand.Category : await category;

            await _demandRepository.Update(demand);

            return new OkObjectResult(demand);
        }

        [HttpDelete]
        [Route("api/demand/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _demandRepository.Delete(id);

            return new OkObjectResult(id);
        }
    }
}