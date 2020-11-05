using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockaPoker
{
    class Dobas
    {
        int[] kockak = new int[5];

        public Dobas(int k1 ,int k2,int k3, int k4, int k5)
        {
            kockak[0] = k1;
            kockak[1] = k2;
            kockak[2] = k3;
            kockak[3] = k4;
            kockak[4] = k5;
        }
        public void EgyDobas()
        {
            Random rnd = new Random();
            for (int i = 0; i < kockak.Length; i++)
            {
                kockak[i] = rnd.Next(1, 7);
            }
        }
        public void KiIras()
        {
            foreach (var k in kockak)
            {
                Console.Write($"{k} ");
            }
        }
        public string Erteke()
        {
            Dictionary<int, int> eredmeny = new Dictionary<int, int>();

            for (int i = 0; i <=6; i++)
            {
                eredmeny.Add(i,0);
            }

            foreach (var k in kockak)
            {
                eredmeny[k]++;
            }
            //A dictionaryból lekérdezzük az 1 value-nál nagyobb elemeket
            //Első eset ha egy elem marad(value értéket nézzük):
            //  -5 akkor nagypóker
            //  -4 póker
            //  -3 drill
            //  -2 pár
            //  A key érték mondja meg hogy hányas -> 4-es póker
            //Második eset két elem marad:
            /*Value 3 és 2 full
             * value 2és 2 két pár
             * Harmadik eset nem marad egy sem:
             *  -Ha a Key:6 egyenlő nulla -> kis sor
             *  -Ha a key:1 =0 ->nagy sor
             *Minden más esetben szemét(moslék)*/
            var result = (from e in eredmeny
                         orderby e.Value,e.Key descending
                         where e.Value > 1
                         select new { szam = e.Key, Db = e.Value }).ToList();

            Console.WriteLine();

            int darab = result.Count;
            string[] egyes = new string[] { "", "", "Pár", "Drill", "Póker", "Nagypóker" };
            return $"{result[0].szam} {egyes[result[0].Db]}";
           
            //Ez is jó
            //switch (result[0].Db)
            //{
            //    case 5: return $"{result[0].szam} Nagypóker";

            //    case 4: return $"{result[0].szam} Póker";

            //    case 3: return $"{result[0].szam} Drill";

            //    case 2: return $"{result[0].szam} Pár";
            //}
        }
    }
}
