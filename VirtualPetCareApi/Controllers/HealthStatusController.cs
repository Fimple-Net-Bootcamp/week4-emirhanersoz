using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;
using AutoMapper;
using FluentValidation;
using VirtualPetCareApi.Dtos;

namespace VirtualPetCareApi.Controllers
{
    [Route("api/v1/healthstatuses")]
    [ApiController]
    public class HealthStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<HealthStatusDto> _validator;
        private readonly ICache _cache;

        public HealthStatusController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<HealthStatusDto> validator, ICache cache)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("{petId}")]
        public IActionResult GetHealthStatus(int petId)
        {
            var healthStatus = _unitOfWork.HealthStatus.GetByPetId(petId);

            if (healthStatus == null)
            {
                return NotFound($"Pet with ID {petId} not found");
            }

            var healthStatusDto = _mapper.Map<HealthStatus, HealthStatusDto>(healthStatus);

            return Ok(healthStatusDto);
        }


        [HttpPatch("{petId}")]
        public IActionResult UpdateHealthStatus(int petId, [FromBody] HealthStatusDto updatedHealthStatusDto)
        {
            var healthStatus = _unitOfWork.HealthStatus.GetByPetId(petId);

            if (healthStatus == null)
            {
                return NotFound($"Pet with ID {petId} not found");
            }

            if (updatedHealthStatusDto.PetId != petId)
            {
                return BadRequest("Can't update the 'Id' field.");
            }

            _mapper.Map(updatedHealthStatusDto, healthStatus);
            _unitOfWork.HealthStatus.Update(healthStatus);
            _unitOfWork.Save();

            return Ok(_mapper.Map<HealthStatus, HealthStatusDto>(healthStatus));
        }
    }
}
