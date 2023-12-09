using Microsoft.EntityFrameworkCore;

namespace PoliSchool.WebCourse.Data
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Department");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Budget).HasColumnType("money");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}