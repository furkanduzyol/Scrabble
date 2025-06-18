using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeÖdevi
{
    class HarfTasi
    {
        public char Harf;     
        public int Puan;     

        public HarfTasi(char harf, int puan)
        {
            Harf = harf;
            Puan = puan;
        }

        public override string ToString()
        {
            return $"{Harf} ({Puan})";
        }
    }
}
