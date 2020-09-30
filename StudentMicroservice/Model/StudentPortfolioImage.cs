using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMicroservice.Model
{
    public class StudentPortfolioImage
    {
        [Key]
        public int PhotoID { get; set; }
        public int StudentID { get; set; }
        public string ImageUrl { get; set; }
    }
}
