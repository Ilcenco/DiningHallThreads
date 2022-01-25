using System;

namespace KitchenThreads.Models
{
    public class Cook
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public int Proficiency { get; set; }
        public string CatchPhrase { get; set; }

        public Cook(string name, int rank, int proficiency)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Rank = rank;
            this.Proficiency = proficiency;
            this.CatchPhrase = "Okaaay let's gooo";
        }


    }
}
