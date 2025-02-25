﻿// <auto-generated />
using System;
using AutorsServices.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutorsServices.DAL.Migrations
{
    [DbContext(typeof(AutorDbContext))]
    partial class AutorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutorsServices.DAL.Entities.AcademicGrade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AutorId")
                        .HasColumnType("uuid");

                    b.Property<string>("CollageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FinishedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("AcademicGrades");
                });

            modelBuilder.Entity("AutorsServices.DAL.Entities.BookAutor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BookAutors");
                });

            modelBuilder.Entity("AutorsServices.DAL.Entities.AcademicGrade", b =>
                {
                    b.HasOne("AutorsServices.DAL.Entities.BookAutor", "Autor")
                        .WithMany("AcademicGrades")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("AutorsServices.DAL.Entities.BookAutor", b =>
                {
                    b.Navigation("AcademicGrades");
                });
#pragma warning restore 612, 618
        }
    }
}
