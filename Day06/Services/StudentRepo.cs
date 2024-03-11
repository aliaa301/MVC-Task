using Day06.Models;

using Microsoft.EntityFrameworkCore;

namespace Day06.Services
{
    public class StudentRepo : IStudentRepo
    {

        ITIDBContext db;// = new ITIDBContext();

        public StudentRepo(ITIDBContext _db)
        {
            db = _db;
        }

        public List<Student> GetAll()
        {
            return db.Students.Include(a=>a.department).Where(a=>a.department.Status==true).ToList();
        }
        public Student GetById(int id) {
            return db.Students.SingleOrDefault(a => a.Id == id);

        }
        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var m = db.Students.SingleOrDefault(a => a.Id == id);
            db.Students.Remove(m);
            db.SaveChanges();
        }

        public List<Student> GetALl()
        {
            throw new NotImplementedException();
        }

        public Student GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
