using StudentMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMicroservice.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int StudentID);
        Student InsertStudent(Student student);
        void UpdateStudent(Student student);
        void InsertStudentPortfolioImage(StudentPortfolioImage studentPortfolioImage);
        void Save();
    }
}
