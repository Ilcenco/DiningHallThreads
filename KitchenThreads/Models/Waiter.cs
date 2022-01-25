using DiningHallThreads.StaticModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace KitchenThreads.Models
{

    public class Waiter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Waiter(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public void Work()
        {
            var rnd = new Random();
            while (true)
            {
                Thread.Sleep(rnd.Next(500));

                Tables.mutex.WaitOne();
                var table = Tables.TableList.FirstOrDefault(t => t.Status == "waiting to be served");
                if (table != null)
                {
                    System.Diagnostics.Debug.WriteLine(Name + " entered table " + table.Index);
                    Thread.Sleep(rnd.Next(500, 3000));

                    Order order = new Order(table.Id, Id);
                    System.Diagnostics.Debug.WriteLine(Name + " took order " + JsonConvert.SerializeObject(order) + " from table " + table.Index);
                    table.Order = order;
                    PushOrder(order);

                    table.Status = "waiting for order";
                    System.Diagnostics.Debug.WriteLine(Name + " is leaving table " + table.Index);
                }
                Tables.mutex.ReleaseMutex();

                lock (ReadyOrders.readyOrdersList)
                {
                    if (ReadyOrders.readyOrdersList.Count != 0)
                    {
                        if (ReadyOrders.readyOrdersList.Any(o => o.WaiterId.Equals(Id)))
                        {
                            var order = ReadyOrders.readyOrdersList.FirstOrDefault(o => o.WaiterId.Equals(Id));
                            ReadyOrders.readyOrdersList.Remove(order);
                            //System.Diagnostics.Debug.WriteLine(Name + " distributed order " + order.Id + " to " + order.TableId);
                            var orderRating = "";
                            var preparedTime = (DateTime.Now - order.PickUpTime).TotalMilliseconds;

                            if (order.MaxWait * 1400 > preparedTime)
                            {
                                orderRating = "*";
                            }
                            else if (order.MaxWait * 1300 > preparedTime)
                            {
                                orderRating = "**";
                            }
                            else if (order.MaxWait * 1200 > preparedTime)
                            {
                                orderRating = "***";
                            }
                            else if (order.MaxWait * 1100 > preparedTime)
                            {
                                orderRating = "****";
                            }
                            else if (order.MaxWait * 1000 > preparedTime)
                            {
                                orderRating = "*****";
                            }
                            else
                            {
                                orderRating = " 0 ";
                            }
                            System.Diagnostics.Debug.WriteLine(Name + " distributed order " + order.Id + " to " + order.TableId + " with rating: " + orderRating + " prepare time: " + preparedTime);
                            lock (Tables.TableList)
                            {
                                var tableFree = Tables.TableList.FirstOrDefault(t => t.Id == order.TableId);
                                if (tableFree != null)
                                {
                                    tableFree.Order = null;
                                    tableFree.Status = "waiting to be served";
                                }
                            }
                        }
                    }
                }

            }
        }
        public void PushOrder( Order order)
        {
            using (var client = new HttpClient())
            {
                var postTask = client.PostAsJsonAsync<Order>("https://localhost:44336/api/postOrder", order);
                postTask.Wait();
                var result = postTask.Result;
            }
            
        }

    }
}
