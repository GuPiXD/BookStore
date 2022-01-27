using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Feature.Authors.Models
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

    [Range(1, 5)]
    public byte? Rating { get; set; }
  }
}
