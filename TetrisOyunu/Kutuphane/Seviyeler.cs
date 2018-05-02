using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisOyunu.Kutuphane
{
    public static class Seviyeler
    {
        public static int SeviyeHiziAl(int aktifHiz, int seviye)
        {
            int hiz = 0;
            if (seviye == 0)
            {
                hiz = 800;
            }
            else if(seviye >= 1 && seviye <= 5)
            {
              hiz = aktifHiz - 100;
            }
            else if (seviye >= 6 && seviye <= 10)
            {
                hiz = aktifHiz - 50;
            }            
            else
            {
                if (aktifHiz > 10)
                {
                    hiz = aktifHiz - 10;
                }
                else
                {
                    hiz = 1;
                }
            }
            return hiz;
        }
        public static bool SeviyeArtsinMi(int seviye, int satirSayisi)
        {            
            if (seviye == 0 && satirSayisi >= 10)
            {
                return true;
            }
            else if ((seviye >= 1 && seviye <= 5 )&& satirSayisi >= 15)
            {
                return true;
            }
            else if ((seviye >= 6 && seviye <= 10) && satirSayisi >= 20)
            {
                return true;
            }
            else
            {
                if (satirSayisi >= 25)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
