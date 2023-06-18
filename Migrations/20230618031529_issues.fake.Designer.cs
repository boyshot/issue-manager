﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebIssueManagementApp.Data;

#nullable disable

namespace WebIssueManagementApp.Migrations
{
    [DbContext(typeof(ManagementIssueContext))]
    [Migration("20230618031529_issues.fake")]
    partial class issuesfake
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebIssueManagementApp.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FileName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdIssue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdIssue");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("WebIssueManagementApp.Models.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abstract")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DataBase")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DateBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Server")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("UrlIssue")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Issues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abstract = "Abstract 0",
                            DataBase = "DataBase 0",
                            DateBegin = new DateTime(2023, 7, 18, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3607),
                            IdUser = 1,
                            Server = "Server 0",
                            Text = "Text 0",
                            UrlIssue = "UrlIssue 0"
                        },
                        new
                        {
                            Id = 2,
                            Abstract = "Abstract 1",
                            DataBase = "DataBase 1",
                            DateBegin = new DateTime(2023, 7, 19, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3700),
                            IdUser = 1,
                            Server = "Server 1",
                            Text = "Text 1",
                            UrlIssue = "UrlIssue 1"
                        },
                        new
                        {
                            Id = 3,
                            Abstract = "Abstract 2",
                            DataBase = "DataBase 2",
                            DateBegin = new DateTime(2023, 7, 20, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3706),
                            IdUser = 1,
                            Server = "Server 2",
                            Text = "Text 2",
                            UrlIssue = "UrlIssue 2"
                        },
                        new
                        {
                            Id = 4,
                            Abstract = "Abstract 3",
                            DataBase = "DataBase 3",
                            DateBegin = new DateTime(2023, 7, 21, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3710),
                            IdUser = 1,
                            Server = "Server 3",
                            Text = "Text 3",
                            UrlIssue = "UrlIssue 3"
                        },
                        new
                        {
                            Id = 5,
                            Abstract = "Abstract 4",
                            DataBase = "DataBase 4",
                            DateBegin = new DateTime(2023, 7, 22, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3714),
                            IdUser = 1,
                            Server = "Server 4",
                            Text = "Text 4",
                            UrlIssue = "UrlIssue 4"
                        },
                        new
                        {
                            Id = 6,
                            Abstract = "Abstract 5",
                            DataBase = "DataBase 5",
                            DateBegin = new DateTime(2023, 7, 23, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3722),
                            IdUser = 1,
                            Server = "Server 5",
                            Text = "Text 5",
                            UrlIssue = "UrlIssue 5"
                        },
                        new
                        {
                            Id = 7,
                            Abstract = "Abstract 6",
                            DataBase = "DataBase 6",
                            DateBegin = new DateTime(2023, 7, 24, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3726),
                            IdUser = 1,
                            Server = "Server 6",
                            Text = "Text 6",
                            UrlIssue = "UrlIssue 6"
                        },
                        new
                        {
                            Id = 8,
                            Abstract = "Abstract 7",
                            DataBase = "DataBase 7",
                            DateBegin = new DateTime(2023, 7, 25, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3730),
                            IdUser = 1,
                            Server = "Server 7",
                            Text = "Text 7",
                            UrlIssue = "UrlIssue 7"
                        },
                        new
                        {
                            Id = 9,
                            Abstract = "Abstract 8",
                            DataBase = "DataBase 8",
                            DateBegin = new DateTime(2023, 7, 26, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3734),
                            IdUser = 1,
                            Server = "Server 8",
                            Text = "Text 8",
                            UrlIssue = "UrlIssue 8"
                        },
                        new
                        {
                            Id = 10,
                            Abstract = "Abstract 9",
                            DataBase = "DataBase 9",
                            DateBegin = new DateTime(2023, 7, 27, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3739),
                            IdUser = 1,
                            Server = "Server 9",
                            Text = "Text 9",
                            UrlIssue = "UrlIssue 9"
                        },
                        new
                        {
                            Id = 11,
                            Abstract = "Abstract 10",
                            DataBase = "DataBase 10",
                            DateBegin = new DateTime(2023, 7, 28, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3744),
                            IdUser = 1,
                            Server = "Server 10",
                            Text = "Text 10",
                            UrlIssue = "UrlIssue 10"
                        },
                        new
                        {
                            Id = 12,
                            Abstract = "Abstract 11",
                            DataBase = "DataBase 11",
                            DateBegin = new DateTime(2023, 7, 29, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3749),
                            IdUser = 1,
                            Server = "Server 11",
                            Text = "Text 11",
                            UrlIssue = "UrlIssue 11"
                        },
                        new
                        {
                            Id = 13,
                            Abstract = "Abstract 12",
                            DataBase = "DataBase 12",
                            DateBegin = new DateTime(2023, 7, 30, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3753),
                            IdUser = 1,
                            Server = "Server 12",
                            Text = "Text 12",
                            UrlIssue = "UrlIssue 12"
                        },
                        new
                        {
                            Id = 14,
                            Abstract = "Abstract 13",
                            DataBase = "DataBase 13",
                            DateBegin = new DateTime(2023, 7, 31, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3757),
                            IdUser = 1,
                            Server = "Server 13",
                            Text = "Text 13",
                            UrlIssue = "UrlIssue 13"
                        },
                        new
                        {
                            Id = 15,
                            Abstract = "Abstract 14",
                            DataBase = "DataBase 14",
                            DateBegin = new DateTime(2023, 8, 1, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3761),
                            IdUser = 1,
                            Server = "Server 14",
                            Text = "Text 14",
                            UrlIssue = "UrlIssue 14"
                        },
                        new
                        {
                            Id = 16,
                            Abstract = "Abstract 15",
                            DataBase = "DataBase 15",
                            DateBegin = new DateTime(2023, 8, 2, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3766),
                            IdUser = 1,
                            Server = "Server 15",
                            Text = "Text 15",
                            UrlIssue = "UrlIssue 15"
                        },
                        new
                        {
                            Id = 17,
                            Abstract = "Abstract 16",
                            DataBase = "DataBase 16",
                            DateBegin = new DateTime(2023, 8, 3, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3770),
                            IdUser = 1,
                            Server = "Server 16",
                            Text = "Text 16",
                            UrlIssue = "UrlIssue 16"
                        },
                        new
                        {
                            Id = 18,
                            Abstract = "Abstract 17",
                            DataBase = "DataBase 17",
                            DateBegin = new DateTime(2023, 8, 4, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3776),
                            IdUser = 1,
                            Server = "Server 17",
                            Text = "Text 17",
                            UrlIssue = "UrlIssue 17"
                        },
                        new
                        {
                            Id = 19,
                            Abstract = "Abstract 18",
                            DataBase = "DataBase 18",
                            DateBegin = new DateTime(2023, 8, 5, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3780),
                            IdUser = 1,
                            Server = "Server 18",
                            Text = "Text 18",
                            UrlIssue = "UrlIssue 18"
                        },
                        new
                        {
                            Id = 20,
                            Abstract = "Abstract 19",
                            DataBase = "DataBase 19",
                            DateBegin = new DateTime(2023, 8, 6, 0, 15, 28, 977, DateTimeKind.Local).AddTicks(3785),
                            IdUser = 1,
                            Server = "Server 19",
                            Text = "Text 19",
                            UrlIssue = "UrlIssue 19"
                        });
                });

            modelBuilder.Entity("WebIssueManagementApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@issuemanager.com",
                            Name = "admin",
                            Password = "teste@123"
                        });
                });

            modelBuilder.Entity("WebIssueManagementApp.Models.Attachment", b =>
                {
                    b.HasOne("WebIssueManagementApp.Models.Issue", null)
                        .WithMany("ListAttachment")
                        .HasForeignKey("IdIssue")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebIssueManagementApp.Models.Issue", b =>
                {
                    b.HasOne("WebIssueManagementApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebIssueManagementApp.Models.Issue", b =>
                {
                    b.Navigation("ListAttachment");
                });
#pragma warning restore 612, 618
        }
    }
}
