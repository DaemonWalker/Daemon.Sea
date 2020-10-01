using System;
using System.Collections.Generic;
using System.Text;

namespace Daemon.Sea.Consul
{
    public class ConsulConfig
    {
        public string Address { get; set; }
        public int Port { get; set; } = 8500;
        public string ServiceName { get; set; }
        public string ServiceAddress { get; set; }
        public int ServicePort { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public TimeSpan Interval { get; set; } = TimeSpan.FromSeconds(10);
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(5);
        public TimeSpan FirstCheck { get; set; } = TimeSpan.FromSeconds(5);
        public string Health { get; set; } = "/api/health";
    }
}
