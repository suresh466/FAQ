﻿// <auto-generated />
using FAQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FAQ.Migrations
{
    [DbContext(typeof(FaqDbContext))]
    [Migration("20240611201143_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FAQ.Models.Category", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Name = "General"
                        },
                        new
                        {
                            Name = "Account"
                        },
                        new
                        {
                            Name = "Shipping"
                        });
                });

            modelBuilder.Entity("FAQ.Models.FAQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TopicId");

                    b.ToTable("FAQs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "Contoso University is a sample application that...",
                            CategoryId = "General",
                            Question = "What is Contoso University?",
                            TopicId = "Getting Started"
                        });
                });

            modelBuilder.Entity("FAQ.Models.Topic", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Name = "Getting Started"
                        },
                        new
                        {
                            Name = "Orders"
                        },
                        new
                        {
                            Name = "Customer Service"
                        });
                });

            modelBuilder.Entity("FAQ.Models.FAQ", b =>
                {
                    b.HasOne("FAQ.Models.Category", "Category")
                        .WithMany("FAQs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FAQ.Models.Topic", "Topic")
                        .WithMany("FAQs")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("FAQ.Models.Category", b =>
                {
                    b.Navigation("FAQs");
                });

            modelBuilder.Entity("FAQ.Models.Topic", b =>
                {
                    b.Navigation("FAQs");
                });
#pragma warning restore 612, 618
        }
    }
}
