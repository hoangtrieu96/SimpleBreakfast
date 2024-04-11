using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBreakfast.DTO;
using SimpleBreakfast.Models.Entities;
using SimpleBreakfast.Services.BreakfastService;

namespace SimpleBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastsController : ControllerBase
{

    private IBreakfastRepository _breakfastRepository;
    private IMapper _mapper;

    public BreakfastsController(IBreakfastRepository breakfastRepository, IMapper mapper)
    {
        _breakfastRepository = breakfastRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetBreakfasts()
    {
        List<BreakfastDTO> breakfastDTOs = _mapper.Map<List<BreakfastDTO>>(_breakfastRepository.GetBreakfasts());
        return Ok(breakfastDTOs);
    }

    /// <summary>
    /// Return a specific breakfast that match the given ID.
    /// </summary>
    /// <remarks>
    /// Here is a sample remarks placeholder.
    /// </remarks>
    /// <param name="id">The breakfast ID to search for.</param>
    /// <returns>A JSON object.</returns>
    /// <response code="200">Returns the breakfast.</response>
    /// <response code="400">If the ID doesn't exist.</response>
    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(BreakfastDTO), StatusCodes.Status200OK)]
    public IActionResult GetBreakfast(Guid id)
    {
        BreakfastDTO breakfastDTO = _mapper.Map<BreakfastDTO>(_breakfastRepository.GetBreakfast(id));
        if (breakfastDTO is null)
            return BadRequest(nameof(Breakfast) + " not found");
        return Ok(breakfastDTO);
    }

    [HttpPost]
    public IActionResult CreateBreakfast(BreakfastDTO breakfastDTO)
    {
        var id = Guid.NewGuid();
        Breakfast breakfast = new Breakfast(
            id,
            breakfastDTO.Name,
            breakfastDTO.Description,
            breakfastDTO.StartDateTime,
            breakfastDTO.EndDateTime,
            DateTime.UtcNow,
            breakfastDTO.Savory,
            breakfastDTO.Sweet
        );

        try
        {
            _breakfastRepository.CreateBreakfast(breakfast);
            _breakfastRepository.SaveChanges();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Problem();
        }

        return Ok(_mapper.Map<BreakfastDTO>(breakfast));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateBreakfast(Guid id, BreakfastDTO breakfastDTO)
    {
        var breakfast = _breakfastRepository.GetBreakfast(id);
        if (breakfast is null)
            return BadRequest(nameof(Breakfast) + " not found");

        try
        {
            breakfast.Name = breakfastDTO.Name;
            breakfast.Description = breakfastDTO.Description;
            breakfast.StartDateTime = breakfastDTO.StartDateTime;
            breakfast.EndDateTime = breakfastDTO.EndDateTime;
            breakfast.LastModifiedDateTime = DateTime.UtcNow;
            breakfast.Savory = breakfastDTO.Savory;
            breakfast.Sweet = breakfastDTO.Sweet;

            _breakfastRepository.UpdateBreakfast(breakfast);
            _breakfastRepository.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Problem();
        }

        return Ok(_mapper.Map<BreakfastDTO>(breakfast));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        var breakfast = _breakfastRepository.GetBreakfast(id);
        if (breakfast is null)
            return BadRequest(nameof(Breakfast) + " not found");

        try
        {
            _breakfastRepository.RemoveBreakfast(breakfast);
            _breakfastRepository.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Problem();
        }

        return NoContent();
    }
}