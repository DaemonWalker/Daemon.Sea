using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daemon.Sea.MSDemo.WarehouseService.Models
{
    public class ItemWarehouseModel
    {
        public int ItemId { get; set; }
        public int Inventory { get; set; }
        public int WarehouseId { get; set; }
    }
}
