using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuCLI
{
    internal class Program
    {

        /* 1. Készítsen konzolos alkalmazást a következő feladatok megoldására, amelynek projektjét
              sudokuCLI néven mentse el!

           2. A forráskódba a meglévő osztály elé illessze be az Osztaly.java avagy az Osztaly.cs
              forrásállományból a Feladvany osztályt definiáló kódrészletét! A beillesztett osztály
              tetszés szerint bővíthető további tagokkal! ---> most külön cs-be teszem */

        //-----------------------------------------------------------------------------------------------------------------

        /* 3. Olvassa be a feladvanyok.txt állományban lévő adatokat és tárolja el egy olyan
              adatszerkezetben, ami a további feladatok megoldására alkalmas! Határozza meg és írja ki
              a képernyőre a minta szerint, hogy hány feladvány található a forrásállományban! */

        

        static void Main(string[] args)
        {
            /*  // 1 MEGOLDAS:
             
            List<Feladvany> feladvanyok = new List<Feladvany>();
            StreamReader sr = new StreamReader("feladvanyok.txt");

            while (!sr.EndOfStream)
            {
                Feladvany uj = new Feladvany(sr.ReadLine());
                feladvanyok.Add(uj);
            }
            sr.Close();

            Console.WriteLine($" 3. feladat: Beolvasva {feladvanyok.Count} feladvány.");              
             */

            //--------------------------------------

            /* // 2. MEGOLDAS:
             
             List<Feladvany> feladvanyok = new List<Feladvany>();
             StreamReader sr = new StreamReader("feladvanyok.txt");

             string sor = "";
             while (!sr.EndOfStream)
             {
                 sor = sr.ReadLine();
                 Feladvany f = new Feladvany(sor);   // sor ---> Osztaly.cs-ben ....konstruktor beillesztése
                 feladvanyok.Add(f);
             }
             sr.Close();  
             Console.WriteLine($" 3. feladat: Beolvasva {feladvanyok.Count} feladvány."); 
            */

            //---------------------------------------

            /*  // 3. MEGOLDAS:
             
             List<Feladvany> feladvanyok = new List<Feladvany>();
             StreamReader sr = new StreamReader("feladvanyok.txt");

             for (int i = 0; i < feladvanyok.Count; i++)
             {
                Console.WriteLine($"{i}. feladavány mérete: {feladvanyok[i].Meret}");   // Meret ---> Osztaly.cs-ben
                Console.WriteLine(feladvanyok[i].Kezdo);                        // Kezdo ---> Osztaly.cs-ben
                feladvanyok[i].Kirajzol();                              // Kirajzol ---> Osztaly.cs-ben
                Console.WriteLine(new String('─',80));
             }
             Console.WriteLine($" 3. feladat: Beolvasva {feladvanyok.Count} feladvány."); 
            */

            //------------------------------------------

            /* // 4. MEGOLDAS: ez ugynaz mint az első, csak rövidítve.
             *
            List<Feladvany> feladvanyok = new List<Feladvany>();
            StreamReader sr = new StreamReader("feladvanyok.txt");

            while (!sr.EndOfStream)
            {
                feladvanyok.Add(new Feladvany(sr.ReadLine()));
            }
            sr.Close();
            Console.WriteLine(" 3. feladat:");
            Console.WriteLine("Feladványok száma: " + feladvanyok.Count);
            */

            //--------------------------------------------

            /*// 5. MEGOLDAS:
             
            List<Feladvany> feladvanyok = new List<Feladvany>();
            feladvanyok = File.ReadAllLines("feladvanyok.txt")

               .Select(sor) => new Feladvany(sor)).ToList();  //!!!!!!!!!!!!!!!!!!!!!JAVÍTANI!!!!!!!!!!!!!!!

            Console.WriteLine(" 3. feladat: Beolvasva {0} feladvány.", feladvanyok.Count);
            */

            //----------------------------------------------

             // 6. MEGOLDÁS:

            List<Feladvany> feladvanyok = new List<Feladvany>();
            String[] sorok = File.ReadAllLines("feladvanyok.txt");

            foreach (var aktSor in sorok)
            {
                Feladvany uj = new Feladvany(aktSor);
                feladvanyok.Add(uj);
            }
            
            Console.WriteLine($"3. feladat: Beolvasva {sorok.Length} feladvány");
            

            Console.WriteLine();   // sortörés

//---------------------------------------------------------------------------------------------------------------------------


            /* 4/a. feladat: Kérjen be a felhasználótól egy 4...9 intervallumba eső(4≤x≤9) egész számot!
                             A beolvasást addig ismételje, amíg a megfelelő értékhatárból érkező számot nem kapjuk! */
                     

            /* // 4/a. 1 MEGOLDÁS:
             
            int meret;
            do
            {
                Console.Write($"4. Feladat: Kérem a feladvány méretét [4..9]:");
                meret = int.Parse(Console.ReadLine());
            } 
            while (meret < 4 || meret > 9);
            */

            //-------------------------------------------
                     
           
            /*// 4/a 2.MEGOLDÁS: adatellenőrzéssel

            int meret;
            string adat;
            do
            {
                Console.Write("4.feladat: Kérem a feladvány méretét [4...9]:");
                adat= Console.ReadLine();
            }
            while (!int.TryParse(adat, out meret) || meret < 4 || meret > 9);
            */

            /* A TryParsnak 2 db paramétere van.
             
               1.p: mit szeretnék átkonvertálni ---> (adat)
               2.p: amivé konvertálja ... eredménye,vagyis a függvény visszatérési értéke
                   azonban nem az átkonvertált adat, vagyis nem az int érték lesz.

                   Visszatérése értéke egy logikai igaz vagy hamis lesz, 
                   (ha nem siekrül átkonvertálni, akkor igaz lesz),  ezután visszaadja
                   azt, amivé konvertálta. Ezt egy kimenő paraméterrel teszi meg ---> (out meret)*/

            //----------------------------------------------

            /* // az előbbi megoldás rovidebben így is írható!
             
             int meret;
            string adat;
            do
            {
                Console.Write("4.feladat: Kérem a feladvány méretét [4...9]:");               
            }
            while (!int.TryParse(Console.ReadLine(), out meret) || meret < 4 || meret > 9);
             */
                                   
            //_____________________________________

            //  4/a. 3. MEGOLDÁS: 

            int meret = 0; // azért kell itt int-elni, mert a do-while ciklus nem ismeri fel.
            do
            {
                Console.Write("4.feladat: Kérem a feladvány méretét [4...9]:");
                meret = Convert.ToInt32(Console.ReadLine());    
            }
            while ( meret < 4 || meret > 9);
//-------------------------------------------------------------------------------------

            /* 4/b. feladat: Határozza meg,és írja a képernyőre, hogy ebből a méretből hány
                             feladvány található a forrásállományban! */
          
            
            /* // 4/b. 1.MEGOLDÁS:
             
            int feladvanyokSzama = 0;

            for (int i = 0; i < feladvanyok.Count; i++)
            {
                if ( feladvanyok[i].Meret == meret)
                {
                    feladvanyokSzama++;
                }
            }
            Console.WriteLine($"{meret}*{meret} méretű feladványból {feladvanyokSzama} db van tárolva.");
            */

            //------------------------------------------------
         
             /*  // 4/b. 2.MEGOLDÁS: 
            
            List<Feladvany> kivalogatottak = new List<Feladvany>();
            foreach (var vizsgaltFeladvany in feladvanyok)
            {
                if (vizsgaltFeladvany.Meret == meret)
                {
                    kivalogatottak.Add(vizsgaltFeladvany);
                }
            }
            Console.WriteLine($"{meret}x{meret} méretű feladványból {kivalogatottak.Count} darab van tárolva");
             */

            //-----------------------------------------------

            // 4/b. 3:MEGOLDÁS: 

            int meretDb= 0;

            foreach( var db in feladvanyok )
            {
                if ( db.Meret == meret)
                {
                  meretDb++;
                }
                
            }
            Console.WriteLine("{0}*{0} méretű feladványból {1} darab van tárolva.", meret, meretDb);

           



        }
    }
    }

