using StaffCelebrationSystemAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaffCelebrationSystemAPI.Entities
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = true;

        //Navigation Property
        public ICollection<Event> Events { get; set; }

    }
}
