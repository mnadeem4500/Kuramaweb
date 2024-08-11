using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// UserAccess Entity in database
    /// </summary>
    /// 

    [Table("UserAccess")]
    public class UserAccess : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("Id")]
        public new int KeyField { get; set; }

        [Required, MaxLength(50), Column("UserId"), ForeignKey(nameof(User))]
        public new string NameField { get; set; }
        public bool AllDay { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public virtual User User { get; set; }
    }
}
