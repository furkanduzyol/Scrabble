using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjeÖdevi
{
    class Oyuncu
    {
        private static readonly Dictionary<char, int> HarfPuanlari = new Dictionary<char, int>
{
    {'A', 1}, {'B', 3}, {'C', 4}, {'Ç', 4},
    {'D', 3}, {'E', 1}, {'F', 7}, {'G', 5},
    {'Ğ', 8}, {'H', 5}, {'I', 2}, {'İ', 1},
    {'J', 10}, {'K', 1}, {'L', 1}, {'M', 2},
    {'N', 1}, {'O', 2}, {'Ö', 7}, {'P', 5},
    {'R', 1}, {'S', 2}, {'Ş', 4}, {'T', 1},
    {'U', 2}, {'Ü', 3}, {'V', 7}, {'Y', 3},
    {'Z', 4}, {'*', 0}
};
        public string isim;
        public string soyisim;
        public int yas;
        public int skor;
        public List<HarfTasi> taslar;
        //private List<char> harfler;

        public Oyuncu(string isim, string soyisim, int yas)
        {
            this.isim = isim;
            this.soyisim = soyisim;
            this.yas = yas;
            this.skor = 0;
            this.taslar = new List<HarfTasi>();
            //this.harfler = new List<char>();
        }

        public string BilgiGoster()
        {
            return $"{isim} {soyisim}, Yaş: {yas}, Skor: {skor}";
        }
        public void TaslariYazdir()
        {
            Console.WriteLine($"{isim} {soyisim}'nın taşları ");
            foreach (var tas in taslar)
            {
                Console.Write($"{tas.Harf}: {tas.Puan} ");
                Console.WriteLine();
            }
            
        }


        public bool GirilenHarflereSahipMi(string kelime)
        {
            
            List<char> tempHarfler = taslar.Select(t => t.Harf).ToList();

            foreach (char c in kelime)
            {
                if (tempHarfler.Contains(c))
                {
                    tempHarfler.Remove(c);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public void KullanilanTaslariCikar(string kelime)
        {
            foreach (char c in kelime)
            {
                var tas = taslar.FirstOrDefault(t => t.Harf == c);
                if (tas != null)
                {
                    taslar.Remove(tas);
                }
            }
        }
        public void YeniTaslarEkle(Torba torba, int adet)
        {
            for (int i = 0; i < adet; i++)
            {
                var cekilenTas = torba.HarfCek();
                if (cekilenTas != null)
                {
                    taslar.Add(cekilenTas);
                }
                else
                {
                    break;
                }
            }
        }

        public bool TasiBittiMi()
        {
            return taslar.Count == 0;
        }


        public int PuaniniGuncelle(TahtaHücresi[,] board, string kelime, int x, int y, string yon)
        {
            bool ikikatı = false;
            bool üçkatı = false;
            int toplamPuan = 0;
            int i = 0;
            if (yon == "YATAY")
            {
                //board[y, x + i].Harf = kelime[i];
                
                foreach (char c in kelime.ToUpperInvariant())
                {
                    if (HarfPuanlari.ContainsKey(c))
                    {
                        if(board[y, x + i].Bonus == "H2")
                        {
                            
                            toplamPuan += HarfPuanlari[c] * 2;
                        }
                        else if(board[y, x + i].Bonus == "H3")
                        {
                            
                            toplamPuan += HarfPuanlari[c] * 3;
                        }
                        else if (board[y, x + i].Bonus == "K2")
                        {
                            
                            toplamPuan += HarfPuanlari[c];
                            ikikatı = true;

                        }
                        else if (board[y, x + i].Bonus == "K3")
                        {
                            
                            toplamPuan += HarfPuanlari[c];
                            üçkatı = true;
                        }
                        else
                        {
                            
                            toplamPuan += HarfPuanlari[c];
                        }
                       
                        i++;
                    }

                }
            }
            else if (yon == "YATAY_TERS")
            {
                
                foreach (char c in kelime.ToUpperInvariant())
                {
                    if (HarfPuanlari.ContainsKey(c))
                    {
                        if (board[y, x - i].Bonus == "H2")
                        {
                            
                            toplamPuan += HarfPuanlari[c] * 2;
                        }
                        else if (board[y, x - i].Bonus == "H3")
                        {
                            
                            toplamPuan += HarfPuanlari[c] * 3;
                        }
                        else if (board[y, x - i].Bonus == "K2")
                        {
                            
                            toplamPuan += HarfPuanlari[c];
                            ikikatı = true;

                        }
                        else if (board[y, x - i].Bonus == "K3")
                        {
                            
                            toplamPuan += HarfPuanlari[c];
                            üçkatı = true;
                        }
                        else
                        {
                            
                            toplamPuan += HarfPuanlari[c];
                        }
                        
                        i++;
                    }

                }
            }
            else if (yon == "DİKEY")
            {
                
                foreach (char c in kelime.ToUpperInvariant())
                {
                    if (HarfPuanlari.ContainsKey(c))
                    {
                        if (board[y + i, x].Bonus == "H2")
                        {
                            
                            toplamPuan += HarfPuanlari[c] * 2;
                        }
                        else if (board[y + i, x].Bonus == "H3")
                        {
                            
                            toplamPuan += HarfPuanlari[c] * 3;
                        }
                        else if (board[y + i, x].Bonus == "K2")
                        {
                           
                            toplamPuan += HarfPuanlari[c];
                            ikikatı = true;

                        }
                        else if (board[y + i, x].Bonus == "K3")
                        {
                            
                            toplamPuan += HarfPuanlari[c];
                            üçkatı = true;
                        }
                        else
                        {
                            
                            toplamPuan += HarfPuanlari[c];
                        }
                        
                        i++;
                    }

                }
            }
            else if (yon == "DİKEY_TERS")
            {
                //board[y - i, x].Harf = kelime[i];
                foreach (char c in kelime.ToUpperInvariant())
                {
                    if (HarfPuanlari.ContainsKey(c))
                    {
                        if (board[y - i, x].Bonus == "H2")
                        {
                            
                            toplamPuan += HarfPuanlari[c] * 2;
                        }
                        else if (board[y - i, x].Bonus == "H3")
                        {
                            
                            toplamPuan += HarfPuanlari[c] * 3;
                        }
                        else if (board[y - i, x].Bonus == "K2")
                        {
                            
                            toplamPuan += HarfPuanlari[c];
                            ikikatı = true;

                        }
                        else if (board[y - i, x].Bonus == "K3")
                        {
                           
                            toplamPuan += HarfPuanlari[c];
                            üçkatı = true;
                        }
                        else
                        {
                            
                            toplamPuan += HarfPuanlari[c];
                        }
                        
                        i++;
                    }

                }
            }

            
            if (ikikatı)
            {
                toplamPuan *= 2;
            }
            if (üçkatı)
            {
                toplamPuan *= 3;
            }
            return toplamPuan;
        }





    }
}
