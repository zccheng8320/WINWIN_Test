using DomainService;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using TestApplication.ResponseModels;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task CreateUser(ReqCreateUserDto dto, CancellationToken ct)
        {
            await _userService.CreateUserAsync(dto, ct);
        }
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<ResUserInfoDto>>> GetUserInfoAsync([FromQuery]ReqGetUserInfoDto dto, CancellationToken ct)
        {
            var result = await _userService.GetUserInfoAsync(dto, ct);
            return ApiResponse.Ok(result);
        }
        [HttpGet("count")]
        public async Task<ApiResponse<IEnumerable<ResCityUserCountDto>>> GetCityUserCountAsync(CancellationToken ct)
        {
            var result = await _userService.GetCityUserCount(ct);
            return ApiResponse.Ok(result);
        }
    }
}