using KitchenThreads.Models;
using System.Collections.Generic;

namespace DiningHallThreads.Service
{
    public static class Items
    {
        public static List<Item> ItemList = new List<Item>()
        {
            new Item(){
                Id = 1,
                Name= "pizza",
                PreparationTime = 20,
                Complexity = 2,
                CookingApparatus = "oven"
            },
            new Item(){
                Id = 2,
                Name= "salad",
                PreparationTime = 10,
                Complexity = 1,
                CookingApparatus = null
            },
            new Item(){
                Id = 3,
                Name= "zeama",
                PreparationTime = 7,
                Complexity = 1,
                CookingApparatus = "stove"
            },
            new Item(){
                Id = 4,
                Name= "Scallop sashimi with Meyer Lemon Confit",
                PreparationTime = 32,
                Complexity = 3,
                CookingApparatus = null
            },
            new Item(){
                Id = 5,
                Name= "Island duck with mulberry mustard",
                PreparationTime = 32,
                Complexity = 3,
                CookingApparatus = "oven"
            },
            new Item(){
                Id = 6,
                Name= "waffles",
                PreparationTime = 10,
                Complexity = 1,
                CookingApparatus = "stove"
            },
            new Item(){
                Id = 7,
                Name= "Aubergine",
                PreparationTime = 20,
                Complexity = 2,
                CookingApparatus = null
            },
            new Item(){
                Id = 8,
                Name= "Lasagna",
                PreparationTime = 30,
                Complexity = 2,
                CookingApparatus = "oven"
            },
            new Item(){
                Id = 9,
                Name= "Burger",
                PreparationTime = 15,
                Complexity = 1,
                CookingApparatus = "oven"
            },
            new Item(){
                Id = 10,
                Name= "Guros",
                PreparationTime = 15,
                Complexity = 1,
                CookingApparatus = null
            },
        };
    }
}
