using Microsoft.EntityFrameworkCore;
using SocializeData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeData.DbContexts
{
    public static class TablesConfiguration
    {
        public static void AddSocializeTablesConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(m =>
            {
                m.ToTable("Users");
                m.HasKey("UserID");
                m.Property(p => p.UserID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Event>(m =>
            {
                m.ToTable("Events");
                m.HasKey("EventID");
                m.Property(p => p.EventID).ValueGeneratedOnAdd();
            });
        }
    }
}
