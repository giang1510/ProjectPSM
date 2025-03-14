using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Handle product related requests
/// </summary>
[Authorize]
public class ProductsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductsController(IUnitOfWork unitOfWork, IMapper _mapper)
    {
        _unitOfWork = unitOfWork;
        this._mapper = _mapper;
    }

    /// <summary>
    /// Handle getting multiple products
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductCardDto>>> GetProducts()
    {
        var products = await _unitOfWork.ProductRepository.GetProductsAsync();
        return Ok(products);
    }

    /// <summary>
    /// Handle getting a product page
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailDto>> GetProductById(int id)
    {
        var productDetail = await _unitOfWork.ProductRepository.GetProductDetailAsync(id);
        return Ok(productDetail);
    }

    /// <summary>
    /// Handle adding new review to a product
    /// </summary>
    /// <param name="reviewEntryDto"></param>
    /// <returns></returns>
    // TODO Send back better responses in error cases
    [HttpPost("review")] // api/products/review
    public async Task<ActionResult<ReviewDto>> AddReview(ReviewEntryDto reviewEntryDto)
    {
        var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(
            reviewEntryDto.ProductId
        );
        if (product == null)
            return NotFound("Product not found!");

        var username = User.GetUsername();
        if (username == null)
            return NotFound("User not found!");

        var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
        if (user == null)
            return NotFound();

        if (product.Reviews.Any(x => x.UserId == user.Id))
        {
            return BadRequest("A review for the product already exists");
        }

        // TODO use better data retrieving, i.e. reviewRepository
        var review = new Review
        {
            Headline = reviewEntryDto.Headline,
            Rating = reviewEntryDto.Rating,
            WrittenReview = reviewEntryDto.WrittenReview,
            User = user,
            Product = product
        };
        product.Reviews.Add(review);

        if (!await _unitOfWork.Complete())
            return BadRequest("Failed to add new review");

        return _mapper.Map<ReviewDto>(review);
    }
}
