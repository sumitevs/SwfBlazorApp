using SwfBlazorApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace SwfCore.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<DeviceInfo> Devices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<DeviceInfo>().HasData(new DeviceInfo
            {
                Id = 1,
                DeviceName = "device01",
                DeviceType = "type001",
                IsConnected = true
            });
            modelBuilder.Entity<DeviceInfo>().HasData(new DeviceInfo
            {
                Id=2,
                DeviceName = "device02",
                DeviceType = "type002",
                IsConnected = true
            });
            modelBuilder.Entity<DeviceInfo>().HasData(new DeviceInfo
            {
                Id =3,
                DeviceName = "device03",
                DeviceType = "type003",
                IsConnected = false
            });
            modelBuilder.Entity<DeviceInfo>().HasData(new DeviceInfo
            {
                Id =4,
                DeviceName = "device04",
                DeviceType = "type001",
                IsConnected = true
            });
            modelBuilder.Entity<DeviceInfo>().HasData(new DeviceInfo
            {
                Id =5,
                DeviceName = "device05",
                DeviceType = "type002",
                IsConnected = false
            });
        }
    }
}
