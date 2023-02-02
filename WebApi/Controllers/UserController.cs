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
    [HttpGet("GetAddresses")]
    public async Task<Response<List<BookDto>>> Get()
    {
        return await _userService.GetAuthorandBooks();
    }
}