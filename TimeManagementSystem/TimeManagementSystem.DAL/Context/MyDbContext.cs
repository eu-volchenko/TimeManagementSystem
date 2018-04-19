namespace TimeManagementSystem.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TimeManagementSystem.DAL.Entities;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext(string connectionString = "name=DbContext")
            : base(connectionString)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivitiesInProject> ActivitiesInProjects { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Risk> Risks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Teammate> Teammates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.ActivitiesInProjects)
                .WithRequired(e => e.Activity)
                .HasForeignKey(e => e.NameActivity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivitiesInProject>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<ActivitiesInProject>()
                .Property(e => e.NameActivity)
                .IsUnicode(false);

            modelBuilder.Entity<ActivitiesInProject>()
                .HasMany(e => e.Reports)
                .WithRequired(e => e.ActivitiesInProject)
                .HasForeignKey(e => e.IdActivity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Teammates)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.IdPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.InitialEffort)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.InitialMilestones)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.InitialTimeline)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ActivitiesInProjects)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.IdProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Reports)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.IdProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Risks)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.IdProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.IdProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Teammates)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.IdProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Risk>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Risk>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.ActivitiesInProjects)
                .WithRequired(e => e.Role1)
                .HasForeignKey(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Teammates)
                .WithRequired(e => e.Role1)
                .HasForeignKey(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Status1)
                .HasForeignKey(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.Reports)
                .WithOptional(e => e.Task)
                .HasForeignKey(e => e.IdTask);

            modelBuilder.Entity<Teammate>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<Teammate>()
                .HasMany(e => e.Reports)
                .WithRequired(e => e.Teammate)
                .HasForeignKey(e => e.IdDeveloper)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teammate>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.Teammate)
                .HasForeignKey(e => e.IdDeveloper);
        }
    }
}
