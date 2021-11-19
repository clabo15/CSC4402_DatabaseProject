﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestDBProj;

namespace TestDBProj.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211105041303_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TestDBProj.Models.BostonBike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<double>("FpctEnded")
                        .HasColumnType("double precision")
                        .HasColumnName("fpct_ended");

                    b.Property<double>("FpctStarted")
                        .HasColumnType("double precision")
                        .HasColumnName("fpct_started");

                    b.Property<double>("FpctTotal")
                        .HasColumnType("double precision")
                        .HasColumnName("fpct_total");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric")
                        .HasColumnName("latitude");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric")
                        .HasColumnName("longitude");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("StationId")
                        .HasColumnType("integer")
                        .HasColumnName("station_id");

                    b.Property<int>("TripsEnded")
                        .HasColumnType("integer")
                        .HasColumnName("trips_ended");

                    b.Property<int>("TripsStarted")
                        .HasColumnType("integer")
                        .HasColumnName("trips_started");

                    b.Property<int>("TripsTotal")
                        .HasColumnType("integer")
                        .HasColumnName("trips_total");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_bostonbikes");

                    b.ToTable("bostonbikes", "testdb");
                });
#pragma warning restore 612, 618
        }
    }
}
