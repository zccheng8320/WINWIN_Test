using Models.DTO;
using Models.Entities;

namespace Repository.Abstraction;

public interface IUserRepository : IRepository<User>
{
    Task<bool> IsExists(string email, CancellationToken ct);
    Task<IEnumerable<User>> GetUserInfoAsync(ReqGetUserInfoDto dto, CancellationToken ctx);
    Task<IEnumerable<ResCityUserCountDto>> GetCityUserCount(CancellationToken ct);
}