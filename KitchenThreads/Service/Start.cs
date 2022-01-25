using DiningHallThreads.Models;
using DiningHallThreads.StaticModels;
using KitchenThreads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiningHallThreads.Service
{
    public class Start
    {
        public List<Waiter> Waiters = new List<Waiter>()
        {
            new Waiter("Ion"),
            new Waiter("Nicu"),
            new Waiter("Gigel"),
            new Waiter("Petru"),
        };
        
        public Start()
        {
            for (int i = 0; i < Waiters.Count; i++)
            {
                Thread waiterThread = new Thread( Waiters[i].Work)
                {
                    Name = Waiters[i].Name + "Thread"
                };

                waiterThread.Start();
                System.Diagnostics.Debug.WriteLine(Waiters[i].Name + "Thread" + " started");
            }

            Thread tablesChangeThread = new Thread(Tables.ChangeTableState);
            tablesChangeThread.Start();
        }

        
    }
}
