using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daemon.Sea.Consul
{
    public static class Extenssions
    {
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime, IConfiguration configuration)
        {
            var config = configuration.GetSection("consul").Get<ConsulConfig>();
            var consulAddress = new Uri($"http://{config.Address}:{config.Port}");
            var client = new ConsulClient(p => p.Address = consulAddress);
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = config.FirstCheck,
                Interval = config.Interval,
                HTTP = $"http://{config.ServiceAddress}:{config.ServicePort}/{config.Health}",
                Timeout = config.Timeout
            };
            Console.WriteLine($"http://{config.Address}:{config.Port}/{config.Health}");
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = config.Id,
                Name = config.ServiceName,
                Address = config.ServiceAddress,
                Port = config.ServicePort,
                Tags = new[] { $"urlprefix-/{config.ServiceName}" }
            };

            client.Agent.ServiceRegister(registration).Wait();
            lifetime.ApplicationStopping.Register(() =>
            {
                client.Agent.ServiceDeregister(config.Id).Wait();
            });
            return app;
        }
    }
}
