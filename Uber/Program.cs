using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
UBER Firması bir ücret tahmin etme programı hazırlayacak.
Bu program araç çağırmadan önce seyahat ücretinin ne kadar tutacağını hesaplayacaktır.
Yaklaşık seyahat uzaklığı ve tahmini süreye göre aşağıdaki formüle göre hesaplama yapıcak.

    (cost_per_mile)*(ride_time)+(cost_per_minute)*(ride_distance)

    cost per minute ve cost per mile araç tipine göre değişmektedir.
    KISITLAR: 
    1. ride_time= 10-50 dk arasında olmalı
    2. ride_distance=5-20 mile arasında olmalı

*/

namespace Uber
{
    class Program
    {
        static void Main(string[] args)
        {
            int ride_time;
            int ride_distance;
            double sonuc;

            double[] cost_per_mile = new double[4]; //4 elemanlı double tipinde array
            cost_per_mile[0] = 1.1;
            cost_per_mile[1] = 1.8;
            cost_per_mile[2] = 2.3;
            cost_per_mile[3] = 3.5;

            double[] cost_per_minutes = new double[4];
            cost_per_minutes[0] = 0.2;
            cost_per_minutes[1] = 0.35;
            cost_per_minutes[2] = 0.4;
            cost_per_minutes[3] = 0.45;

            bool sart = false;

            // double[] HesaplamaSonuclari = new double[4]; // çıkacak sonucları içine atmak için 4 elemanlı array

            do
            {
                Console.Write("10-50 dakika arasinda Ride Time değerini giriniz: ");
                ride_time = Convert.ToInt32(Console.ReadLine());
                if (ride_time >= 10 && ride_time <= 50) // ride time kısıtı
                {
                    do
                    {
                        //do-while yerine if else kullansaydık. Verilen aralık değeri dışında veri girildiğinde
                        //program en fazla bir kez uyarı verecekti. İkinci defa aralık dışı veri girildiğinde consoldan atacaktı.

                        Console.Write("5-20 mile arasinda Ride Distance giriniz: ");
                        ride_distance = Convert.ToInt32(Console.ReadLine());

                        if (ride_distance >= 5 && ride_distance <= 20)//ride distance kısıtı
                        {

                            for (int i = 0; i < cost_per_mile.Length; i++)
                            {
                                sonuc = Hesapla(ride_time, ride_distance, cost_per_minutes[i], cost_per_mile[i]);

                                Console.WriteLine("{0}. araç tipi için tahmini seyahat ücreti={1}", i + 1, sonuc);
                                //döngüyle her bir araç tipi için ayrı ayrı ücret gösterdik.
                            }
                            sart = true;
                        }
                        else
                        {
                            Console.WriteLine("5-20 mile arasında tekrar değer giriniz");
                            sart = false;
                        }
                    } while (sart == false);

                }
                else
                {
                    Console.WriteLine("10-50 dakika arasında tekrar değer giriniz");
                    sart = false;
                }
            } while (sart == false);


            Console.ReadKey();

        }

        public static double Hesapla(int ridetime, int ridedistance, double costperminute, double costpermile)
        {
            return (costperminute * ridetime) + (costpermile * ridedistance);
        }
        //parametreli Metot 

    }

}


