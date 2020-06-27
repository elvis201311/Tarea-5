﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prestamo_con_Detalla.DAL;

namespace Prestamo_con_Detalla.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200627200430_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("Prestamo_con_Detalla.Entidades.MorasDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdArticulo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("IdArticulo");

                    b.ToTable("MorasDetalle");
                });

            modelBuilder.Entity("Prestamo_con_Detalla.Entidades.Prestamos", b =>
                {
                    b.Property<int>("MoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("total")
                        .HasColumnType("INTEGER");

                    b.HasKey("MoraId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Prestamo_con_Detalla.Entidades.MorasDetalle", b =>
                {
                    b.HasOne("Prestamo_con_Detalla.Entidades.Prestamos", null)
                        .WithMany("Detalle")
                        .HasForeignKey("IdArticulo");
                });
#pragma warning restore 612, 618
        }
    }
}