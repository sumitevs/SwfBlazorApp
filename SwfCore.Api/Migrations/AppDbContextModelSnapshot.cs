// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwfCore.Api.Models;

#nullable disable

namespace SwfCore.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SwfBlazorApp.Shared.DeviceInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConnected")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeviceName = "device01",
                            DeviceType = "type001",
                            IsConnected = true
                        },
                        new
                        {
                            Id = 2,
                            DeviceName = "device02",
                            DeviceType = "type002",
                            IsConnected = true
                        },
                        new
                        {
                            Id = 3,
                            DeviceName = "device03",
                            DeviceType = "type003",
                            IsConnected = false
                        },
                        new
                        {
                            Id = 4,
                            DeviceName = "device04",
                            DeviceType = "type001",
                            IsConnected = true
                        },
                        new
                        {
                            Id = 5,
                            DeviceName = "device05",
                            DeviceType = "type002",
                            IsConnected = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
