﻿// <auto-generated />
using HotelListening.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelListening.API.Migrations
{
    [DbContext(typeof(HotelListListingDbContext))]
    partial class HotelListListingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelListening.API.Data.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("T_Country", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Jamaica",
                            ShortName = "JM"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Jamaica",
                            ShortName = "JM"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Cayman Island",
                            ShortName = "CI"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Taiwan",
                            ShortName = "TW"
                        });
                });

            modelBuilder.Entity("HotelListening.API.Data.Hotel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("T_Hotel", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "Negril",
                            CountryId = 1L,
                            Name = "Sandals Resort and Spa",
                            Rating = 4.5
                        },
                        new
                        {
                            Id = 2L,
                            Address = "George Town",
                            CountryId = 3L,
                            Name = "Comfort Suites",
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            Id = 3L,
                            Address = "Nassua",
                            CountryId = 2L,
                            Name = "Grand Palldium",
                            Rating = 4.0
                        },
                        new
                        {
                            Id = 4L,
                            Address = "Taichung",
                            CountryId = 4L,
                            Name = "Splendor Hotel-Taichung",
                            Rating = 4.2000000000000002
                        });
                });

            modelBuilder.Entity("HotelListening.API.Data.Hotel", b =>
                {
                    b.HasOne("HotelListening.API.Data.Country", "Country")
                        .WithMany("Hotels")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HotelListening.API.Data.Country", b =>
                {
                    b.Navigation("Hotels");
                });
#pragma warning restore 612, 618
        }
    }
}
