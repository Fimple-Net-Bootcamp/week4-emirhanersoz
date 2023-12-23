using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

[Route("api/v1/socialInteractions")]
[ApiController]
public class SocialInteractionController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<SocialInteractionDto> _validator;
    private readonly ICache _cache;

    public SocialInteractionController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<SocialInteractionDto> validator, ICache cache)
    {
        _unitOfWork = unitOfWork;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    [HttpPost]
    public IActionResult Create([FromBody] SocialInteractionDto newSocialInteraction)
    {
        if (newSocialInteraction == null)
        {
            return BadRequest("Invalid socialInteraction data");
        }

        var result = _validator.Validate(newSocialInteraction);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors
                .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

            return BadRequest(errorMessages);
        }

        var entity = _mapper.Map<SocialInteractionDto, SocialInteraction>(newSocialInteraction);

        try
        {
            _unitOfWork.SocialInteraction.Insert(entity);
            _unitOfWork.Save();

            return Ok("Social Interaction created successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
        }
    }

    [HttpGet("socialInteractions/{petId}")]
    public IActionResult GetById(int id)
    {
        var socialInteraction = _unitOfWork.SocialInteraction.GetById(id);

        if (socialInteraction == null)
        {
            return NotFound($"SocialInteraction with ID {id} not found");
        }

        var SocialInteractionDto = _mapper.Map<SocialInteraction, SocialInteractionDto>(socialInteraction);

        return Ok(SocialInteractionDto);
    }
}