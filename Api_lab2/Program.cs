using Api_lab2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Apka"), InternalsVisibleTo("GUI")]


namespace Lab2
{
    internal class Client
    {
        public HttpClient httpClient;
        public Aktywnosc activity = new Aktywnosc();

        public async Task GetData(string call)
        {
            httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync(call);
            activity = JsonSerializer.Deserialize<Aktywnosc>(response);
            Console.WriteLine(response);
            Console.WriteLine(activity);
        }
    }

    internal class Klasa
    {
        public void Generuj(int i, AktywnoscDB activityDB)
        {
            Client client;
            //AktywnoscDB activityDB;

            client = new Client();
            //activityDB = new AktywnoscDB();

            AktywnoscGenerator generator = new AktywnoscGenerator();

          
            for (int j = 0; j < i; j++)
            {
                string nowyKlucz = generator.GenerujNowyKlucz();

                string url = "http://www.boredapi.com/api/activity/";
                client.GetData(url).Wait();


                Aktywnosc activity = client.activity;
                var found = activityDB.aktywnosc.FirstOrDefault(a => a.key == nowyKlucz);
                if (found == null)
                {
                    Console.WriteLine("Trzeba dodać tę aktywność!");
                    activityDB.aktywnosc.Add(activity);
                }
                else
                {
                    Console.WriteLine("Już było!");
                }

                activityDB.SaveChanges();
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)

        {
            AktywnoscDB activityDB;
            activityDB = new AktywnoscDB();

            foreach (var aktywnosc in activityDB.aktywnosc)
                activityDB.aktywnosc.Remove(aktywnosc);

            activityDB.SaveChanges();

            Console.WriteLine("Baza:");
            Console.WriteLine("Menu aktywności:\n");

            int numer = 1;
            foreach (var aktywnosc in activityDB.aktywnosc)
            {
                Console.WriteLine(aktywnosc.ToString());
                
                numer++;
            }

            Console.WriteLine("Podaj ilosc wygenerowanych API:" );
            int parametr = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");


            Klasa obiekt = new Klasa();
            obiekt.Generuj(parametr, activityDB);

            Console.WriteLine("Baza:");
            Console.WriteLine("Menu aktywności:");
            Console.WriteLine("\n");

            numer = 1;
            foreach (var aktywnosc in activityDB.aktywnosc)
            {
                Console.WriteLine(aktywnosc.ToString());
                numer++;
            }
        }
    }


    public class AktywnoscGenerator
    {
        private int licznik = 0; 

        public string GenerujNowyKlucz()
        {

            int nowyKlucz = ++licznik;

            return nowyKlucz.ToString();
        }
    }

}
