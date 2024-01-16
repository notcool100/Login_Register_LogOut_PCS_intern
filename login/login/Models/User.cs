using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace login.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[DisplayName("Full Name")]
		public string Name { get; set; }
		[Required]
		[DisplayName("Email")]
		public string Email { get; set; }
		[Required]
		[DisplayName("Password")]
		[MinLength(8, ErrorMessage = "The {0} must be at least {1} characters long.")]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "The password must include at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
		public string Password { get; set; }
		[Required]
		[DisplayName("Phone Number")]
		public int PhoneNumber { get; set; }

	}
}
