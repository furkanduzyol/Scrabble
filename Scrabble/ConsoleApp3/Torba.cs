using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeÖdevi
{
    class Torba
    {
        private List<HarfTasi> taslar;
        private Random rnd = new Random();

        public Torba()
        {
            taslar = new List<HarfTasi>();
            Doldur();
            Karistir();
        }

        
        public void Doldur()
        {
            
            var harfler = new Dictionary<char, (int adet, int puan)>
            {
                {'A', (12, 1)}, {'B', (2, 3)}, {'C', (2, 4)}, {'Ç', (2, 4)},
                {'D', (2, 3)}, {'E', (8, 1)}, {'F', (1, 7)}, {'G', (1, 5)},
                {'Ğ', (1, 8)}, {'H', (1, 5)}, {'I', (4, 2)}, {'İ', (7, 1)},
                {'J', (1, 10)}, {'K', (7, 1)}, {'L', (7, 1)}, {'M', (4, 2)},
                {'N', (5, 1)}, {'O', (3, 2)}, {'Ö', (1, 7)}, {'P', (1, 5)},
                {'R', (6, 1)}, {'S', (3, 2)}, {'Ş', (2, 4)}, {'T', (5, 1)},
                {'U', (3, 2)}, {'Ü', (2, 3)}, {'V', (1, 7)}, {'Y', (2, 3)}, {'Z', (2, 4)}
            };

            foreach (var kvp in harfler)
            {
                for (int i = 0; i < kvp.Value.adet; i++)
                {
                    taslar.Add(new HarfTasi(kvp.Key, kvp.Value.puan));
                }
            }

            
            taslar.Add(new HarfTasi('*', 0));
            taslar.Add(new HarfTasi('*', 0));
        }

       
        public void Karistir()
        {
            int n = taslar.Count;
            for (int i = 0; i < n; i++)
            {
                int j = rnd.Next(n);
                var temp = taslar[i];
                taslar[i] = taslar[j];
                taslar[j] = temp;
            }
        }

       
        public HarfTasi HarfCek()
        {
            if (bosMu())
                return null;

            var secilen = taslar[0];
            taslar.RemoveAt(0);
            return secilen;
        }

        
        public bool bosMu()
        {
            return taslar.Count == 0;


        }

      
        public int KalanTasSayisi()
        {
            return taslar.Count;
        }
    }
}
