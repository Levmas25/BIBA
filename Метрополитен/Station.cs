using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Метро
{
    public class Station
    {
        string name;
        string color;
        Line line;
        bool isWheelchairAccessible;
        bool hasParkandRide;
        bool hasNearbyCableCar;
        List<Station> transfers;
        public Station(string name, string color, List<Station> transfers)
        {
            this.name = name;
            this.color = color;
            this.transfers = transfers;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public bool IsWheelchairAccessible()
        {
            return isWheelchairAccessible;
        }
        public bool HasParkandRide()
        {
            return hasParkandRide;
        }
        public bool HasNearbyCableCar()
        {
            return hasNearbyCableCar;
        }
        public string GetLineName()
        {
            return line.GetName();
        }
        public List<Station> GetTransferList()
        {
            return transfers;
        }
    }
}
