using Day06.Models;

namespace Day06.Services
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        Department GetById(int id);
        Department GetByName(string name);


        void Update(Department dept);
        void Delete(int id);
        void Add(Department dept);
    }
}
