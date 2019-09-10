﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VivaldiHiddenLevers.Persistence;

namespace VivaldiHiddenLevers.Persistence.Migrations
{
    [DbContext(typeof(VivaldiHiddenLeversDbContext))]
    [Migration("20190908154934_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VivaldiHiddenLevers.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("AdvisorEmail");

                    b.Property<string>("Email");

                    b.Property<int?>("HiddenLeverId");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("VivaldiHiddenLevers.Domain.Entities.RiskProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("Result")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("RiskProfiles");
                });

            modelBuilder.Entity("VivaldiHiddenLevers.Domain.Entities.StressTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("Message");

                    b.Property<string>("Results")
                        .IsRequired();

                    b.Property<string>("Ticker");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("StressTests");
                });

            modelBuilder.Entity("VivaldiHiddenLevers.Domain.Entities.RiskProfile", b =>
                {
                    b.HasOne("VivaldiHiddenLevers.Domain.Entities.Client", "Client")
                        .WithMany("RiskProfiles")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_RiskProfile_Client")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VivaldiHiddenLevers.Domain.Entities.StressTest", b =>
                {
                    b.HasOne("VivaldiHiddenLevers.Domain.Entities.Client", "Client")
                        .WithMany("StressTests")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_StressTest_Client")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
