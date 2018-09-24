using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HammerProject.Database.Entity
{
    /// <summary>
    /// Entity Deparment
    /// </summary>
    public class Department
    {
        // Database fields
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Location { get; set; }

        // Database relations
        public virtual ICollection<Employee> Employees { get; set; }
    }
}