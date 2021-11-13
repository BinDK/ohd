using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project3.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<HeadTask> HeadTasks { get; set; }
        public virtual DbSet<ReqLog> ReqLogs { get; set; }
        public virtual DbSet<RequestByUser> RequestByUsers { get; set; }
        public virtual DbSet<RequestPriority> RequestPriorities { get; set; }
        public virtual DbSet<RequestStatus> RequestStatuses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<UserTask> UserTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__account__role_id__398D8EEE");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("facility");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.HeadAccountId).HasColumnName("head_account_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.HasOne(d => d.HeadAccount)
                    .WithMany(p => p.Facilities)
                    .HasForeignKey(d => d.HeadAccountId)
                    .HasConstraintName("FK_facility_account");
            });

            modelBuilder.Entity<HeadTask>(entity =>
            {
                entity.ToTable("head_task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.HeadAccountId).HasColumnName("head_account_id");

                entity.Property(e => e.HeadTaskStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("head_task_status")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.RequestByUserId).HasColumnName("request_by_user_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.HeadAccount)
                    .WithMany(p => p.HeadTasks)
                    .HasForeignKey(d => d.HeadAccountId)
                    .HasConstraintName("FK__head_task__head___3D5E1FD2");

                entity.HasOne(d => d.RequestByUser)
                    .WithMany(p => p.HeadTasks)
                    .HasForeignKey(d => d.RequestByUserId)
                    .HasConstraintName("FK__head_task__reque__3A81B327");
            });

            modelBuilder.Entity<ReqLog>(entity =>
            {
                entity.ToTable("req_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LogTime)
                    .HasColumnType("datetime")
                    .HasColumnName("log_time");

                entity.Property(e => e.ReqContent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("req_content")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.RequestByUserId).HasColumnName("request_by_user_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");
            });

            modelBuilder.Entity<RequestByUser>(entity =>
            {
                entity.ToTable("request_by_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.FacilityId).HasColumnName("facility_id");

                entity.Property(e => e.ReasonCloseRequest)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("reason_close_request")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.RequestPriorityId).HasColumnName("request_priority_id");

                entity.Property(e => e.RequestStatusId).HasColumnName("request_status_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RequestByUsers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__request_b__accou__33D4B598");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.RequestByUsers)
                    .HasForeignKey(d => d.FacilityId)
                    .HasConstraintName("FK__request_b__facil__36B12243");

                entity.HasOne(d => d.RequestPriority)
                    .WithMany(p => p.RequestByUsers)
                    .HasForeignKey(d => d.RequestPriorityId)
                    .HasConstraintName("FK__request_b__reque__35BCFE0A");

                entity.HasOne(d => d.RequestStatus)
                    .WithMany(p => p.RequestByUsers)
                    .HasForeignKey(d => d.RequestStatusId)
                    .HasConstraintName("FK__request_b__reque__34C8D9D1");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.RequestByUsers)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__request_b__servi__37A5467C");
            });

            modelBuilder.Entity<RequestPriority>(entity =>
            {
                entity.ToTable("request_priority");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<RequestStatus>(entity =>
            {
                entity.ToTable("request_status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.FacilityId).HasColumnName("facility_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.FacilityId)
                    .HasConstraintName("FK_service_facility");
            });

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.ToTable("user_task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.HeadTaskId).HasColumnName("head_task_id");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.RequestByUserId).HasColumnName("request_by_user_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.UserAccountId).HasColumnName("user_account_id");

                entity.Property(e => e.UserTaskStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_task_status")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.HasOne(d => d.HeadTask)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.HeadTaskId)
                    .HasConstraintName("FK__user_task__head___38996AB5");

                entity.HasOne(d => d.RequestByUser)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.RequestByUserId)
                    .HasConstraintName("FK__user_task__reque__3B75D760");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.UserAccountId)
                    .HasConstraintName("FK__user_task__user___3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
