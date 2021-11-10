using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Метро
{
    public class Line
    {
        List<Station> stations;
        string name;
        string color;

        public Line(string name, string color)
        {
            this.name = name;
            this.color = color;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetColor()
        {
            return color;
        }
        public void SetColor(string color)
        {
            this.color = color;
        }
        public void AddStaion(string name, string color)
        {
            stations.Add(new Station(name, this.color, null));
        }
        public Station FindStationByName(string name)
        {
            foreach (Station i in stations)
            {
                if (i.GetName() == name)
                {
                    return i;
                }
            }
            return null;
        }
        public void RemoveStation(string name)
        {
            stations.Remove(FindStationByName(name));
        }
        public List<Station> GetStationList()
        {
            return stations;
        }
    }
}