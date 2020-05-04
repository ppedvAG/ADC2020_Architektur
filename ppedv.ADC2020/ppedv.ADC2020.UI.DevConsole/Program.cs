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

            if (core.Repository.Query<Auto>().Count() == 0)
                core.CreateDemoDaten();

            foreach (var a in core.Repository.Query<Auto>().OrderBy(x => x.Created.Year).ThenBy(x => x.Farbe).ToList())
            {
                Console.WriteLine($"{a.Hersteller},{a.Modell} {a.Farbe}");
                foreach (var vm in a.Vermietungen)
                {
                    Console.WriteLine($"\t{vm.Start:D}-{vm.Ende:D} {vm.Kunde.Name}");
                }
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
