﻿using System.ComponentModel.DataAnnotations;

namespace Miam.Domain.Entities
{
    public class MiamRole : Entity
    {

        public string RoleName { get; set; }

        // Foreign key
        public int ApplicationUserId { get; set; }

        //Navigation properties
        [Required]
        public MiamUser MiamUsers { get; set; }

    }
}