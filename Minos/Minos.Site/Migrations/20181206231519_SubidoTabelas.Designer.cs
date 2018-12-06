﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minos.Site.Models;

namespace Minos.Site.Migrations
{
    [DbContext(typeof(MinosContext))]
    [Migration("20181206231519_SubidoTabelas")]
    partial class SubidoTabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Minos.Site.Models.Pergunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Texto")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("Minos.Site.Models.Periodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFinal");

                    b.Property<DateTime>("DataInicial");

                    b.HasKey("Id");

                    b.ToTable("Periodo");
                });

            modelBuilder.Entity("Minos.Site.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Sobrenome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("Minos.Site.Models.ProfessorTurma", b =>
                {
                    b.Property<int>("ProfessorId");

                    b.Property<int>("TurmaId");

                    b.HasKey("ProfessorId", "TurmaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("ProfessorTurma");
                });

            modelBuilder.Entity("Minos.Site.Models.Questionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PeriodoId");

                    b.Property<int?>("TurmaId");

                    b.HasKey("Id");

                    b.HasIndex("PeriodoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Questionarios");
                });

            modelBuilder.Entity("Minos.Site.Models.QuestionarioPergunta", b =>
                {
                    b.Property<int>("QuestionarioId");

                    b.Property<int>("PerguntaId");

                    b.HasKey("QuestionarioId", "PerguntaId");

                    b.HasIndex("PerguntaId");

                    b.ToTable("QuestionarioPergunta");
                });

            modelBuilder.Entity("Minos.Site.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoTurma")
                        .IsRequired();

                    b.Property<int>("Grau");

                    b.Property<int>("Serie");

                    b.Property<int>("Turno");

                    b.HasKey("Id");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("Minos.Site.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Admin");

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Minos.Site.Models.ProfessorTurma", b =>
                {
                    b.HasOne("Minos.Site.Models.Professor", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Minos.Site.Models.Turma", "Turma")
                        .WithMany("Professores")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Minos.Site.Models.Questionario", b =>
                {
                    b.HasOne("Minos.Site.Models.Periodo", "Periodo")
                        .WithMany()
                        .HasForeignKey("PeriodoId");

                    b.HasOne("Minos.Site.Models.Turma")
                        .WithMany("Questionarios")
                        .HasForeignKey("TurmaId");
                });

            modelBuilder.Entity("Minos.Site.Models.QuestionarioPergunta", b =>
                {
                    b.HasOne("Minos.Site.Models.Pergunta", "Pergunta")
                        .WithMany("Questionario")
                        .HasForeignKey("PerguntaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Minos.Site.Models.Questionario", "Questionario")
                        .WithMany("Perguntas")
                        .HasForeignKey("QuestionarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
