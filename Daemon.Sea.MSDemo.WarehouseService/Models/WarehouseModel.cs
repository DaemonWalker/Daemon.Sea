using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daemon.Sea.MSDemo.WarehouseService.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> KeeperIds { get; set; }
        public string Address { get; set; }
    }
}
