using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace TimeTrackerV2.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<WBS> WBSs { get; set; }
        public DbSet<TaskHistoryItem> TaskHistoryItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=" + App.databasePath);


        public void DeleteFromDatabase(Project project)
        {
            Projects.Remove(project);
            SaveChangesWithValidation();
        }

        public void DeleteFromDatabase(WBS wbs)
        {
            WBSs.Remove(wbs);
            SaveChangesWithValidation();
        }

        public void InsertIntoDatabase(Project project)
        {
            Projects.Add(project);
            SaveChangesWithValidation();
        }

        public void InsertIntoDatabase(WBS wbs)
        {
            WBSs.Add(wbs);
            SaveChangesWithValidation();
        }


        private void SaveChangesWithValidation()
        {
            // TODO: Add try/catch here
            SaveChanges();
        }
    }
}
