﻿using ControleFinanceiro.Api.ApiModels;
using ControleFinanceiro.Domain.Dtos.Category;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<ApiResponse<IEnumerable<CategoryResponseDto>>> GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(new ApiResponse<IEnumerable<CategoryResponseDto>>(categories));
        }

        [HttpGet("{id:int}")]
        public ActionResult<ApiResponse<CategoryResponseDto>> GetById([FromRoute] int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(new ApiResponse<CategoryResponseDto>(category));
        }

        [HttpPost]
        public ActionResult<ApiResponse<CategoryResponseDto>> Add([FromBody] CategoryRequestDto dto)
        {
            int id = _categoryService.Add(dto);
            return Created($"categories/{id}", new ApiResponse<CategoryRequestDto>(dto));
        }

        [HttpPut("{id:int}")]
        public ActionResult Update([FromRoute] int id, [FromBody] CategoryRequestDto dto)
        {
            _categoryService.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }
    }
}
