using System;
using System.Threading;

namespace SP_Lab6
{
    public class Factory
    {
        public int Manufactories { get; set; } = 0;
        public int Material { get; set; } = 0;
        public int Products { get; set; } = 0;
        public int Money { get; set; } = 0;
        public int MaterialMax { get; set; } = 100;
        public bool BuyDone = true;
        public bool MakeDone = true;
        public bool SellDone = true;

        public Factory()
        {
            
        }

        public Factory(int money = 1000, int manufactories = 3)
        {
            Money = money;
            Manufactories = manufactories;
        }

        public void BuyMaterial()
        {
            BuyDone = false;
            for (int i = 0; i < MaterialMax / 5; i++)
            {
                if(Money < 300 || (MaterialMax - Material) < MaterialMax / 20)
                    break;
                
                Money -= 300;
                Thread.Sleep(300);
                Material += MaterialMax / 20;
            }
            BuyDone = true;
        }

        public void MakeProducts()
        {
            MakeDone = false;
            for (int i = 0; Material > 0 && Money >= 10; i++)
            {
                Material -= 1;
                Thread.Sleep(1000 / Manufactories);
                Money -= 10;
                Products += 1;
            }

            MakeDone = true;
        }

        public void SellProducts()
        {
            SellDone = false;
            for (int i = 0; Products > 0; i++)
            {
                Products -= 1;
                Thread.Sleep(150);
                Money += 200;
            }

            SellDone = true;
        }

        public void AddMoney(int money)
        {
            Money += money;
        }

        public void AddManufatories(int manufactories)
        {
            Manufactories += manufactories;
        }
    }
}