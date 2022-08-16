using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Models.Enums;

namespace Models.DTO;

public class ReqCreateUserDto
{
    /// <summary>
    /// email
    /// </summary>
    /// <example>admin@example.com</example>
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    /// <summary>
    /// 密碼
    /// </summary>
    /// <example>qwer123456</example>
    [MinLength(6)]
    public string Password { get; set; }
    /// <summary>
    /// 名稱
    /// </summary>
    /// <example>阿三</example>
    [Required]
    public string Name { get; set; }
    /// <summary>
    /// 性別
    /// </summary>
    /// <example>Man</example>
    [Required]
    public Gender Gender { get; set; }
    /// <summary>
    /// 年紀
    /// </summary>
    /// <example>27</example>
    [Required]
    public int Age { get; set; }
    /// <summary>
    /// 區域編號
    /// </summary>
    /// <example>1</example>
    public int AreaId { get; set; }

}