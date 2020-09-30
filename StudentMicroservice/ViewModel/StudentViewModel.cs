using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMicroservice.ViewModel
{
    public class StudentViewModel
    {
        
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [MinLength(4, ErrorMessage ="Password length min should be 4 digit")]
        public string Password { get; set; }
        public IFormFile Photo { get; set; }

        public List<IFormFile> PortfolioImage { get; set; }
    }
}
