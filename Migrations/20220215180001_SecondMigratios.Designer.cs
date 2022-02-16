﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Web.Site.GerenciadorCartao.Database;

namespace Web.Site.GerenciadorCartao.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220215180001_SecondMigratios")]
    partial class SecondMigratios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Web.Site.GerenciadorCartao.Models.Cartao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<double>("Limite")
                        .HasColumnType("double precision");

                    b.Property<string>("NomeBanco")
                        .HasColumnType("text");

                    b.Property<string>("NumeroCartao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("Web.Site.GerenciadorCartao.Models.Gasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("CartaoId")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.ToTable("Gastos");
                });

            modelBuilder.Entity("Web.Site.GerenciadorCartao.Models.Gasto", b =>
                {
                    b.HasOne("Web.Site.GerenciadorCartao.Models.Cartao", "Cartao")
                        .WithMany("Gastos")
                        .HasForeignKey("CartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartao");
                });

            modelBuilder.Entity("Web.Site.GerenciadorCartao.Models.Cartao", b =>
                {
                    b.Navigation("Gastos");
                });
#pragma warning restore 612, 618
        }
    }
}
