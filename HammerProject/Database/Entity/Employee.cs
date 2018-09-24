using HammerProject.Database.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HammerProject.Database.Entity
{
    /// <summary>
    /// Employee Entity
    /// </summary>
    public class Employee : IHasLastModified
    {
        // Database fields
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public DateTime? lastModifyDate { get; set; }

        // Database relations
        public virtual Department Department { get; set; }
    }
}