using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebShopServiceWebsline.DTO;
using WebShopServiceWebsline.Interfaces;
using WebShopServiceWebsline.Models;

namespace WebShopServiceWebsline.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountCodesController : Controller
{
    private readonly IDiscountCodeRepository _discountRepository;
    private readonly IMapper _mapper;

    public DiscountCodesController(IDiscountCodeRepository discountRepository, IMapper mapper)
    {
        _discountRepository = discountRepository;
        _mapper = mapper;
    }

    [HttpGet("Id/{discountId}")]
    [ProducesResponseType(200, Type = typeof(DiscountCode))]
    [ProducesResponseType(400)]
    public IActionResult GetDiscountById(int discountId)
    {
        if (_discountRepository.DiscountCodeExists(discountId) == false)
            return NotFound();

        var discount = _mapper.Map<DiscountCodeDTO>(_discountRepository.GetDiscountCodeById(discountId));

        if (ModelState.IsValid == false)
            return BadRequest(ModelState);

        return Ok(discount);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateDiscountCode([FromBody] DiscountCodeDTO discountCreate)
    {
        if (discountCreate == null)
            return BadRequest(ModelState);

        var users = _discountRepository.GetDiscountCodes()
            .Where(d => d.Code.Trim().ToUpper() == discountCreate.Code.TrimEnd().ToUpper())
            .FirstOrDefault();

        if (users != null)
        {
            ModelState.AddModelError("", "Discount already exists");
            return StatusCode(422, ModelState);
        }

        if (ModelState.IsValid == false)
            return BadRequest(ModelState);

        var discountMap = _mapper.Map<DiscountCode>(discountCreate);

        if (_discountRepository.CreateDiscountCode(discountMap) == false)
        {
            ModelState.AddModelError("", "Something went wrong while saving the discount");
            return StatusCode(500, ModelState);
        }

        return Ok("Discount Successfully created");
    }
}
