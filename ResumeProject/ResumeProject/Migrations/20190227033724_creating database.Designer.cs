﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ResumeProject.Data;
using System;

namespace ResumeProject.Migrations
{
    [DbContext(typeof(ResumeContext))]
    [Migration("20190227033724_creating database")]
    partial class creatingdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ResumeProject.Models.Description", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Duties");

                    b.Property<int>("ExperienceID");

                    b.HasKey("ID");

                    b.HasIndex("ExperienceID");

                    b.ToTable("Description");
                });

            modelBuilder.Entity("ResumeProject.Models.Education", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Degree");

                    b.Property<DateTime>("GraduationDate");

                    b.Property<int>("PersonID");

                    b.Property<string>("School");

                    b.HasKey("ID");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("ResumeProject.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("EventType");

                    b.Property<int>("PersonID");

                    b.Property<string>("Role");

                    b.HasKey("ID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("ResumeProject.Models.Experience", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CurrentlyStillWorking");

                    b.Property<string>("Organization");

                    b.Property<string>("Role");

                    b.Property<int>("YearsService");

                    b.HasKey("ID");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("ResumeProject.Models.ExperienceType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExpType");

                    b.Property<int>("ExperienceID");

                    b.HasKey("ID");

                    b.HasIndex("ExperienceID");

                    b.ToTable("ExperienceType");
                });

            modelBuilder.Entity("ResumeProject.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EducationID");

                    b.Property<string>("Email");

                    b.Property<int?>("EventID");

                    b.Property<int?>("ExperienceID");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<int?>("PersonalSkillID");

                    b.Property<int>("PhoneNumber");

                    b.HasKey("ID");

                    b.HasIndex("EducationID");

                    b.HasIndex("EventID");

                    b.HasIndex("ExperienceID");

                    b.HasIndex("PersonalSkillID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("ResumeProject.Models.PersonalSkill", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonID");

                    b.Property<string>("Skill");

                    b.HasKey("ID");

                    b.ToTable("PersonalSkill");
                });

            modelBuilder.Entity("ResumeProject.Models.Description", b =>
                {
                    b.HasOne("ResumeProject.Models.Experience", "Experience")
                        .WithMany()
                        .HasForeignKey("ExperienceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ResumeProject.Models.ExperienceType", b =>
                {
                    b.HasOne("ResumeProject.Models.Experience", "Experience")
                        .WithMany()
                        .HasForeignKey("ExperienceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ResumeProject.Models.Person", b =>
                {
                    b.HasOne("ResumeProject.Models.Education")
                        .WithMany("Persons")
                        .HasForeignKey("EducationID");

                    b.HasOne("ResumeProject.Models.Event")
                        .WithMany("Persons")
                        .HasForeignKey("EventID");

                    b.HasOne("ResumeProject.Models.Experience")
                        .WithMany("Persons")
                        .HasForeignKey("ExperienceID");

                    b.HasOne("ResumeProject.Models.PersonalSkill")
                        .WithMany("Persons")
                        .HasForeignKey("PersonalSkillID");
                });
#pragma warning restore 612, 618
        }
    }
}
