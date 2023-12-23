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
    [Route("api/v1/activities")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ActivityDto> _validator;
        private readonly ICache _cache;
        public ActivityController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<ActivityDto> validator, ICache cache)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActivityDto newActivity)
        {
            var result = _validator.Validate(newActivity);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors
                    .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

                return BadRequest(errorMessages);
            }

            if (newActivity == null)
            {
                return BadRequest("Invalid activity data");
            }

            var entity = _mapper.Map<ActivityDto, Activity>(newActivity);

            try
            {
                _unitOfWork.Activity.Insert(entity);
                _unitOfWork.Save();

                return Ok("Activity created successfully");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
            }
        }

        [HttpGet("{petId}")]
        public IActionResult GetById(int id)
        {
            var activity = _unitOfWork.Activity.GetById(id);

            if (activity == null)
            {
                return NotFound($"Pet with ID {id} not found");
            }

            var activityDto = _mapper.Map<Activity, ActivityDto>(activity);

            return Ok(activityDto);
        }
    }
}
