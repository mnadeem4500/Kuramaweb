using ExtremeClassified.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{

    [Table("UserActivities")]
    [Keyless]
    public class UserActivity : EntityBase
    {
        [MaxLength(36), Column("ActivityId")]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(36), Column("UserId")]
        public new string NameField { get; set; }

    }
}
