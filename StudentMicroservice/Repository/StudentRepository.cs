using StudentMicroservice.DBContexts;
using StudentMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMicroservice.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentDBContext studentDBContext;
        public StudentRepository(StudentDBContext studentDBContext)
        {
            this.studentDBContext = studentDBContext;
        }
        public Student GetStudentByID(int StudentID)
        {
            return studentDBContext.Students.Where(x => x.Id == StudentID).FirstOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            return studentDBContext.Students.ToList();
        }

        public Student InsertStudent(Student student)
        {
            studentDBContext.Students.Add(student);
            Save();
            return student;
        }

        public void InsertStudentPortfolioImage(StudentPortfolioImage studentPortfolioImage)
        {
            studentDBContext.StudentPortfolioImages.Add(studentPortfolioImage);
            Save();            
        }

        public void Save()
        {
            studentDBContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
