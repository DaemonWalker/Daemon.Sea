using Daemon.Sea.MSDemo.WarehouseService.Models;
using Daemon.Sea.MSDemo.WarehouseService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daemon.Sea.MSDemo.WarehouseService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemWarehouseController : ControllerBase
    {
        private readonly ItemWarehouseService itemWarehouseService;
        public ItemWarehouseController(ItemWarehouseService itemWarehouseService)
        {
            this.itemWarehouseService = itemWarehouseService;
        }
        public List<ItemWarehouseModel> GetItems(int warehouseId)
        {
            return itemWarehouseService.GetWarehouseItems(warehouseId);
        }
    }
}
