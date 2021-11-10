using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Метро
{
    public class Metro
    {
        List<Line> lines;
        string city;
        public Metro(string city)
        {
            this.city = city;
            lines = new List<Line>();
        }
        public string GetCity()
        {
            return city;
        }
        public void AddLine(string name, string color)
        {
            lines.Add(new Line(name, color));
        }
        public void RemoveLine(string name)
        {
            foreach (Line i in lines)
            {
                if (i.GetName() == name)
                    lines.Remove(i);
            }
        }
    }
}