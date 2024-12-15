﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductManagementAPI.Models
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public int UId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

