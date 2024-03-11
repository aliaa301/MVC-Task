using Day06.Models;
using Day06.Services;
namespace Day06.TestRepo
{
    public class DepartmentTestRepo:IDepartmentRepo
    {
        static List<Department> DeptList = [new Department()
        {
            DeptId = 1,
            Name = "Sd"
        },
        ];
        public List<Department> GetAll()
        { return DeptList; }

        public Department GetById(int id)
        {
            return DeptList.FirstOrDefault(a => a.DeptId == id);

        }
        public void Update(Department dept)
        {
            var m = GetById(dept.DeptId);
            m.Name = dept.Name;
            m.Status = dept.Status;
        }
        public void Delete(int id)
        {
            var m = GetById(id);
            DeptList.Remove(m);
        }
        public void Add(Department dept)
        {
            DeptList.Add(dept);
        }
        public Department GetByName(string name )
        {
            return DeptList.FirstOrDefault(a => a.Name == name);
        }
    }
}
