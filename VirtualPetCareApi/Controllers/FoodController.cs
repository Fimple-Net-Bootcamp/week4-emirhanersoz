using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using VirtualPetCareApi.Dtos;

namespace VirtualPetCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<FoodDto> _validator;
        private readonly ICache _cache;
        public FoodController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<FoodDto> validator, ICache cache)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetAllFoods()
        {
            var foods = _unitOfWork.Food.GetAll();

            var foodDtos = foods.Select(pet => _mapper.Map<FoodDto>(foods)).ToList();

            return Ok(foodDtos);
        }

        [HttpPost]
        public IActionResult Create([FromBody] FoodDto newFood)
        {
            var result = _validator.Validate(newFood);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors
                    .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

                return BadRequest(errorMessages);
            }

            if (newFood == null)
            {
                return BadRequest("Invalid activity data");
            }

            var entity = _mapper.Map<FoodDto, Food>(newFood);

            try
            {
                _unitOfWork.Food.Insert(entity);
                _unitOfWork.Save();

                return Ok("Activity created successfully");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
            }
        }
    }
}
