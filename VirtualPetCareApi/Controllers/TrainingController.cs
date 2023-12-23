using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

[Route("api/v1/trainings")]
[ApiController]
public class TrainingController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<TrainingDto> _validator;
    private readonly ICache _cache;

    public TrainingController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<TrainingDto> validator, ICache cache)
    {
        _unitOfWork = unitOfWork;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpPost]
    public IActionResult Create([FromBody] TrainingDto newTraining)
    {
        if (newTraining == null)
        {
            return BadRequest("Invalid training data");
        }

        var result = _validator.Validate(newTraining);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors
                .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

            return BadRequest(errorMessages);
        }

        var entity = _mapper.Map<TrainingDto, Training>(newTraining);

        try
        {
            _unitOfWork.Training.Insert(entity);
            _unitOfWork.Save();

            return Ok("Training created successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
        }
    }

    [HttpGet("training/{petId}")]
    public IActionResult GetById(int id)
    {
        var training = _unitOfWork.Training.GetById(id);

        if (training == null)
        {
            return NotFound($"Training with ID {id} not found");
        }

        var trainingDto = _mapper.Map<Training, TrainingDto>(training);

        return Ok(trainingDto);
    }
}