using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockaPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            Dobas d = new Dobas(1,5,1,5,3);
            //d.EgyDobas();
            d.KiIras();
            Console.WriteLine(d.Erteke());

            Console.ReadKey();
        }
    }
}
