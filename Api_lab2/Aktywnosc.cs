using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Api_lab2
{
    internal class Aktywnosc
    {
        public int Id { get; set; }
        public string activity { get; set; } = String.Empty;
        public float accessibility { get; set; }
        public string type { get; set; } = String.Empty;
        public int participants { get; set; }
        public float price { get; set; }
        public string link { get; set; } = String.Empty;
        public string key { get; set; } = String.Empty;


        public override string ToString()
        {
            string str = "";
            str += $"activity: {activity}" + Environment.NewLine;
            str += $"accessibility: {accessibility}" + Environment.NewLine;
            str += $"type: {type}" + Environment.NewLine;
            str += $"participants: {participants}" + Environment.NewLine;
            str += $"price: {price}" + Environment.NewLine;
            str += $"link: {link}" + Environment.NewLine;
            str += $"key: {key}" + Environment.NewLine;

            return str;
        }
    }
}
