using System;
using System.Collections.Generic;

namespace AUTOpark
{
    public class Car
    {
        protected string lable;
        protected int power;
        protected int yearCreate;
        public Car(string lable, int power, int yearCreate)
        {
            this.lable = lable;
            this.power = power;
            this.yearCreate = yearCreate;
        }
    }
    public class PassengerCar : Car
    {
        private int KolPas;
        private Dictionary<string, int> repairing;
        public PassengerCar(string lable, int power, int yearCreate) : base(lable, power, yearCreate)
        {
            this.KolPas = KolPas;
            repairing = new Dictionary<string, int>();
        }
        public void AddBk(string repair, int yearlast)
        {
            repairing.Add(repair, yearlast);
        }
        public int Format(string sov)
        {
            if (repairing.ContainsKey(sov)) return repairing[sov];
            return 0;
        }
        public string Print(string s, int v)
        {
            foreach (string k in repairing.Keys)
            {
                Console.Write(k + " - ");
                Console.WriteLine(repairing[k]);
                s = k.ToString();
                v = repairing[s];
                return v.ToString();
            }
        }
        public virtual string String()
        {
            return $"Марка: {lable}\nМощность:{power}\nГод производства: {yearCreate}\nКоличество пассажиров: {KolPas}\n\n";
        }
    }
    public class Truck : Car
    {
        private int maxPow;
        private string name;
        private int weight;
        private Dictionary<string, int> product;
        public Truck(string lable, int power, int yearCreate) : base(lable, power, yearCreate)
        {
            this.maxPow = maxPow;
            this.name = name;
            product = new Dictionary<string, int>();
        }
        public void ChangeDr(string name)
        {
            this.name = name;
        }
        public void SetMax(int maxPow2, string nul)
        {
            product.Add(nul, maxPow2);
        }
        public void DelMax(string nul)
        {
            if (!product.Remove(nul)) Console.WriteLine("Нет такого груза!");
        }
        public string PrintPr(string g, int y)
        {
            foreach (string i in product.Keys)
            {
                Console.Write(i + " - ");
                Console.WriteLine(product[i]);
                g = i.ToString();
                y = product[g];
                return y.ToString();
            }
        }
        public virtual string String()
        {
            return $"Марка: {lable}\nМощность:{power}\nГод производства: {yearCreate}\nМаксимальная грузоподъёмность: {maxPow}\nФИ водителя: {name}\n\n";
        }
    }
    public class Autopark
    {
        private string namePark;
        public List<PassengerCar> smalCar;
        public List<Truck> bigCar;
        public Autopark()
        {
            smalCar = new List<PassengerCar>();
            bigCar = new List<Truck>();
        }
        public virtual string String(string nul, string ok)
        {
            ok = "";
            nul = "";
            nul += "Легковые машины\n";
            foreach (PassengerCar i in smalCar)
            {
                nul += i.ToString();
            }
            ok += "Грузовые машины\n";
            foreach (Truck i in bigCar)
            {
                nul += i.ToString();
            }
            return nul;
        }
}

class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
