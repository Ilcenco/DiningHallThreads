using DiningHallThreads.StaticModels;
using KitchenThreads.Models;
using System;

namespace DiningHallThreads.Models
{
    public class Table
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public string Status { get; set; }
        public Order Order { get; set; }
        public Table(string status)
        {
            this.Id = Guid.NewGuid();
            this.Status = status;
            this.Index = Tables.c;
            Tables.c++;
        }
    }
}
