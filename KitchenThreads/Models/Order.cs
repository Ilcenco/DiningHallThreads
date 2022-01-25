using DiningHallThreads.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenThreads.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public Guid WaiterId { get; set; }
        public List<int> ItemList { get; set; }
        public List<Item> ItemsObjectList { get; set; }
        public int Priority { get; set; }
        public double MaxWait { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime DistributedTime { get; set; }
        
        public Order(Guid tableId, Guid waiterId)
        {
            this.Id = Guid.NewGuid();
            this.TableId = tableId;
            this.WaiterId = waiterId;
            this.ItemsObjectList = new List<Item>();
            this.ItemList = GenItems();
            this.Priority = GenPriority();
            this.MaxWait = GenMaxWait();
            this.PickUpTime = DateTime.Now;
        }
        private List<int> GenItems()
        {
            List<int> items = new List<int>();
            var rnd = new Random();
            var itemsLength = rnd.Next(1,5);
            for (int i = 0; i < itemsLength; i++)
            {
                var item = rnd.Next(1, 11);
                items.Add(item);
                ItemsObjectList.Add(Items.ItemList[item-1]);
            }
            return items;
        }

        private int GenPriority()
        {
            var rnd = new Random();
            return rnd.Next(1, 6);
        }

        private double GenMaxWait()
        {
            double max = 0;
            foreach (var item in ItemList)
            {
                var menuItem = Items.ItemList.FirstOrDefault(i => i.Id == item);
                if (menuItem.PreparationTime > max)
                {
                    max = menuItem.PreparationTime;
                }
            }
            max *= 1.3;
            return max;
        }


    }
}
