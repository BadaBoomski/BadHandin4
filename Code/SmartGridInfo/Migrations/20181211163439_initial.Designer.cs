﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGridInfo.Models;

namespace SmartGridInfo.Migrations
{
    [DbContext(typeof(SmartGridDbContext))]
    [Migration("20181211163439_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartGridInfo.Models.SmartGrid", b =>
                {
                    b.Property<int>("SmartGridID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SmartGridInfo");

                    b.Property<string>("SmartGridRegistration");

                    b.Property<int>("TotalProsumersCount");

                    b.HasKey("SmartGridID");

                    b.ToTable("SmartGrids");
                });

            modelBuilder.Entity("SmartGridInfo.Models.SmartGridProsumer", b =>
                {
                    b.Property<int>("SmartGridProsumerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InstallationsID");

                    b.Property<int>("SmartGridID");

                    b.HasKey("SmartGridProsumerID");

                    b.HasIndex("SmartGridID");

                    b.ToTable("SmartGridProsumers");
                });

            modelBuilder.Entity("SmartGridInfo.Models.SmartGridProsumer", b =>
                {
                    b.HasOne("SmartGridInfo.Models.SmartGrid", "SmartGrid")
                        .WithMany()
                        .HasForeignKey("SmartGridID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
