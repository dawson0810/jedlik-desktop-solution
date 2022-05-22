using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstate
{
    class Program
    {
        static List<Ad> ads = new List<Ad>();
        static void Main(string[] args)
        {
            Ad ad = new Ad();

            ads = ad.LoadFromCsv("realestates.csv").ToList();

            Console.WriteLine("1. Földszinti ingatlanok átlagos alapterülete: {0:F2} m2", ads.Where(x => x.Floors == 0).Average(x => x.Area));

            var hirdetes = ads.Where(x => x.FreeOfCharge == true).OrderBy(x => x.DistanceTo(47.4164220114023, 19.066342425796986)).ToList()[0];

            Console.WriteLine("2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai: " +
                                "\n\tEladó neve: {0}" +
                                "\n\tEaldó telefonja: {1}" +
                                "\n\tAlapterület: {2}" +
                                "\n\tSzobák száma: {3}", hirdetes.Seller.Name, hirdetes.Seller.Phone, hirdetes.Area, hirdetes.Rooms);
        }
    }
}
