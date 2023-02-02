using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Microsoft.AspNetCore.Components.Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
    [HttpGet("GetAuthorandBooks")]
    public async Task<Response<List<BookDto>>> Get()
    {
        return await _userService.GetAuthorandBooks();
    }
    [HttpGet("GetPublishersBook")]
    public async Task<Response<List<PublisherDto>>> GetPublishersBook()
    {
        return await _userService.GetPublishersBook();
    }
    [HttpGet("GetAuthorbooks")]
    public async Task<Response<List<AuthorDto>>> GetAuthorbooks()
    {
        return await _userService.GetAuthorbooks();
    }
    [HttpGet("GetBookandReviews")]
    public async Task<Response<List<BookReviewDto>>> GetBookandReviews()
    {
        return await _userService.GetBookandReviews();
    }
    [HttpGet("GetBookandReviewsV2")]
    public async Task<Response<List<AuthorDtoV2>>> GetBookandReviewsV2()
    {
        return await _userService.GetBookOfAuthot();
    }
    
    
}