﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteTemplate.Infra.Data.Persistence;

namespace TesteTemplate.Infra.Data.Migrations
{
    [DbContext(typeof(TesteTemplateContext))]
    partial class TesteTemplateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TesteTemplate.Domain.Entities.ImportacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataImportacao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Importacao");
                });

            modelBuilder.Entity("TesteTemplate.Domain.Entities.PedidoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImportacaoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ImportacaoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("TesteTemplate.Domain.Entities.PedidoModel", b =>
                {
                    b.HasOne("TesteTemplate.Domain.Entities.ImportacaoModel", "Importacao")
                        .WithMany("Pedidos")
                        .HasForeignKey("ImportacaoId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}