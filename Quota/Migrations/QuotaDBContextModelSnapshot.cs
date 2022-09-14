﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Quota.DataAccess;

#nullable disable

namespace Quota.Migrations
{
    [DbContext(typeof(QuotaDBContext))]
    partial class QuotaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Quota.DataAccess.Quotas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double?>("maxQuota")
                        .HasColumnType("double precision");

                    b.Property<double?>("remainingQuota")
                        .HasColumnType("double precision");

                    b.Property<string>("vehicleRegistrationNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Quotas", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
