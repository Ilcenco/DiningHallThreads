using DiningHallThreads.StaticModels;
using KitchenThreads.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiningHallThreads.Controllers
{
    [Route("api")]
    public class DistributionController : Controller
    {
        [Route("distributeOrder")]
        [HttpPost]
        public IActionResult Index([FromBody] Order order)
        {
            lock (ReadyOrders.readyOrdersList)
            {
                ReadyOrders.readyOrdersList.Add(order);
                ReadyOrders.c++;
            }
            return View();
        }
    }
}
