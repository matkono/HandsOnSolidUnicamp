using AfterChanges.Models;
using System;
using System.Collections.Generic;

namespace AfterChanges
{
    public class Product
    {
        public int Id { get; private set; }

        public int Price { get; private set; }

        public string Name { get;  private set; }

        public List<Promotional> Promotionals { get; private set; }

        public Product(int id, string name, int price)
        {
            Id = id;
            Price = price;
            Name = name;
            Promotionals = new List<Promotional>();
        }

        public string GetInfos()
        {
            return GetBasicInfo() + GetPromotionalsInfo();
        }

        private string GetBasicInfo()
        {
            return $"The product with Id {Id} and Name '{Name}' costs {Price} dollars. ";
        }

        private string GetPromotionalsInfo() 
        {
            var promotionalsInfo = $"Also has {Promotionals.Count} promotional(s). ";
            var promotionalCounter = 1;
            foreach (var promotional in Promotionals)
            {
                promotionalsInfo += $"{promotionalCounter}° promotional: starts in {promotional.DateStart} and lasts for {promotional.MonthsExemption} month(s). ";
                promotionalCounter++;
            }

            return promotionalsInfo;
        }

        public void AddPromotional(Promotional promotional) 
        {
            Promotionals.Add(promotional);
        }

        public void ChangeName(string newName) 
        {
            Name = newName;
        }
    }
}
