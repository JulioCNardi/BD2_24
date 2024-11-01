﻿// <auto-generated />
using System;
using Competicao.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Prototipo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241101230442_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Competicao.Models.Atleta", b =>
                {
                    b.Property<int>("AtletaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AtletaId"));

                    b.Property<int>("EquipeId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AtletaId");

                    b.HasIndex("EquipeId");

                    b.ToTable("Atleta");
                });

            modelBuilder.Entity("Competicao.Models.Competicao", b =>
                {
                    b.Property<int>("CompeticaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompeticaoId"));

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModalidadeId")
                        .HasColumnType("int");

                    b.Property<int?>("ModalidadeId1")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TipoTorneio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompeticaoId");

                    b.HasIndex("ModalidadeId");

                    b.HasIndex("ModalidadeId1");

                    b.ToTable("Competicoes");
                });

            modelBuilder.Entity("Competicao.Models.Equipe", b =>
                {
                    b.Property<int>("EquipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipeId"));

                    b.Property<int>("CompeticaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EquipeId");

                    b.HasIndex("CompeticaoId");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("Competicao.Models.Modalidade", b =>
                {
                    b.Property<int>("ModalidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModalidadeId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ModalidadeId");

                    b.ToTable("Modalidades");
                });

            modelBuilder.Entity("Competicao.Models.Atleta", b =>
                {
                    b.HasOne("Competicao.Models.Equipe", "Equipe")
                        .WithMany("Atletas")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("Competicao.Models.Competicao", b =>
                {
                    b.HasOne("Competicao.Models.Modalidade", "Modalidade")
                        .WithMany()
                        .HasForeignKey("ModalidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Competicao.Models.Modalidade", null)
                        .WithMany("Competicoes")
                        .HasForeignKey("ModalidadeId1");

                    b.Navigation("Modalidade");
                });

            modelBuilder.Entity("Competicao.Models.Equipe", b =>
                {
                    b.HasOne("Competicao.Models.Competicao", "Competicao")
                        .WithMany("Equipes")
                        .HasForeignKey("CompeticaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competicao");
                });

            modelBuilder.Entity("Competicao.Models.Competicao", b =>
                {
                    b.Navigation("Equipes");
                });

            modelBuilder.Entity("Competicao.Models.Equipe", b =>
                {
                    b.Navigation("Atletas");
                });

            modelBuilder.Entity("Competicao.Models.Modalidade", b =>
                {
                    b.Navigation("Competicoes");
                });
#pragma warning restore 612, 618
        }
    }
}
