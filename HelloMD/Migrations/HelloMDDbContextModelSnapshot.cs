﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NameAPIProxyService.Data;

#nullable disable

namespace HelloMD.Migrations
{
    [DbContext(typeof(HelloMDDbContext))]
    partial class HelloMDDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HelloMD.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReceiverID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ReplayFor")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WriterID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("MessageID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("ReplayFor");

                    b.HasIndex("WriterID");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageID = 1,
                            Body = "Hi Bro",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReceiverID = 2,
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WriterID = 1
                        },
                        new
                        {
                            MessageID = 2,
                            Body = "How Are you ?",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReceiverID = 1,
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WriterID = 2
                        },
                        new
                        {
                            MessageID = 3,
                            Body = "I am God",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReceiverID = 2,
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WriterID = 1
                        },
                        new
                        {
                            MessageID = 4,
                            Body = "Any News ?",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReceiverID = 1,
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WriterID = 2
                        });
                });

            modelBuilder.Entity("HelloMD.models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastSeen")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Active = true,
                            CreatedAt = new DateTime(2023, 1, 23, 4, 46, 4, 132, DateTimeKind.Local).AddTicks(340),
                            FirstName = "Zerihun",
                            LastName = "H.",
                            LastSeen = new DateTime(2023, 1, 23, 4, 46, 4, 132, DateTimeKind.Local).AddTicks(255),
                            Password = "test",
                            Status = 0,
                            UpdatedAt = new DateTime(2023, 1, 23, 4, 46, 4, 132, DateTimeKind.Local).AddTicks(344),
                            Username = "zeru"
                        },
                        new
                        {
                            UserID = 2,
                            Active = true,
                            CreatedAt = new DateTime(2023, 1, 23, 4, 46, 4, 132, DateTimeKind.Local).AddTicks(356),
                            FirstName = "lonel",
                            LastName = "Prime",
                            LastSeen = new DateTime(2023, 1, 23, 4, 46, 4, 132, DateTimeKind.Local).AddTicks(352),
                            Password = "test",
                            Status = 0,
                            UpdatedAt = new DateTime(2023, 1, 23, 4, 46, 4, 132, DateTimeKind.Local).AddTicks(359),
                            Username = "lonel"
                        });
                });

            modelBuilder.Entity("HelloMD.Models.Message", b =>
                {
                    b.HasOne("HelloMD.models.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelloMD.Models.Message", "ReplMsg")
                        .WithMany()
                        .HasForeignKey("ReplayFor");

                    b.HasOne("HelloMD.models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("WriterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("ReplMsg");

                    b.Navigation("Sender");
                });
#pragma warning restore 612, 618
        }
    }
}
