using Models.DTO;
using Models.Entities;
using Models.Enums;

namespace Models.Mappers;

public static class ReqCreateUserDtoExtensions
{
    public static User AdaptToUser(this ReqCreateUserDto req)
    {
        return new User()
        {
            Name = req.Name,
            Age = req.Age,
            Email = req.Email,
            Gender = req.Gender,
            AreaId = req.AreaId
            
        };
    }
}