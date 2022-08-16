using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class Area
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    /// <summary>
    /// 省份
    /// </summary>
    [Required]
    public string Province { get; set; }
    /// <summary>
    /// 城市名稱
    /// </summary>
    public string CityName { get; set; }

    public virtual ICollection<User> Users { get; set; }
}