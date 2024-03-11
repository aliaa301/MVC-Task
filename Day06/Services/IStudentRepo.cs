using Day06.Models;
using Microsoft.EntityFrameworkCore;
namespace Day06.Services
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Update(Student student);
        void Delete(int id);
        void Add(Student student);

    }
}
