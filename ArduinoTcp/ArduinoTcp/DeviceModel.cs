using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoTcp
{
    class DeviceModel
    {
        public Guid DeviceId { get; set; }
        public Socket DeviceSocket { get; set; }
    }
}
