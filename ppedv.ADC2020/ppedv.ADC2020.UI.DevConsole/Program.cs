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

            foreach (var a in core.Repository.GetAll<Auto>())
            {
                Console.WriteLine($"{a.Farbe}");
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
