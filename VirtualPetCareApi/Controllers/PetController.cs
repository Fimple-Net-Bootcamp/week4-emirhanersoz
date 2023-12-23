using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;
using VirtualPetCareApi.Dtos;
using AutoMapper;
using FluentValidation;

namespace VirtualPetCareApi.Controllers
{
    [Route("api/v1/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<PetDto> _validator;
        private readonly ICache _cache;

        public PetController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<PetDto> validator, ICache cache)
        {
            _cache = cache;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("statistics/{petId}")]
        public IActionResult GetPetStatistics(int petId)
        {
            var petStatistics = _unitOfWork.Pet.GetById(petId);

            if(petStatistics == null)
            {
                return NotFound("Pet not found");
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var petStatisticsJson = JsonSerializer.Serialize(petStatistics, options);

            return Ok(petStatisticsJson);
        }

        [HttpGet]
        public IActionResult GetAllPets()
        {
            var pets = _unitOfWork.Pet.GetAll();

            var petDtos = pets.Select(pet => _mapper.Map<PetDto>(pet)).ToList();

            return Ok(petDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pet = _unitOfWork.Pet.GetById(id);

            if (pet == null)
            {
                return NotFound($"User with ID {id} not found");
            }

            var petDto = _mapper.Map<Pet, PetDto>(pet);

            return Ok(petDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PetDto newPet)
        {
            var result = _validator.Validate(newPet);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors
                    .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

                return BadRequest(errorMessages);
            }

            if (newPet == null)
            {
                return BadRequest("Invalid pet data");
            }

            var entity = _mapper.Map<PetDto, Pet>(newPet);

            try
            {
                _unitOfWork.Pet.Insert(entity);
                _unitOfWork.Save();

                return Ok("Pet created successfully");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PetDto updatedPet)
        {
            var pet = _unitOfWork.Pet.GetById(id);

            if (pet == null)
            {
                return NotFound($"Pet with ID {id} not found");
            }

            pet.UserId = updatedPet.UserId;
            pet.Name = updatedPet.Name;
            pet.Species = updatedPet.Species;
            pet.Age = updatedPet.Age;

            try
            {
                _unitOfWork.Pet.Update(pet);
                _unitOfWork.Save();

                return Ok("Pet updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
