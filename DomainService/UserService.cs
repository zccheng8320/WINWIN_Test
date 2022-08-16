using Models.DTO;
using Models.Entities;
using Models.Mappers;
using Repository.Abstraction;
using Repository.Abstraction.Specification.Interfaces;

namespace DomainService;

class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository repository,IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateUserAsync(ReqCreateUserDto createUserDto, CancellationToken ct)
    {
        if (await _repository.IsExists(createUserDto.Email, ct))
        {
            // 拋出錯誤讓Exception Filter處理
            throw new Exception("此Email已註冊");
        }
        var user = createUserDto.AdaptToUser();
        // 密碼雜湊驗算法
        var tuple = PasswordUtilities.Pbkdf2(createUserDto.Password);
        user.Password = tuple.Hash;
        user.PasswordSalt = tuple.Salt;
        _repository.Insert(user);
        await _unitOfWork.SaveChangeAsync(ct);
    }

    public  async Task<IEnumerable<ResUserInfoDto>> GetUserInfoAsync(ReqGetUserInfoDto dto, CancellationToken ct)
    {

        var users =await _repository.GetUserInfoAsync(dto, ct);
        return users.Select(x => new ResUserInfoDto()
        {
            Age = x.Age.ToString(),
            Name = x.Name,
            CityName = x.Area.CityName,
            Gender = x.Gender.ToString(),
            Province = x.Area.Province,
        });
    }

    public Task<IEnumerable<ResCityUserCountDto>> GetCityUserCount(CancellationToken ct)
    {
        return _repository.GetCityUserCount(ct);
       
    }
}