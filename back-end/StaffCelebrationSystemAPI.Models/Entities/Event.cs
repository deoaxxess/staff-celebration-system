using StaffCelebrationSystemAPI.Entities;
using StaffCelebrationSystemAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StaffCelebrationSystemAPI.Models.Entities
{
    public class Event
    {
        [Key]
        public Guid EventId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid MyProperty { get; set; }
        public string EventName { get; set; }
        public DateTime DateOfEvent { get; set; }
        public bool IsPrivate { get; set; }
        public EventType EventType { get; set; }

        //Navigation Property
        public Employee Employee { get; set; }
        public virtual ICollection<EventEmailToNotify> EmailsToNotify { get; set; }


    }
}
