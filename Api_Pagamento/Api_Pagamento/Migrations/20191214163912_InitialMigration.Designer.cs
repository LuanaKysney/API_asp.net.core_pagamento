﻿// <auto-generated />
using System;
using Api_Pagamento.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_Pagamento.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191214163912_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api_Pagamento.Models.AddressClient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("line1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("line2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("neighborhood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postal_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("addressClients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            city = "Vilarejo",
                            country_code = "brasília",
                            line1 = "complemento",
                            neighborhood = "ceilandia",
                            postal_code = "72236800",
                            state = "brasília"
                        });
                });

            modelBuilder.Entity("Api_Pagamento.Models.Bandeiras_cartao_credito", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("American_Express")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banescard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diners")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ELO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hipercard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JCB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mastercard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Visa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("bandeiras_Cartao_Creditos");
                });

            modelBuilder.Entity("Api_Pagamento.Models.CustomerClient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("addressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("taxpayer_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("addressId");

                    b.ToTable("customerClients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            addressId = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            email = "testeApi@gmail.com",
                            first_name = "Naruto Shippuden ",
                            taxpayer_id = "09865425555"
                        });
                });

            modelBuilder.Entity("Api_Pagamento.Models.Json_boleto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("body_instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("customerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("expiration_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("on_behalf_of")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payment_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("customerId");

                    b.ToTable("json_Boletos");
                });

            modelBuilder.Entity("Api_Pagamento.Models.CustomerClient", b =>
                {
                    b.HasOne("Api_Pagamento.Models.AddressClient", "address")
                        .WithMany()
                        .HasForeignKey("addressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api_Pagamento.Models.Json_boleto", b =>
                {
                    b.HasOne("Api_Pagamento.Models.CustomerClient", "customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
