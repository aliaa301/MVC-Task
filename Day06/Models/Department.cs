using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Day06.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Remote("CheckDeptID", "Department")]
        public int DeptId { get; set; }
        [Remote("CheckDeptName", "Department", AdditionalFields = "DeptId")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;
        public ICollection<Student> students { get; set; } = new HashSet<Student>();

    }
}
