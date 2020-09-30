using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StudentMicroservice.Model;
using StudentMicroservice.Repository;
using StudentMicroservice.ViewModel;

namespace StudentMicroservice.Controllers
{    
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet("api/Student")]
        public IEnumerable<Student> Get()
        {
            return studentRepository.GetStudents();
        }

        // GET: api/Student/5
        [HttpGet("api/Student/{id}")]
        public Student Get(int id)
        {
            return studentRepository.GetStudentByID(id);
        }


        // POST: api/Student
        [HttpPost("api/Student")]
        public IActionResult Student([FromBody] StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                if (studentViewModel != null)
                {
                    Student student = new Student();
                    student.FirstName = studentViewModel.FirstName;
                    student.LastName = studentViewModel.LastName;
                    student.Email = studentViewModel.Email;
                    student.Phone = studentViewModel.Phone;
                    student.Password = studentViewModel.Password;

                    var addedStudent = studentRepository.InsertStudent(student);
                    int id = addedStudent.Id;
                    studentViewModel.Id = id;
                    return StatusCode(StatusCodes.Status201Created, studentViewModel);
                }
                else
                {
                    return StatusCode(404, "Sending data is not valid");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Parameter type/data not accurate!");
            }
        }


        // POST: api/Student
        //add student with photo by passign formdata
        [HttpPost("api/Student/AddStudent")]
        public IActionResult AddStudent([FromForm] StudentViewModel studentViewModel)
        {
            if (studentViewModel != null)
            {                

                Student student = new Student();               
                student.FirstName = studentViewModel.FirstName;
                student.LastName = studentViewModel.LastName;
                student.Email = studentViewModel.Email;
                student.Phone = studentViewModel.Phone;
                student.Password = studentViewModel.Password;

                var image = studentViewModel.Photo;
                var folderPath= Path.Combine(Directory.GetCurrentDirectory(), "Image");
                var pathToSave = "";

                if (image.Length > 0)
                {
                    pathToSave= Path.Combine(folderPath, image.FileName);

                    using (var fileStream = new FileStream(pathToSave, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                }

                student.Photo = pathToSave;

                var addedStudent = studentRepository.InsertStudent(student);

                if(studentViewModel.PortfolioImage!=null)
                {
                    PortfolioImage(studentViewModel.PortfolioImage, addedStudent.Id);
                }
                return StatusCode(StatusCodes.Status201Created, addedStudent);
            }
            else
            {
                return StatusCode(404, "Sending data is not valid");
            }           
        }

        [NonAction]
        private void PortfolioImage(List<IFormFile> portfolioImage, int studentId)
        {
            if(portfolioImage.Count>0)
            {
                foreach(var item in portfolioImage)
                {
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Image");
                    folderPath= Path.Combine(folderPath, "Portfolio");
                    var pathToSave = "";

                    if (item.Length > 0)
                    {
                        pathToSave = Path.Combine(folderPath, item.FileName);

                        using (var fileStream = new FileStream(pathToSave, FileMode.Create))
                        {
                            item.CopyTo(fileStream);
                        }

                        StudentPortfolioImage studentPortfolioImage = new StudentPortfolioImage();
                        studentPortfolioImage.StudentID = studentId;
                        studentPortfolioImage.ImageUrl = pathToSave;
                        studentRepository.InsertStudentPortfolioImage(studentPortfolioImage);
                    }
                }
            }
        }
    }
}