using System.Text;

namespace Kassenautomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //Umstellung der Konsole von UTF16 auf UTF8
            string titel = @"
 ____  ____  ____  ____  ____  ____  ____  ____  ____  ____ 
||W ||||i ||||l ||||l ||||k ||||o ||||m ||||m ||||e ||||n ||
||__||||__||||__||||__||||__||||__||||__||||__||||__||||__||
|/__\||/__\||/__\||/__\||/__\||/__\||/__\||/__\||/__\||/__\|
";
            string[] geld = { "500 Euroschein", "200 Euroschein", "100 Euroschein", "50 Euroschein", "20 Euroschein", "10 Euroschein", "5 Euroschein", "2 Münze", "1 Münze", "50 Cent", "20 Cent", "10 Cent", "5 Cent", "2 Cent", "1 Cent" };


            int[] scheineUndMuenzen = { 50000, 20000, 10000, 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };
            decimal gegeben;

            Console.WriteLine(titel);

            Console.Write("Geben Sie den zu zahlenden Betrag ein: ");
            decimal betrag = decimal.Parse(Console.ReadLine());

            while (true)
            {

                Console.Write("Geben Sie den gezahlten Betrag ein: ");
                gegeben = decimal.Parse(Console.ReadLine());


                if (gegeben > betrag)
                {
                    break;
                }
                else if (gegeben == betrag)
                {
                    Console.WriteLine("Der gegebene Betrag passt genau!");
                    return;
                }
                Console.WriteLine("Der Betrag ist zu niedrig");
            }

            decimal rueckgeld = gegeben - betrag;
            Console.WriteLine($"Rückgeld: {rueckgeld:C}");

            int rueckgeldInCent = (int)(rueckgeld * 100);

            for (int i = 0; i < scheineUndMuenzen.Length; i++)
            {
                int anzahl = rueckgeldInCent / scheineUndMuenzen[i];

                if (anzahl > 0)
                {
                    Console.WriteLine($"{anzahl} x {geld[i]}");
                    rueckgeldInCent = rueckgeldInCent % scheineUndMuenzen[i];
                    //rueckgeldInCent %= scheineUndMuenzen[i];

                }

            }
        }
    }
}
