using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeÖdevi
{
    class Koordinat
    {
        public int Satir;
        public int Sutun;

        public Koordinat(int satir, int sutun)
        {
            Satir = satir;
            Sutun = sutun;
        }

        public override string ToString() => $"({Satir}, {Sutun})";
    }
}
