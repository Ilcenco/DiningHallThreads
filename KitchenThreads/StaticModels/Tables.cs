using DiningHallThreads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiningHallThreads.StaticModels
{
    public static class Tables
    {
        public static int c = 0;
        public static Mutex mutex = new Mutex();
        public static List<Table> TableList = new List<Table>()
        {
            new Table("free"),
            new Table("free"),
            new Table("free"),
            new Table("waiting to be served"),
            new Table("waiting to be served"),
            new Table("waiting to be served"),
            new Table("waiting to be served"),
            new Table("waiting to be served"),
            new Table("waiting to be served"),
            new Table("waiting to be served"),
        };

        public static void ChangeTableState()
        {
            while (true)
            {
                var table = Tables.TableList.FirstOrDefault(t => t.Status == "free");
                if (table != null)
                {
                    Thread.Sleep(9000);
                    System.Diagnostics.Debug.WriteLine(table.Index + " changed status to waiting to be served");
                    table.Status = "waiting to be served";
                    Thread.Sleep(9000);


                }

            }
        }


    }
}
