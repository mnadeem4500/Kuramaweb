using ExtremeClassified.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// GroupUser Entity in database
    /// </summary>
    /// 

    [Table("UserGroups")]
    [Keyless]
    public class UserGroup : EntityBase
    {

        [MaxLength(50), Column("GroupId"), Required, ForeignKey(nameof(Group))]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(50), Column("UserId"), Required, ForeignKey(nameof(User))]
        public new string NameField { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }


    }
}
