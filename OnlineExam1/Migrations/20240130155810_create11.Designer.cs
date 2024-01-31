﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineExam1.Entity;

#nullable disable

namespace OnlineExam1.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240130155810_create11")]
    partial class create11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineExam1.Entity.AssignedTest", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentID"), 1L, 1);

                    b.Property<DateTime>("ScheduledDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TestID")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("char(5)");

                    b.HasKey("AssignmentID");

                    b.HasIndex("TestID");

                    b.HasIndex("UserId");

                    b.ToTable("AssignedTests");
                });

            modelBuilder.Entity("OnlineExam1.Entity.Organization", b =>
                {
                    b.Property<int>("OrgID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrgID"), 1L, 1);

                    b.Property<string>("OrgName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("OrgID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("OnlineExam1.Entity.QuestionBank", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionID"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Option1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("QuestionID");

                    b.HasIndex("SubjectID");

                    b.ToTable("QuestionBanks");
                });

            modelBuilder.Entity("OnlineExam1.Entity.Site", b =>
                {
                    b.Property<int>("SiteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteID"), 1L, 1);

                    b.Property<int>("OrgID")
                        .HasColumnType("int");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SiteID");

                    b.HasIndex("OrgID");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("OnlineExam1.Entity.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectID"), 1L, 1);

                    b.Property<int>("SiteID")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SubjectID");

                    b.HasIndex("SiteID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("OnlineExam1.Entity.TestStructure", b =>
                {
                    b.Property<int>("TestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestID"), 1L, 1);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("NoOfQuestions")
                        .HasColumnType("int");

                    b.Property<int>("SiteID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TotalMarks")
                        .HasColumnType("int");

                    b.HasKey("TestID");

                    b.HasIndex("SiteID");

                    b.HasIndex("SubjectID");

                    b.ToTable("TestStructures");
                });

            modelBuilder.Entity("OnlineExam1.Entity.User", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("char(5)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Username");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Role");

                    b.Property<int>("SiteID")
                        .HasColumnType("int");

                    b.Property<string>("UploadImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("SiteID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnlineExam1.Entity.UserResponse", b =>
                {
                    b.Property<int>("ResponseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResponseID"), 1L, 1);

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<int>("TestID")
                        .HasColumnType("int");

                    b.Property<string>("UserAnswer")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("char(5)");

                    b.HasKey("ResponseID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("TestID");

                    b.HasIndex("UserId");

                    b.ToTable("UserResponses");
                });

            modelBuilder.Entity("OnlineExam1.Entity.AssignedTest", b =>
                {
                    b.HasOne("OnlineExam1.Entity.TestStructure", "Test")
                        .WithMany()
                        .HasForeignKey("TestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineExam1.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineExam1.Entity.QuestionBank", b =>
                {
                    b.HasOne("OnlineExam1.Entity.Subject", "Subject")
                        .WithMany("QuestionBanks")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("OnlineExam1.Entity.Site", b =>
                {
                    b.HasOne("OnlineExam1.Entity.Organization", "Organization")
                        .WithMany("Sites")
                        .HasForeignKey("OrgID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("OnlineExam1.Entity.Subject", b =>
                {
                    b.HasOne("OnlineExam1.Entity.Site", "Site")
                        .WithMany("Subjects")
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("OnlineExam1.Entity.TestStructure", b =>
                {
                    b.HasOne("OnlineExam1.Entity.Site", "Site")
                        .WithMany("TestStructures")
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineExam1.Entity.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("OnlineExam1.Entity.User", b =>
                {
                    b.HasOne("OnlineExam1.Entity.Site", "Site")
                        .WithMany("Users")
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("OnlineExam1.Entity.UserResponse", b =>
                {
                    b.HasOne("OnlineExam1.Entity.QuestionBank", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineExam1.Entity.TestStructure", "AssignedTest")
                        .WithMany()
                        .HasForeignKey("TestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineExam1.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedTest");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineExam1.Entity.Organization", b =>
                {
                    b.Navigation("Sites");
                });

            modelBuilder.Entity("OnlineExam1.Entity.Site", b =>
                {
                    b.Navigation("Subjects");

                    b.Navigation("TestStructures");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OnlineExam1.Entity.Subject", b =>
                {
                    b.Navigation("QuestionBanks");
                });
#pragma warning restore 612, 618
        }
    }
}
