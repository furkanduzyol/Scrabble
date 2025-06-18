using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeÖdevi
{
    class TahtaHücresi
    {
        public string Bonus;     
        public char? Harf;       
        public bool Dolu => Harf.HasValue;    

        public TahtaHücresi(string bonus = "")
        {
            Bonus = bonus;
            Harf = null;
        }

        public override string ToString()
        {
            if (Harf.HasValue)
                return $" {Harf}"; 
            else if (!string.IsNullOrEmpty(Bonus))
                return Bonus;       
            else
                return "  ";        
        }
    }
}
