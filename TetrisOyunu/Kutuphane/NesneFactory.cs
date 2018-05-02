using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisOyunu.Kutuphane.Nesneler;

namespace TetrisOyunu.Kutuphane
{
    public static class NesneFactory
    {
        public static Random R = new Random();
        public static INesne NesneUret(Tablo tablo)
        {
            INesne nesne = null;
            int nesneTipi = R.Next(1, NesneTipleri.TOPLAM_NESNE_SAYISI + 1);

            switch (nesneTipi)
            {
                case NesneTipleri.NesneA:
                    nesne = new NesneA(tablo);
                    break;
                case NesneTipleri.NesneB:                    
                    nesne = new NesneB(tablo);
                    break;
                case NesneTipleri.NesneC:
                    nesne = new NesneC(tablo);
                    break;
                case NesneTipleri.NesneD:
                    nesne = new NesneD(tablo);
                    break;
                case NesneTipleri.NesneE:
                    nesne = new NesneE(tablo);
                    break;
                case NesneTipleri.NesneF:
                    nesne = new NesneF(tablo);
                    break;
                case NesneTipleri.NesneG:
                    nesne = new NesneG(tablo);
                    break;
            }
            return nesne;
        }
    }
}
