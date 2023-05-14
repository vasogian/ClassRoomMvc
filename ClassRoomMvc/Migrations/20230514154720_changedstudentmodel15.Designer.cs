﻿// <auto-generated />
using System;
using ClassRoomMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClassRoomMvc.Migrations
{
    [DbContext(typeof(ClassRoomMvcContext))]
    [Migration("20230514154720_changedstudentmodel15")]
    partial class changedstudentmodel15
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssignmentStudent", b =>
                {
                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsStudentId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId", "StudentsStudentId");

                    b.HasIndex("StudentsStudentId");

                    b.ToTable("AssignmentStudent");
                });

            modelBuilder.Entity("ClassRoomMvc.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"), 1L, 1);

                    b.Property<string>("AssignmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<decimal>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("ClassRoomMvc.Models.ClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassRoomId"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassRoomId");

                    b.ToTable("ClassRoom");
                });

            modelBuilder.Entity("ClassRoomMvc.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<int?>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<string>("StudentLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ClassRoomMvc.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"), 1L, 1);

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.HasIndex("ClassRoomId")
                        .IsUnique();

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("AssignmentStudent", b =>
                {
                    b.HasOne("ClassRoomMvc.Models.Assignment", null)
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassRoomMvc.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassRoomMvc.Models.Assignment", b =>
                {
                    b.HasOne("ClassRoomMvc.Models.ClassRoom", null)
                        .WithMany("Assignments")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassRoomMvc.Models.Student", b =>
                {
                    b.HasOne("ClassRoomMvc.Models.ClassRoom", null)
                        .WithMany("Students")
                        .HasForeignKey("ClassRoomId");
                });

            modelBuilder.Entity("ClassRoomMvc.Models.Teacher", b =>
                {
                    b.HasOne("ClassRoomMvc.Models.ClassRoom", "ClassRoom")
                        .WithOne("Teacher")
                        .HasForeignKey("ClassRoomMvc.Models.Teacher", "ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");
                });

            modelBuilder.Entity("ClassRoomMvc.Models.ClassRoom", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Students");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
