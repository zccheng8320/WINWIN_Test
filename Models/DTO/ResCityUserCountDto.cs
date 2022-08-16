using Models.Enums;

namespace Models.DTO;

public class ResCityUserCountDto
{
    public string CityName { get; set; }
    public Gender Gender { get; set; }
    public int Count { get; set; }
}