using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Feature.Clients.Models
{
  public class FormViewModel
  {
    [Required(ErrorMessage = "Id is missing and is required to edit or register")]
    public string Id { get; set; }

    [Required(ErrorMessage = "First Name is required to register")]
    [StringLength(40, ErrorMessage = "First Name is too long")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required to register")]
    [StringLength(40, ErrorMessage = "Last Name is too long")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Address is required to register")]
    public string Address { get; set; }

    [Required(ErrorMessage = "E-mail Address is required to register")]
    [EmailAddress(ErrorMessage = "Not a valid e-mail address")]
    [Display(Name = "E-mail address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required to register")]
    [Phone(ErrorMessage = "Not a valid phone number")]
    [Display(Name = "Phone number")]
    public string Phone { get; set; }

    public string Job { get; set; }
  }
}
