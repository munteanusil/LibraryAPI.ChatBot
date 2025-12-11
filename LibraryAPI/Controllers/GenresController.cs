using AutoMapper;
using FluentValidation;
using Library.Application.DTOs;
using Library.Application.DTOs.Authors;
using Library.Application.DTOs.Genres;
using Library.Application.Interfaces;
using Library.Domain.Common;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : Controller
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateGenreDto> _validator;
        private readonly IValidator<PaginatedDto> _paginatedValidator;

        public GenresController(IGenreRepository repository,
            IMapper mapper,
            IValidator<CreateGenreDto> validator,
            IValidator<PaginatedDto> paginatedValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
            _paginatedValidator = paginatedValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateGenreDto genreDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(genreDto, cancellationToken);
            if (validationResult.IsValid)
            {
                //var authorToCreate = _mapper.Map<Author>(authorDto);
                //authorToCreate.Books = _mapper.Map<List<Book>>(authorDto.Books);
                await _repository.CreateGenre(_mapper.Map<Genre>(genreDto), cancellationToken);
                return Created();
            }

            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginatedDto dto, CancellationToken cancellationToken)
        {
            var validationResult = await _paginatedValidator.ValidateAsync(dto, cancellationToken);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            var genres = await _repository.GetGenres(dto.Page, dto.PageSize);
            var genressDto = _mapper.Map<List<GenreDto>>(genres.Items);
            var result = new PaginetedList<GenreDto>(genressDto, dto.Page, dto.PageSize);
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var genre = await _repository.GetGenreById(id, cancellationToken);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GenreDto>(genre));
        }

        [HttpPut]
        public async Task<IActionResult> Put(GenreDto genreDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(genreDto, cancellationToken);
            if (validationResult.IsValid)
            {
                await _repository.UpdateGenre(_mapper.Map<Genre>(genreDto), cancellationToken);
                return Created();
            }
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _repository.DeleteGenre(id, cancellationToken);
            return Ok();
        }
    }
}
