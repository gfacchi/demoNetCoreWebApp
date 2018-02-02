using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace demoWebAppCore.Models
{
    public partial class EsameDiStatoContext : DbContext
    {
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsExams> StudentsExams { get; set; }

        public EsameDiStatoContext(DbContextOptions<EsameDiStatoContext> options) // RICORDARSI DI SOSTITUIRE IL METODO AD OGNI SCAFFOLD
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exams>(entity =>
            {
                entity.HasKey(e => e.Pkexam);

                entity.Property(e => e.Pkexam)
                    .HasColumnName("PKExam")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExDate).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.Pkstudent);

                entity.Property(e => e.Pkstudent)
                    .HasColumnName("PKStudent")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentsExams>(entity =>
            {
                entity.HasKey(e => new { e.Ppkfkstudent, e.Ppkfkexam });

                entity.Property(e => e.Ppkfkstudent).HasColumnName("PPKFKStudent");

                entity.Property(e => e.Ppkfkexam).HasColumnName("PPKFKExam");

                entity.HasOne(d => d.PpkfkexamNavigation)
                    .WithMany(p => p.StudentsExams)
                    .HasForeignKey(d => d.Ppkfkexam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentsE__PPKFK__286302EC");

                entity.HasOne(d => d.PpkfkstudentNavigation)
                    .WithMany(p => p.StudentsExams)
                    .HasForeignKey(d => d.Ppkfkstudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentsE__PPKFK__276EDEB3");
            });
        }
    }
}
