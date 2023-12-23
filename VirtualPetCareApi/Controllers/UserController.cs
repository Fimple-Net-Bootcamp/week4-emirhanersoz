using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;
using VirtualPetCareApi.Dtos;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;
using FluentValidation;

namespace VirtualPetCareApi.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UserDto> _validator;
        private readonly ICache _cache;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserDto> validator, ICache cache)
        {
            _cache = cache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;      
        }

        [HttpGet("statistics/{userId}")]
        public IActionResult GetUserStatistics(int userId)
        {
            var userStatistics = _unitOfWork.User.GetById(userId);

            if (userStatistics == null)
            {
                return NotFound("Pet not found");
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var userStatisticsJson = JsonSerializer.Serialize(userStatistics, options);

            return Ok(userStatisticsJson);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _unitOfWork.User.GetAll();

            var userDtos = users.Select(user => _mapper.Map<UserDto>(user)).ToList();

            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _unitOfWork.User.GetById(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found");
            }

            var userDto = _mapper.Map<User, UserDto>(user);

            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDto newUser)
        {
            var result = _validator.Validate(newUser);

            if(!result.IsValid) 
            {
                var errorMessages = result.Errors
                    .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

                return BadRequest(errorMessages);
            }

            if (newUser == null)
            {
                return BadRequest("Invalid user data");
            }

            var entity = _mapper.Map<UserDto, User>(newUser);

            try
            {
                _unitOfWork.User.Insert(entity);
                _unitOfWork.Save();

                return Ok("User created successfully");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
