using System.ComponentModel.DataAnnotations;

namespace Xakpc.RazorHtmx.Validation;

public record UserRegistrationForm
{
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; init; }

    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
    [Display(Name = "Last Name")]
    public string LastName { get; init; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Display(Name = "Email Address")]
    public string Email { get; init; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
    [Display(Name = "Password")]
    public string Password { get; init; }

    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password", ErrorMessage = "Password and Confirmation Password do not match")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; init; }

    [Required(ErrorMessage = "Phone Number is required")]
    [Phone(ErrorMessage = "Invalid Phone Number")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; init; }

    [Required(ErrorMessage = "Age is required")]
    [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]    
    [Display(Name = "Age")]
    public int Age { get; init; }

    [Required(ErrorMessage = "Date of Birth is required")]
    [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; init; }
}