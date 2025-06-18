using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjeÖdevi
{
    class Oyun
    {
        public List<Oyuncu> oyuncular;
        public int Index = 0;
        public Oyun()
        {
            oyuncular = new List<Oyuncu>();
        }


        public void Baslat()
        {
            
            

            Torba torba = new Torba();
            torba.Doldur();
            torba.Karistir();

            Tahta tahta = new Tahta();
            


            Console.Clear();

          
        }
        public void Oynat()
        {

            
            Torba torba = new Torba();
            torba.Doldur();
            torba.Karistir();

            Tahta tahta = new Tahta();
            OyuncuBilgileriniAl();
            Console.WriteLine("\nİki oyuncunun da bilgileri sistemimize kaydedildi. Oyuna başlatmak istiyorsanız ENTER'a basın");
            Console.ReadLine();
            
            

            Console.Clear();
            TahtaHücresi[,] board = tahta.tahtaolusturma();
            OyuncularaTasDagit(torba);
            Oyuncu aktifOyuncu = oyuncular[Index];

            
            while ((!torba.bosMu() || !aktifOyuncu.TasiBittiMi()) )
            {
                
                tahta.TahtaYazdir(board);
        
                OyuncularinTaslariniGoster();
                SkorlariYaz();
                
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{aktifOyuncu.isim}'nin sırası.");
                Console.ResetColor();

                Console.WriteLine();
                var (baslangic, bitis, kelime) = KoordinatVeKelimeAl();

                Console.WriteLine($"Başlangıç: {baslangic}, Bitiş: {bitis}, Kelime: {kelime}");



                if (GirilenInputGecerliMi(board, baslangic, bitis, kelime))
                {
                    //Oyuncu oyuncu = new Oyuncu(aktifOyuncu.isim, aktifOyuncu.soyisim, aktifOyuncu.yas);
                    aktifOyuncu.KullanilanTaslariCikar(kelime);
                    aktifOyuncu.YeniTaslarEkle(torba, kelime.Length);

                    string yon;
                     if (baslangic.Satir == bitis.Satir)
                      {
                          yon = (bitis.Sutun >= baslangic.Sutun) ? "YATAY" : "YATAY_TERS";
                      }
                      else if (baslangic.Sutun == bitis.Sutun)
                      {
                          yon = (bitis.Satir >= baslangic.Satir) ? "DİKEY" : "DİKEY_TERS";
                      }
                      else
                      {
                          throw new Exception("Yön belirlenemedi.");
                      }
                   




                    tahta.hucreleringüncellenmesi(board, kelime, baslangic.Sutun, baslangic.Satir, yon);



                    aktifOyuncu.skor += aktifOyuncu.PuaniniGuncelle(board, kelime, baslangic.Sutun, baslangic.Satir, yon);
                    

                }
              


                   
                    if(Index == 0)
                    {
                        Index = 1;
                    }
                    else
                    {
                        Index = 0;
                    }
                    
                    aktifOyuncu = oyuncular[Index];
                    

            }
           // OyunBittiMi();


        }

        public void OyuncuBilgileriniAl()
        {
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine($"{i}. oyuncunun adını giriniz:");
                string isim = Console.ReadLine();

                Console.WriteLine($"{i}. oyuncunun soyadını giriniz:");
                string soyisim = Console.ReadLine();

                Console.WriteLine($"{i}. oyuncunun yaşını giriniz:");
                int yas = int.Parse(Console.ReadLine());

                Oyuncu oyuncu = new Oyuncu(isim, soyisim, yas);
                oyuncular.Add(oyuncu);
            }
        }
        public void OyuncularaTasDagit(Torba torba)
        {
            foreach (var oyuncu in oyuncular)
            {
                for (int i = 0; i < 7; i++)
                {
                    HarfTasi cekilen = torba.HarfCek();
                    if (cekilen != null)
                    {
                        oyuncu.taslar.Add(cekilen);
                    }
                }
            }
        }



        public void OyuncularinTaslariniGoster()
        {
            Console.WriteLine("\n--- Oyuncuların Taşları ---");

            foreach (var oyuncu in oyuncular)
            {
                oyuncu.TaslariYazdir();
            }
        }



        public void SkorlariYaz()
        {
            Console.WriteLine("\n--- Oyuncu Skorları ---");
            foreach (var o in oyuncular)
            {
                Console.WriteLine($"{o.isim} {o.soyisim} -> Skor: {o.skor}");
            }
        }

        public (Koordinat baslangic, Koordinat bitis, string kelime) KoordinatVeKelimeAl()
        {
            Console.Write("Başlangıç satırı (0-14): ");
            int basSatir = int.Parse(Console.ReadLine());

            Console.Write("Başlangıç sütunu (0-14): ");
            int basSutun = int.Parse(Console.ReadLine());

            Console.Write("Bitiş satırı (0-14): ");
            int bitSatir = int.Parse(Console.ReadLine());

            Console.Write("Bitiş sütunu (0-14): ");
            int bitSutun = int.Parse(Console.ReadLine());

            Console.Write("Yazmak istediğiniz kelime: ");
            string kelime = Console.ReadLine()?.ToUpper().Trim();

            var basKoord = new Koordinat(basSatir, basSutun);
            var bitKoord = new Koordinat(bitSatir, bitSutun);

            return (basKoord, bitKoord, kelime);
        }
        bool ilkmi = true;


        //Hocam size geçerlilik yatay, dikey, ve temas metotlarını tahtaya koymamızı istemişssiniz ama ben tüm fonksiyonları
        //girileninputgecerlimi fonksiyonunua koydum. 
        public bool GirilenInputGecerliMi(TahtaHücresi[,] board,Koordinat baslangic, Koordinat bitis, string kelime)
        {
            bool GirilenInputGecerliMiDeğilMi = true;
            Console.ForegroundColor = ConsoleColor.Red;
            
            if (baslangic.Satir < 0 || baslangic.Satir > 14 ||
                baslangic.Sutun < 0 || baslangic.Sutun > 14 ||
                bitis.Satir < 0 || bitis.Satir > 14 ||
                bitis.Sutun < 0 || bitis.Sutun > 14)
            {
                Console.WriteLine("Koordinatlar 0 ile 14 arasında olmalıdır.");
                GirilenInputGecerliMiDeğilMi = false;
            }

            // Kelime boş veya null olmamalı
            if (string.IsNullOrEmpty(kelime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kelime boş olamaz.");
                
                GirilenInputGecerliMiDeğilMi = false;
            }

            Sözlük sozluk = new Sözlük();
            sozluk.Olustur();
            if (!sozluk.KelimeVarMi(kelime))
            {
                
                Console.WriteLine("Sözlükte böyle bir kelime yok.");
                GirilenInputGecerliMiDeğilMi = false;

            }
            
            
            if (!oyuncular[Index].GirilenHarflereSahipMi(kelime))
            {
                Console.WriteLine("Aktif olan oyuncunun taşları ile kelimenin harfleri uyumlu değil.");
                GirilenInputGecerliMiDeğilMi = false;
            }


            // Koordinatlar ya aynı satırda ya da aynı sütunda olmalı (yatay veya dikey)
            bool yatay = baslangic.Satir == bitis.Satir;
            bool dikey = baslangic.Sutun == bitis.Sutun;

            if (!yatay && !dikey)
            {
                Console.WriteLine("harfler dikey ya da yatay konumda olmalıdır.");
                GirilenInputGecerliMiDeğilMi = false;
            }

            // Kelimenin uzunluğu ile koordinatlar arasındaki mesafe uyumlu mu?
            int aralik = yatay
                ? Math.Abs(bitis.Sutun - baslangic.Sutun) + 1
                : Math.Abs(bitis.Satir - baslangic.Satir) + 1;

            if (kelime.Length != aralik)
            {
                Console.WriteLine("Kelimenin uzunluğu koordinatlar arasındaki mesafeye uymuyor.");
                GirilenInputGecerliMiDeğilMi = false;
            }




            string yon;

            if (baslangic.Satir == bitis.Satir)
            {
                if (bitis.Sutun >= baslangic.Sutun)
                {
                    yon = "YATAY";
                }
                else
                {
                    yon = "YATAY_TERS";
                }
            }
            else if (baslangic.Sutun == bitis.Sutun)
            {
                if (bitis.Satir >= baslangic.Satir)
                {
                    yon = "DİKEY";
                }
                else
                {
                    yon = "DİKEY_TERS";
                }
            }
            else
            {
                yon = "YATAY";   
            }

           

            for (int i = 0; i < kelime.Length; i++)
            {
                

                int satir = 0, sutun = 0;

                switch (yon)
                {
                    case "YATAY":
                        satir = baslangic.Satir;
                        sutun = baslangic.Sutun + i;
                        break;

                    case "YATAY_TERS":
                        satir = baslangic.Satir;
                        sutun = baslangic.Sutun - i;
                        break;

                    case "DİKEY":
                        satir = baslangic.Satir + i;
                        sutun = baslangic.Sutun;
                        break;

                    case "DİKEY_TERS":
                        satir = baslangic.Satir - i;
                        sutun = baslangic.Sutun;
                        break;
                }
                if (board[satir, sutun].Dolu)  // boş hücreyi "  " olarak
                {
                    Console.WriteLine($"Belirtilen konumda zaten harf var dolu olan hücreye harf koyamazsınız.");
                    GirilenInputGecerliMiDeğilMi = false;
                }

            }

            
            
            bool komsuVarMi = false;


           //Temas kuralına ilk kelime yazılırken bakalmaması için ilkmi diye boolean tanımladım
           //eğer ilk giren kişi yanlış yaparsa, hata alırsa da bu tarz bir yapı tercih ettim hocam.
            if (ilkmi && GirilenInputGecerliMiDeğilMi == true)
            {
                ilkmi = false;
            }
            else if(ilkmi == true && GirilenInputGecerliMiDeğilMi == false)
            {
                ilkmi = true;
            }
            else
            {
                if(yon != "DİKEY_TERS" && yon != "YATAY_TERS")
                {
                    for (int i = 0; i < kelime.Length && komsuVarMi == false; i++)
                {
                    int satir, sutun;
                    switch (yon)
                    {
                        case "YATAY":
                            satir = baslangic.Satir;
                            sutun = baslangic.Sutun + i;
                            break;

                        case "YATAY_TERS":
                            satir = baslangic.Satir;
                            sutun = baslangic.Sutun - i;
                            break;

                        case "DİKEY":
                            satir = baslangic.Satir + i;
                            sutun = baslangic.Sutun;
                            break;

                        case "DİKEY_TERS":
                            satir = baslangic.Satir - i;
                            sutun = baslangic.Sutun;
                            break;
                        default:
                            satir = baslangic.Satir;
                            sutun = baslangic.Sutun + i;
                            break;
                    }

                   
                    int[,] komsular = new int[,] {
                    { satir - 1, sutun }, 
                    { satir + 1, sutun }, 
                    { satir, sutun - 1 }, 
                    { satir, sutun + 1 }  
                };

                    for (int k = 0; k < 4 && komsuVarMi == false; k++)
                    {
                        int ks = komsular[k, 0];
                        int ss = komsular[k, 1];

                        if (ks >= 0 && ks <= 14 && ss >= 0 && ss <= 14)
                        {
                            if (board[ks, ss].Dolu)
                            {
                                komsuVarMi = true;

                            }
                        }
                    }



                }

                }
                else
                {
                    komsuVarMi = true;
                }

                if (!komsuVarMi)
                {
                    Console.WriteLine("Harfler önceki harflerden en az birine temas etmelidir.");
                    GirilenInputGecerliMiDeğilMi = false;

                }

            }

                
           /* if(ilkmi = false && GirilenInputGecerliMiDeğilMi == false)
            {
                ilkmi = true;
            }*/


            Console.ResetColor();
            return GirilenInputGecerliMiDeğilMi;
        }

     



    }

}
