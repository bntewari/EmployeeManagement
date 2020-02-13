using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagementMVC.Models
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The First Name is required.")]
        [MinLength(4, ErrorMessage = "The First Name must be atleast 5 characters")]
        [MaxLength(15, ErrorMessage = "The First Name cannot be more than 15 characters")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "The Last Name should be between 5 to 15 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Birth is required.")]
        public Nullable<System.DateTime> DOB { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter PhoneNumber as 0123456789, 012-345-6789, (012)-345-6789.")]
        public string ContactNo { get; set; }
        public Nullable<decimal> Salary { get; set; }
    }
}