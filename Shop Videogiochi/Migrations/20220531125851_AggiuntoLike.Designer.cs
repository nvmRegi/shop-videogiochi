﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop_Videogiochi.Data;

#nullable disable

namespace Shop_Videogiochi.Migrations
{
    [DbContext(typeof(VideogameShopContext))]
    [Migration("20220531125851_AggiuntoLike")]
    partial class AggiuntoLike
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shop_Videogiochi.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Shop_Videogiochi.Models.Ordine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantità")
                        .HasColumnType("int");

                    b.Property<int>("VideogiocoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("VideogiocoId");

                    b.ToTable("Ordini");
                });

            modelBuilder.Entity("Shop_Videogiochi.Models.OrdineFornitore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeFornitore")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantità")
                        .HasColumnType("int");

                    b.Property<int>("VideogiocoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("VideogiocoId");

                    b.ToTable("OrdiniFornitore");
                });

            modelBuilder.Entity("Shop_Videogiochi.Models.Videogioco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Like")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Videogiochi");
                });

            modelBuilder.Entity("Shop_Videogiochi.Models.Ordine", b =>
                {
                    b.HasOne("Shop_Videogiochi.Models.Videogioco", "Videogioco")
                        .WithMany("Ordini")
                        .HasForeignKey("VideogiocoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Videogioco");
                });

            modelBuilder.Entity("Shop_Videogiochi.Models.OrdineFornitore", b =>
                {
                    b.HasOne("Shop_Videogiochi.Models.Videogioco", "Videogioco")
                        .WithMany("OrdiniFornitore")
                        .HasForeignKey("VideogiocoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Videogioco");
                });

            modelBuilder.Entity("Shop_Videogiochi.Models.Videogioco", b =>
                {
                    b.HasOne("Shop_Videogiochi.Models.Categoria", "Categoria")
                        .WithMany("Videogiochi")
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Shop_Videogiochi.Models.Categoria", b =>
                {
                    b.Navigation("Videogiochi");
                });

            modelBuilder.Entity("Shop_Videogiochi.Models.Videogioco", b =>
                {
                    b.Navigation("Ordini");

                    b.Navigation("OrdiniFornitore");
                });
#pragma warning restore 612, 618
        }
    }
}
