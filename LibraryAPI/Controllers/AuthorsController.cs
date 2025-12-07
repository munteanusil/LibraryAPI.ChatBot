using AutoMapper;
using Library.Application.DTOs.Authors;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
       

        private readonly ILogger<AuthorsController> _logger;
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository repository,IMapper mapper)
        {
           _repository = repository;
            _mapper = mapper;
        }
 
        [HttpPost] 
        public async Task<IActionResult> Post(CreateAuthorDto authorDto,CancellationToken cancellationToken)
        {
            await _repository.CreateAuthor(_mapper.Map<Author>(authorDto), cancellationToken);
            return Created();
        }
    }
}
