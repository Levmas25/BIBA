using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface IStoraltem
    {
        public double Price { get; set; }
        public double DiscountPrice(int pricent)
        {
            return Price * pricent;
        }
    }

    public class Disk : IStoraltem
    {
        protected string name, genre;
        protected int burnCount;
        public Disk(string name, string genre)
        {
            this.name = name;
            this.genre = genre;
        }
        public virtual int DiskSize { get; set; }
        public double DiscountPrice { get; }
        public double Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual void Burn(params string[] values)
        {
            
        }

    }
    public class Audio : Disk
    {
        protected string artist, recordingStudio;
        protected int songsNumber;
        public Audio(string artist, string recordingStudio, int songsNumber, string name, string genre) : base(name, genre)
        {
            this.artist = artist;
            this.recordingStudio = recordingStudio;
            this.songsNumber = songsNumber;
            this.name = name;
            this.genre = genre;
        }
        public override int DiskSize { get => songsNumber * 8; }
        public override void Burn(params string[] values)
        {
            artist = values[0];
            recordingStudio = values[1];
            songsNumber = int.Parse(values[2]);
            name = values[3];
            genre = values[4];
            burnCount++;
        }
        public override string ToString()
        {
            return $"Название: {name}, Жанр: {genre}, Исполнитель: {artist}, Студия звукозаписи :{recordingStudio}, Количество песен: {songsNumber}, Количество прожигоа: {burnCount}";
        }
    }
    public class DVD : Disk
    {
        protected string producer, filmCompany;
        protected int minutesCount;
        public DVD (string producer, string filmCompany, int minutesCount, string name, string genre) : base(name, genre)
        {
            this.producer = producer;
            this.filmCompany = filmCompany;
            this.name = name;
            this.genre = genre;
            this.minutesCount = minutesCount;
        }
        public override int DiskSize { get => ((minutesCount) / 64 * 2); }
        public override void Burn(params string[] values)
        {
            producer = values[0];
            filmCompany = values[1];
            minutesCount = int.Parse(values[2]);
            name = values[3];
            genre = values[4];
            burnCount++;
        }
        public override string ToString()
        {
            return $"Название: {name}, Жанр: {genre}, Режисёр: {producer}, Кинокомпания: {filmCompany}, Количество минут: {minutesCount}, Количество прожигов: {burnCount}";
        }
    }
    public class Store
    {
        protected string storeName;
        protected string addres;
        protected List<Audio> audios;
        protected List<DVD> dvds;
        public Store(string storeName, string addres)
        {
            this.storeName = storeName;
            this.addres = addres;
        }
        public static Store operator +(Store start, DVD plus)
        {
            start.dvds.Add(plus);
            return start;
        }
        public static Store operator -(Store start, DVD minus)
        {
            start.dvds.Remove(minus);
            return start;
        }

        public static Store operator +(Store start, Audio plus)
        {
            start.audios.Add(plus);
            return start;
        }
        public static Store operator -(Store start, Audio minus)
        {
            start.audios.Remove(minus);
            return start;
        }
        public override string ToString()
        {
            string a = "Аудиодиски: ";
            string b = "Фильмы: ";
            for(int i = 0; i < audios.Count; i++)
            {
                a += $"{audios[i]}";
            }
            for(int i = 0; i < dvds.Count; i++)
            {
                b += $"{dvds[i]}";
            }
            return a + b;
        }
    }

    class Program
    {
       public static void Main(string[] args)
        {
            Store store = new("Название", "Адрес");
            List<Audio> audios = new();
            DVD first = new("aboba", "NEXT DOOR", 2, "DUNGEON", "Gachi");
            DVD second = new("abiba", "Full", 3, "Boys", "GachiRem");
            DVD third = new("biba", "GYM", 4, "Slave", "GachiRemix");
            store += first;
            store += second;
            store += third;
            Audio fif = new("aboba", "NEXT DOOR", 2, "DUNGEON", "Gachi");
            Audio six = new("abiba", "Full", 3, "Boys", "GachiRem");
            Audio seven = new("biba", "GYM", 4, "Slave", "GachiRemix");
            store.ToString();
            third.Burn("ok", "yes", "4", "no", "aboba");
        }
    }
}
