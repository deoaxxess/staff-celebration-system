using System;
using System.Collections.Generic;
using System.Text;

namespace StaffCelebrationSystemAPI.Models.Entities
{
    public class PrivateEmailToNotify
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<EventEmailToNotify> EmailsToNotify { get; set; }
    }
}
