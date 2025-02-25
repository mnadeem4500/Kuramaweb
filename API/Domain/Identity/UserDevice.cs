﻿using ExtremeClassified.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// UserDevice Entity in database
    /// </summary>
    /// 

    [Table("UserDevices")]
    public class UserDevice : EntityBase
    {
        [Key]
        [MaxLength(100),Column("DeviceId")]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [Required, MaxLength(255), Column("DeviceName")]
        public new string NameField { get; set; }

        [Required, MaxLength(50)]
        public string UserId { get; set; }


        [MaxLength(512)]
        public string Description { get; set; }

        [MaxLength(255)]
        public string Model { get; set; }

        [MaxLength(255)]
        public string Vender { get; set; }

        [MaxLength(255)]
        public string DeviceOs { get; set; }

        public string FingerPrint { get; set; }

        public User User { get; set; }

    }
}
