using Models.DTO;

namespace DomainService;

public interface IUserService
{
    Task CreateUserAsync(ReqCreateUserDto createUserDto, CancellationToken ct);
    Task<IEnumerable<ResUserInfoDto>> GetUserInfoAsync(ReqGetUserInfoDto dto,CancellationToken ct);
    Task<IEnumerable<ResCityUserCountDto>> GetCityUserCount(CancellationToken ct);
}