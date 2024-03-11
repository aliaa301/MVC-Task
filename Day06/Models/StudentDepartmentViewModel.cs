namespace Day06.Models
{
    public class StudentDepartmentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Department>? Department { get; set; }
    }
}
