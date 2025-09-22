using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StaffCelebrationSystemAPI.Models.Entities
{
    /// <summary>
    /// Join Table to Events and Private emails to notify
    /// </summary>
    public class EventEmailToNotify
    {
        public Guid EventId { get; set; }
        public Guid EmailToNotifyId { get; set; }

        //Navigation Properties
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
        [ForeignKey("EmailToNotifyId")]
        public virtual PrivateEmailToNotify EmailToNotify { get; set; }
    }
}
