﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TalentManagement.Infrastructure;

namespace TalentManagement.Infrastructure.Migrations
{
    [DbContext(typeof(TalentManagementContext))]
    partial class TalentManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TalentManagement.Domain.Entities.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AccountType");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.Knowledge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Knowledge");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountNumber");

                    b.Property<int?>("AccountTypeId");

                    b.Property<string>("Agency");

                    b.Property<int?>("BankId");

                    b.Property<int?>("CityId");

                    b.Property<string>("Cpf");

                    b.Property<string>("Email");

                    b.Property<string>("LinkTest");

                    b.Property<string>("LinkedIn");

                    b.Property<string>("Name");

                    b.Property<string>("OtherKnowledge");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Portfolio");

                    b.Property<int?>("ProfileId");

                    b.Property<decimal?>("Salary");

                    b.Property<string>("Skype");

                    b.Property<int?>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("BankId");

                    b.HasIndex("CityId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("StateId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.PersonKnowledge", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<int>("KnowledgeId");

                    b.Property<int>("Level");

                    b.HasKey("PersonId", "KnowledgeId");

                    b.HasAlternateKey("KnowledgeId", "PersonId");

                    b.ToTable("PersonKnowledge");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.PersonTimeWork", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<int>("TimeWorkId");

                    b.HasKey("PersonId", "TimeWorkId");

                    b.HasIndex("TimeWorkId");

                    b.ToTable("PersonTimeWork");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.PersonWillingness", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<int>("WillingnessId");

                    b.HasKey("PersonId", "WillingnessId");

                    b.HasIndex("WillingnessId");

                    b.ToTable("PersonWillingness");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Initials");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.TimeWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("TimeWork");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.Willingness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Willingness");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.City", b =>
                {
                    b.HasOne("TalentManagement.Domain.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.Person", b =>
                {
                    b.HasOne("TalentManagement.Domain.Entities.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId");

                    b.HasOne("TalentManagement.Domain.Entities.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("TalentManagement.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("TalentManagement.Domain.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId");

                    b.HasOne("TalentManagement.Domain.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.PersonKnowledge", b =>
                {
                    b.HasOne("TalentManagement.Domain.Entities.Knowledge")
                        .WithMany("PersonKnowledges")
                        .HasForeignKey("KnowledgeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TalentManagement.Domain.Entities.Person")
                        .WithMany("PersonKnowledges")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.PersonTimeWork", b =>
                {
                    b.HasOne("TalentManagement.Domain.Entities.Person")
                        .WithMany("PersonTimeWorks")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TalentManagement.Domain.Entities.TimeWork")
                        .WithMany("PersonTimeWorks")
                        .HasForeignKey("TimeWorkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TalentManagement.Domain.Entities.PersonWillingness", b =>
                {
                    b.HasOne("TalentManagement.Domain.Entities.Person")
                        .WithMany("PersonWillingnesss")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TalentManagement.Domain.Entities.Willingness")
                        .WithMany("PersonWillingnesss")
                        .HasForeignKey("WillingnessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
