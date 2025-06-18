using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeÖdevi
{
    class Sözlük
    {
        private HashSet<string> kelimeler;

        //Siz liste ya da arraylist kullanın dediniz de ben dosya okuma işlemi yapacağım için HashSet kullandım.
        //Liste kullanınca aralarında virgül bulunan kelime listesi internette bulamadım açıkçası
        //Çalışması için dosyayolunu düzenlemeniz gerekiyor sanırım hocam
        public void Olustur(string dosyaYolu = "C:\\Users\\duzyo\\Desktop\\dosya\\TDK_Sözlük_Kelime_Listesi.txt")
        {
            kelimeler = new HashSet<string>();


            if (!string.IsNullOrEmpty(dosyaYolu) && File.Exists(dosyaYolu))
            {

                foreach (var satir in File.ReadAllLines(dosyaYolu))
                {


                    kelimeler.Add(satir.Trim().ToUpper());
                }
            }
            
        }

        
        public bool KelimeVarMi(string kelime)
        {

               return kelimeler.Contains(kelime.ToUpper());
        }
    }
}
