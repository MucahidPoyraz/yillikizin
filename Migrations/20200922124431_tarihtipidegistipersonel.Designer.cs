﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YillikIzin.Models.Context;

namespace YillikIzin.Migrations
{
    [DbContext(typeof(IzinContext))]
    [Migration("20200922124431_tarihtipidegistipersonel")]
    partial class tarihtipidegistipersonel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YillikIzin.Models.Departman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad");

                    b.HasKey("Id");

                    b.ToTable("Departmanlar");
                });

            modelBuilder.Entity("YillikIzin.Models.Personel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdSoyad");

                    b.Property<bool>("Cinsiyet");

                    b.Property<int>("DepartmanId");

                    b.Property<string>("Email");

                    b.Property<DateTime>("Giristarih")
                        .HasColumnType("date");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("DepartmanId");

                    b.ToTable("Personeller");
                });

            modelBuilder.Entity("YillikIzin.Models.Personel", b =>
                {
                    b.HasOne("YillikIzin.Models.Departman", "Departman")
                        .WithMany("Personeller")
                        .HasForeignKey("DepartmanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
