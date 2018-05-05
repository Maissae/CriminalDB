﻿// <auto-generated />
using CriminalDB.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CriminalDB.Migrations
{
    [DbContext(typeof(CriminalContext))]
    partial class CriminalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("CriminalDB.Database.Model.Crime", b =>
                {
                    b.Property<int>("CrimeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Time");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("CrimeID");

                    b.ToTable("Crimes");
                });

            modelBuilder.Entity("CriminalDB.Database.Model.Criminal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("CrimeID");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<double>("Height");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<double>("Weight");

                    b.HasKey("ID");

                    b.HasIndex("CrimeID");

                    b.ToTable("Criminals");
                });

            modelBuilder.Entity("CriminalDB.Database.Model.Victim", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("CrimeID");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<double>("Height");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<double>("Weight");

                    b.HasKey("ID");

                    b.HasIndex("CrimeID");

                    b.ToTable("Victims");
                });

            modelBuilder.Entity("CriminalDB.Database.Model.Criminal", b =>
                {
                    b.HasOne("CriminalDB.Database.Model.Crime")
                        .WithMany("Criminals")
                        .HasForeignKey("CrimeID");
                });

            modelBuilder.Entity("CriminalDB.Database.Model.Victim", b =>
                {
                    b.HasOne("CriminalDB.Database.Model.Crime")
                        .WithMany("Victims")
                        .HasForeignKey("CrimeID");
                });
#pragma warning restore 612, 618
        }
    }
}
