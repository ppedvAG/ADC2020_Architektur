using ppedv.ADC2020.Logic;
using ppedv.ADC2020.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.ADC2020.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** ADC2020 DevConsole ***");

            var core = new Core();

            if (core.Repository.GetAll<Auto>().Count() == 0)
                core.CreateDemoDaten();

            foreach (var a in core.Repository.GetAll<Auto>())
            {
                Console.WriteLine($"{a.Hersteller},{a.Modell} {a.Farbe}");
                foreach (var vm in a.Vermietungen)
                {
                    Console.WriteLine($"{vm.Start:D}-{vm.Ende:D} {vm.Kunde.Name}");
                }
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
