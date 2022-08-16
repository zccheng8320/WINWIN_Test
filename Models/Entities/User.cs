using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Models.Enums;

namespace Models.Entities;

[Index(nameof(Email), IsUnique = true)]
public class User : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    /// <summary>
    /// 年齡
    /// </summary>
    public int Age{ get; set; }
    /// <summary>
    /// 密碼鹽
    /// </summary>
    public byte[] PasswordSalt { get; set; }
    /// <summary>
    /// 密碼
    /// </summary>
    public byte[] Password { get; set; }
    public int AreaId { get; set; }
    /// <summary>
    /// 性別
    /// </summary>
    public  Gender Gender { get; set; }
    public virtual  Area Area { get; set;}
}