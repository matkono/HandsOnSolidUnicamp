using System;
using System.Collections.Generic;

namespace BeforeChanges
{
    public class Product
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public string Name { get; set; }

        public List<Tuple<int, DateTime>> Promotionals { get; set; }

        public Product(int id, string name, int price, List<Tuple<int, DateTime>> promotinals) 
        {
            Id = id;
            Price = price;
            Name = name;
            Promotionals = promotinals;
        }

        public string GetInfos() 
        {
            var basicInfos = $"The product with Id {Id} and Name '{Name}' costs {Price} dollars";
            var promotionalsInfo = $"Also has {Promotionals.Count} promotional(s).";
            var promotionalCounter = 1;
            foreach (var promotional in Promotionals) 
            {
                promotionalsInfo += $"{promotionalCounter}° promotional: starts in {promotional.Item2} and lasts for {promotional.Item1} month(s). ";
                promotionalCounter++;
            }

            return basicInfos;
        }
    }
}
