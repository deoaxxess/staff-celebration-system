using Microsoft.EntityFrameworkCore;
using StaffCelebrationSystemAPI.Entities;
using StaffCelebrationSystemAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffCelebrationSystemAPI.Data
{
    /// <summary>
    /// Database context for StaffSystem Project
    /// </summary>
    public class StaffSystemDBContext : DbContext
    {
        public StaffSystemDBContext(DbContextOptions<StaffSystemDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<PrivateEmailToNotify> EmailsToNotify { get; set; }
        public virtual DbSet<EventEmailToNotify> EventEmails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Events)
                .WithOne(em => em.Employee)
                .HasForeignKey(em => em.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventEmailToNotify>()
                .HasKey(e => new { e.EventId, e.EmailToNotifyId });

            modelBuilder.Entity<EventEmailToNotify>()
                .HasOne(e => e.Event)
                .WithMany(pe => pe.EmailsToNotify)
                .HasForeignKey(e => e.EventId);

            modelBuilder.Entity<EventEmailToNotify>()
                .HasOne(pe => pe.EmailToNotify)
                .WithMany(en => en.EmailsToNotify)
                .HasForeignKey(pe => pe.EmailToNotifyId);
        }
    }
}
