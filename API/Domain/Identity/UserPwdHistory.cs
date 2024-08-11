using ExtremeClassified.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// UserPasswordHistory Entity in database
    /// </summary>
    /// 

    [Table("UserPwdHistory")]
    [Keyless]
    public class UserPwdHistory : EntityBase
    {
        [Column("UserId"), MaxLength(50), Required, ForeignKey(nameof(User))]
        public new string KeyField { get; set; }

        [Required, MaxLength(255), Column("Password")]
        public new string NameField { get; set; }

        [Required]
        public DateTime ChangeDate { get; set; }
        public virtual User User { get; set; }
    }
}
