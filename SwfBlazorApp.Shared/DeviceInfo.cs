using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwfBlazorApp.Shared
{
    public class DeviceInfo
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public bool IsConnected { get; set; }
    }
}
