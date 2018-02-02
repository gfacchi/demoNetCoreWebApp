﻿// <auto-generated />
using demoWebAppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace demoWebAppCore.Migrations
{
    [DbContext(typeof(EsameDiStatoContext))]
    [Migration("20180202221017_Identity")]
    partial class Identity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("demoWebAppCore.Models.Exams", b =>
                {
                    b.Property<int>("Pkexam")
                        .HasColumnName("PKExam");

                    b.Property<DateTime>("ExDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Pkexam");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("demoWebAppCore.Models.Students", b =>
                {
                    b.Property<int>("Pkstudent")
                        .HasColumnName("PKStudent");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false);

                    b.HasKey("Pkstudent");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("demoWebAppCore.Models.StudentsExams", b =>
                {
                    b.Property<int>("Ppkfkstudent")
                        .HasColumnName("PPKFKStudent");

                    b.Property<int>("Ppkfkexam")
                        .HasColumnName("PPKFKExam");

                    b.Property<int>("Grade");

                    b.HasKey("Ppkfkstudent", "Ppkfkexam");

                    b.HasIndex("Ppkfkexam");

                    b.ToTable("StudentsExams");
                });

            modelBuilder.Entity("demoWebAppCore.Models.StudentsExams", b =>
                {
                    b.HasOne("demoWebAppCore.Models.Exams", "PpkfkexamNavigation")
                        .WithMany("StudentsExams")
                        .HasForeignKey("Ppkfkexam")
                        .HasConstraintName("FK__StudentsE__PPKFK__286302EC");

                    b.HasOne("demoWebAppCore.Models.Students", "PpkfkstudentNavigation")
                        .WithMany("StudentsExams")
                        .HasForeignKey("Ppkfkstudent")
                        .HasConstraintName("FK__StudentsE__PPKFK__276EDEB3");
                });
#pragma warning restore 612, 618
        }
    }
}