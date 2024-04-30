﻿using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Authorize]
public class ProductsController : BaseApiController
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ProductsController(IProductRepository productRepository, IUserRepository _userRepository,
        IMapper _mapper)
    {
        _productRepository = productRepository;
        this._userRepository = _userRepository;
        this._mapper = _mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductCardDto>>> GetProducts()
    {
        var products = await _productRepository.GetProductsAsync();
        return Ok(products);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailDto>> GetProductById(int id)
    {
        var productDetail = await _productRepository.GetProductDetailAsync(id);
        return Ok(productDetail);
    }

    // TODO Send back better responses in error cases
    [HttpPost("review")] // api/products/review
    public async Task<ActionResult<ReviewDto>> AddReview(ReviewEntryDto reviewEntryDto)
    {
        var product = await _productRepository.GetProductByIdAsync(reviewEntryDto.ProductId);
        if (product == null) return NotFound("Product not found!");

        var username = User.GetUsername();
        if (username == null) return NotFound("User not found!");

        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user == null) return NotFound();

        if (product.Reviews.Any(x => x.UserId == user.Id || x.ProductId == product.Id))
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

        if (!await _productRepository.SaveAllAsync()) return BadRequest("Failed to add new review");

        return _mapper.Map<ReviewDto>(review);
    }

}