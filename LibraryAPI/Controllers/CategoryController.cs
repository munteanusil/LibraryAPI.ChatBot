using AutoMapper;
using FluentValidation;
using Library.Application.DTOs;
using Library.Application.DTOs.Authors;
using Library.Application.DTOs.Categories;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCategoryDto> _validator;
        private readonly IValidator<PaginatedDto> _paginatedValidator;

        public CategoryController(ICategoryRepository repository,
            IMapper mapper,
             IValidator<CreateCategoryDto> validator,
            IValidator<PaginatedDto> paginatedValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
            _paginatedValidator = paginatedValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(categoryDto, cancellationToken);
            if (validationResult.IsValid)
            {
                await _repository.CreateCategory(_mapper.Map<Category>(categoryDto), cancellationToken);
                return Created();
            }
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CreateCategoryDto CategoryDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(CategoryDto, cancellationToken);
            if (validationResult.IsValid)
            {
                await _repository.CreateCategory(_mapper.Map<Category>(CategoryDto), cancellationToken);
                return Created();
            }

            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id,CancellationToken cancellationToken)
        {
            var category = await _repository.GetCategoryById(id, cancellationToken);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CreateCategoryDto>(category));
        }

        [HttpPut]
        public async Task<IActionResult> Put(CategoryDto categoryDto,CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(categoryDto, cancellationToken);
            if (validationResult.IsValid)
            {
                await _repository.UpdateCategory(_mapper.Map<Category>(categoryDto), cancellationToken);
                return Created();
            }
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _repository.DeleteCategory(id, cancellationToken);
            return Ok();
        }
    }
}
