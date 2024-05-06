using System;
using System.ComponentModel.DataAnnotations;

namespace TMS.TMSService.Application.DTOs
{
	public class UserDto
	{
        public int UserId { get; set; }

        [Required(ErrorMessage="DisplayName is required")]
        [MaxLength(50,ErrorMessage="DisplayName cannot exceed 50 characters")]
        public string DisplayName { get; set; } = null!;

        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(50, ErrorMessage = "FirstName cannot exceed 50 characters")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(50, ErrorMessage = "LastName cannot exceed 50 characters")]
        public string LastName { get; set; } = null!;
    }
}

