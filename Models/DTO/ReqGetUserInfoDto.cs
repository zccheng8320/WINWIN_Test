using Models.Enums;

namespace Models.DTO;

public class ReqGetUserInfoDto
{
    /// <summary>
    /// 模糊查詢
    /// </summary>
    public string? Name { get; set; }
    public int? AgeMin { get; set; }
    public int? AgeMax { get; set; }
    public Gender? Gender { get; set; }
    public int Page { get; set; } = 1;
    public int ResultCount { get; set; } = 10;
}