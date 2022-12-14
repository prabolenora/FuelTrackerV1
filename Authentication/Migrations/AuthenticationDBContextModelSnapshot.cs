// <auto-generated />
using System;
using Authentication.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Authentication.Migrations
{
    [DbContext(typeof(AuthenticationDBContext))]
    partial class AuthenticationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Authentication.DataAccess.Authentications", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("registeredDate")
                        .HasColumnType("text");

                    b.Property<string>("vehicleRegistrationNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authentication", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
