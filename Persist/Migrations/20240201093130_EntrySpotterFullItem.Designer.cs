﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persist;

#nullable disable

namespace Persist.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240201093130_EntrySpotterFullItem")]
    partial class EntrySpotterFullItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Persist.Entities.BookEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Persist.Entities.EntryEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("Persist.Entities.EntrySpotterEntity", b =>
                {
                    b.Property<string>("EntryId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SpotterId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("EntryId", "SpotterId");

                    b.HasIndex("SpotterId");

                    b.ToTable("EntrySpotter");
                });

            modelBuilder.Entity("Persist.Entities.SpotterEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Spotter");
                });

            modelBuilder.Entity("Persist.Entities.EntrySpotterEntity", b =>
                {
                    b.HasOne("Persist.Entities.EntryEntity", "Entry")
                        .WithMany()
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persist.Entities.SpotterEntity", "Spotter")
                        .WithMany()
                        .HasForeignKey("SpotterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entry");

                    b.Navigation("Spotter");
                });
#pragma warning restore 612, 618
        }
    }
}
