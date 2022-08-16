namespace Models.DTO;

public class ResUserInfoDto
{
    public string Name { get; set; }
    public string Age { get; set; }
    public string Gender { get; set; }
    /// <summary>
    /// 所在省份
    /// </summary>
    public string Province { get; set; }
    /// <summary>
    /// 城市名稱
    /// </summary>
    public string  CityName{ get; set; }
}