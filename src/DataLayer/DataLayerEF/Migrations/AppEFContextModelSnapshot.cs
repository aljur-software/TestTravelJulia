﻿// <auto-generated />
using System;
using DataLayerEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataLayerEF.Migrations
{
    [DbContext(typeof(AppEFContext))]
    partial class AppEFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AgencyAgent", b =>
                {
                    b.Property<int>("AgenciesId")
                        .HasColumnType("integer");

                    b.Property<int>("AgentsId")
                        .HasColumnType("integer");

                    b.HasKey("AgenciesId", "AgentsId");

                    b.HasIndex("AgentsId");

                    b.ToTable("AgencyAgent");
                });

            modelBuilder.Entity("DataLayerEF.Entities.Agency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Agency");
                });

            modelBuilder.Entity("DataLayerEF.Entities.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("character varying(65)");

                    b.HasKey("Id");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("DataLayerEF.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("AgencyId")
                        .HasColumnType("integer");

                    b.Property<int?>("AgentId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("character varying(65)");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("AgentId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("AgencyAgent", b =>
                {
                    b.HasOne("DataLayerEF.Entities.Agency", null)
                        .WithMany()
                        .HasForeignKey("AgenciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayerEF.Entities.Agent", null)
                        .WithMany()
                        .HasForeignKey("AgentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayerEF.Entities.Contact", b =>
                {
                    b.HasOne("DataLayerEF.Entities.Agency", null)
                        .WithMany("Contacts")
                        .HasForeignKey("AgencyId");

                    b.HasOne("DataLayerEF.Entities.Agent", null)
                        .WithMany("Contacts")
                        .HasForeignKey("AgentId");
                });

            modelBuilder.Entity("DataLayerEF.Entities.Agency", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("DataLayerEF.Entities.Agent", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
