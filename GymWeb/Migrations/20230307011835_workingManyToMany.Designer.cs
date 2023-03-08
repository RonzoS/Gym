﻿// <auto-generated />
using System;
using GymWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230307011835_workingManyToMany")]
    partial class workingManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GymWeb.Model.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Clues")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("GymWeb.Model.ExerciseMuscle", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("MuscleId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseId", "MuscleId");

                    b.HasIndex("MuscleId");

                    b.ToTable("ExerciseMuscle");
                });

            modelBuilder.Entity("GymWeb.Model.ExerciseSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExerciseSet");
                });

            modelBuilder.Entity("GymWeb.Model.ExerciseSetRepeat", b =>
                {
                    b.Property<int>("ExerciseSetId")
                        .HasColumnType("int");

                    b.Property<int>("RepeatId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseSetId", "RepeatId");

                    b.HasIndex("RepeatId");

                    b.ToTable("RepeatExercise");
                });

            modelBuilder.Entity("GymWeb.Model.ExerciseTool", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseId", "ToolId");

                    b.HasIndex("ToolId");

                    b.ToTable("ExerciseTool");
                });

            modelBuilder.Entity("GymWeb.Model.Muscle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Muscle");
                });

            modelBuilder.Entity("GymWeb.Model.Repeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("FirstRepeats")
                        .HasColumnType("int");

                    b.Property<float>("FirstWeight")
                        .HasColumnType("real");

                    b.Property<int>("FourthRepeats")
                        .HasColumnType("int");

                    b.Property<float>("FourthWeight")
                        .HasColumnType("real");

                    b.Property<int>("SecoundRepeats")
                        .HasColumnType("int");

                    b.Property<float>("SecoundWeight")
                        .HasColumnType("real");

                    b.Property<int>("ThirdRepeats")
                        .HasColumnType("int");

                    b.Property<float>("ThirdWeight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Repeat");
                });

            modelBuilder.Entity("GymWeb.Model.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tool");
                });

            modelBuilder.Entity("GymWeb.Model.ExerciseMuscle", b =>
                {
                    b.HasOne("GymWeb.Model.Exercise", "Exercise")
                        .WithMany("ExerciseMuscles")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymWeb.Model.Muscle", "Muscle")
                        .WithMany("ExerciseMuscles")
                        .HasForeignKey("MuscleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Muscle");
                });

            modelBuilder.Entity("GymWeb.Model.ExerciseSetRepeat", b =>
                {
                    b.HasOne("GymWeb.Model.ExerciseSet", "ExerciseSet")
                        .WithMany("ExerciseSetRepeats")
                        .HasForeignKey("ExerciseSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymWeb.Model.Repeat", "Repeat")
                        .WithMany("ExerciseSetRepeats")
                        .HasForeignKey("RepeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseSet");

                    b.Navigation("Repeat");
                });

            modelBuilder.Entity("GymWeb.Model.ExerciseTool", b =>
                {
                    b.HasOne("GymWeb.Model.Exercise", "Exercise")
                        .WithMany("ExerciseTools")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymWeb.Model.Tool", "Tool")
                        .WithMany("ExerciseTools")
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("GymWeb.Model.Repeat", b =>
                {
                    b.HasOne("GymWeb.Model.Exercise", "Exercise")
                        .WithMany("Repeats")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("GymWeb.Model.Exercise", b =>
                {
                    b.Navigation("ExerciseMuscles");

                    b.Navigation("ExerciseTools");

                    b.Navigation("Repeats");
                });

            modelBuilder.Entity("GymWeb.Model.ExerciseSet", b =>
                {
                    b.Navigation("ExerciseSetRepeats");
                });

            modelBuilder.Entity("GymWeb.Model.Muscle", b =>
                {
                    b.Navigation("ExerciseMuscles");
                });

            modelBuilder.Entity("GymWeb.Model.Repeat", b =>
                {
                    b.Navigation("ExerciseSetRepeats");
                });

            modelBuilder.Entity("GymWeb.Model.Tool", b =>
                {
                    b.Navigation("ExerciseTools");
                });
#pragma warning restore 612, 618
        }
    }
}
