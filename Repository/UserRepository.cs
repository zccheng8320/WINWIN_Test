using Dapper;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Entities;
using Plantsist.AppProGateway.Repository.Repositories.DbContext;
using Repository.Abstraction;

namespace Repository;

internal class UserRepository : MasterGenericRepository<User>,IUserRepository
{
    private readonly DbEntities _dbContext;

    public UserRepository(DbEntities dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsExists(string email, CancellationToken ct)
    {
        return (await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email, ct)) != null;
    }

    public async Task<IEnumerable<User>> GetUserInfoAsync(ReqGetUserInfoDto dto, CancellationToken ctx)
    {

        var skip = (dto.Page-1) * dto.ResultCount;
        var take = dto.ResultCount;
        var queryable = _dbContext.Users.Include(x => x.Area);
        if (dto.Name != null)
            queryable.Where(x => x.Name.Contains(dto.Name));
        if (dto.Gender != null)
            queryable.Where(x => x.Gender == dto.Gender);
        if (dto.AgeMin != null)
            queryable.Where(x => x.Age >= dto.AgeMin);
        if (dto.AgeMax != null)
            queryable.Where(x => x.Age <= dto.AgeMax);

        return await queryable.Skip(skip).Take(take).ToListAsync(ctx);
    }

    public async Task<IEnumerable<ResCityUserCountDto>> GetCityUserCount(CancellationToken ct)
    {
        const string sql =
            "SELECT Count(*) as [Count] ,Gender,CityName FROM Users as u Inner join Areas as a on u.AreaId = a.Id GROUP BY a.CityName,Gender";
        
        return  await _dbContext.Database.GetDbConnection().QueryAsync<ResCityUserCountDto>(sql);

    }
}