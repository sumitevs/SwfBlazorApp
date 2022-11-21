using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwfBlazorApp.Shared
{
    public class DeviceInfo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Too long buddy")]
        public string DeviceName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Too long buddy")]
        public string DeviceType { get; set; }
        public bool IsConnected { get; set; }
        [NotMapped]
        public byte[] ImageContent { get; set; }
        public string ImageName { get; set; }
    }
}
