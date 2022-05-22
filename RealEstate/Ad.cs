using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RealEstate
{
    class Ad
    {
        public Ad()
        {

        }
        public Ad(string sor)
        {
            string[] adatok = sor.Split(";");
            this.id = Convert.ToInt32(adatok[0]);
            this.Rooms = Convert.ToInt32(adatok[1]);
            this.LatLong = adatok[2];
            this.Floors = Convert.ToInt32(adatok[3]);
            this.Area = int.Parse(adatok[4]);
            this.Description = adatok[5];
            this.FreeOfCharge = Convert.ToBoolean(Convert.ToInt32(adatok[6]));
            this.ImageUrl = adatok[7];
            this.CreateAt = Convert.ToDateTime(adatok[8]);
            this.Seller = new Seller() { id = Convert.ToInt32(adatok[9]), Name = adatok[10], Phone = adatok[11], };
            this.Category = new Category() { id = Convert.ToInt32(adatok[12]), Name = adatok[13] };
        }

        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public int id { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }


        public IEnumerable<Ad> LoadFromCsv(string filename)
        {
            foreach (var sor in File.ReadAllLines(filename).Skip(1))
            {
                yield return new Ad(sor);
            }
        }

        public double DistanceTo(double x, double y)
        {
            double dx = Math.Abs(Convert.ToDouble(this.LatLong.Split(",")[0].Replace(".", ",")) - x);
            double dy = Math.Abs(Convert.ToDouble(this.LatLong.Split(",")[1].Replace(".", ",")) - y);

            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        }

    }
}
