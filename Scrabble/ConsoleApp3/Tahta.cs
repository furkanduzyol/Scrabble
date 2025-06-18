using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeÖdevi
{
    class Tahta
    {
        public TahtaHücresi[,] tahtaolusturma()
        {
            int k, t;
            TahtaHücresi[,] board = new TahtaHücresi[15, 15];

            for (k = 0; k < 15; k++)
            {
                for (t = 0; t < 15; t++)
                {
                    board[k, t] = new TahtaHücresi("  ");
                }
            }
           
            board[0, 2].Bonus = "K3";
            board[0, 5].Bonus = "H2";
            board[0, 9].Bonus = "H2";
            board[0, 12].Bonus = "K3";
            board[1, 1].Bonus = "H3";
            board[1, 6].Bonus = "H2";
            board[1, 8].Bonus = "H2";
            board[1, 13].Bonus = "H3";
            board[2, 0].Bonus = "K3";
            board[2, 7].Bonus = "K2";
            board[2, 14].Bonus = "K3";
            board[3, 3].Bonus = "K2";
            board[3, 11].Bonus = "K2";
            board[4, 4].Bonus = "H3";
            board[4, 10].Bonus = "H3";
            board[5, 0].Bonus = "H2";
            board[5, 5].Bonus = "H2";
            board[5, 9].Bonus = "H2";
            board[5, 14].Bonus = "H2";
            board[6, 1].Bonus = "H2";
            board[6, 6].Bonus = "H2";
            board[6, 8].Bonus = "H2";
            board[6, 13].Bonus = "H2";
            board[7, 2].Bonus = "K2";
            board[7, 13].Bonus = "K2";
            board[8, 1].Bonus = "H2";
            board[8, 6].Bonus = "H2";
            board[8, 8].Bonus = "H2";
            board[8, 13].Bonus = "H2";
            board[9, 0].Bonus = "H2";
            board[9, 5].Bonus = "H2";
            board[9, 9].Bonus = "H2";
            board[9, 14].Bonus = "H2";
            board[10, 4].Bonus = "H3";
            board[10, 10].Bonus = "H3";
            board[11, 3].Bonus = "K2";
            board[11, 11].Bonus = "K2";
            board[12, 0].Bonus = "K3";
            board[12, 7].Bonus = "K2";
            board[12, 14].Bonus = "K3";
            board[13, 1].Bonus = "H3";
            board[13, 6].Bonus = "H2";
            board[13, 9].Bonus = "H2";
            board[13, 13].Bonus = "H3";
            board[14, 2].Bonus = "K3";
            board[14, 5].Bonus = "H2";
            board[14, 9].Bonus = "H2";
            board[14, 12].Bonus = "K3";

            return board;
        }

        public void TahtaYazdir(TahtaHücresi[,] board)
        {
            Console.Write("    +");
            for (int i = 0; i <= 14; i++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
            
            Console.Write("    |"); 
            for (int x = 0; x <= 9; x++)
            {
                Console.Write($" {x} |");
            }
            for (int x = 10; x <= 14; x++)
            {
                Console.Write($" {x}|");
            }
            Console.WriteLine();



            for (int y = 0; y <= 14; y++)
            {
                for (int i = 0; i <= 15; i++)
                {
                    Console.Write("+---");
                }
                Console.Write("+");
                Console.WriteLine();

                
                Console.Write("|");
                Console.Write($" {y,2}|");
                for (int x = 0; x <= 14; x++)
                {
                    Console.Write($"{board[y, x].ToString(),3}|");
                }


                Console.WriteLine();
            }
            for (int i = 0; i <= 15; i++)
            {
                Console.Write("+---");
            }
            Console.Write("+");
            Console.WriteLine();



        }

        public void hucreleringüncellenmesi(TahtaHücresi[,] board, string kelime, int x, int y, string yon)
        {
            kelime = kelime.ToUpper();

            for (int i = 0; i < kelime.Length; i++)
            {
                if (yon == "YATAY")
                {
                    board[y, x + i].Harf = kelime[i];
                }
                else if (yon == "YATAY_TERS")
                {
                    board[y, x - i].Harf = kelime[i];
                }
                else if (yon == "DİKEY")
                {
                    board[y + i, x].Harf = kelime[i];
                }
                else if (yon == "DİKEY_TERS")
                {
                    board[y - i, x].Harf = kelime[i];
                }
                else
                {
                    throw new Exception("Geçersiz yön değeri!");
                }
            }
        }

       
    }
}
