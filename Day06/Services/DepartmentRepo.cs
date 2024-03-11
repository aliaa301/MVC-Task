using Day06.Models;
using Microsoft.EntityFrameworkCore;

namespace Day06.Services
{
    public class DepartmentRepo:IDepartmentRepo
    {

        ITIDBContext db;// = new ITIDBContext();

        public DepartmentRepo(ITIDBContext _db)
        {
            db = _db;
        }
        public List<Department> GetAll()
        {
            return db.Departments.Where(a=>a.Status==true).ToList();
        }
        public Department GetById(int id)
        {
            return db.Departments.SingleOrDefault(a => a.DeptId == id);

        }
        public Department GetByName(string name)
        {
            return db.Departments.FirstOrDefault(d => d.Name == name);
        }
        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public void Update(Department dept)
        {
            db.Departments.Update(dept);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var m = db.Departments.SingleOrDefault(a => a.DeptId == id);
            //db.Departments.Remove(m);
            m.Status=false;
            db.SaveChanges();
        }
    }
}
