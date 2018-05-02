using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisOyunu.Kutuphane.Nesneler
{
    public class NesneA : Nesne, INesne
    {

        public NesneA(Tablo tablo)
            : base(tablo, new Nokta(2,0))
        {           
        }
        public override void NesneOlustur()
        {            
            this.KutuOlustur(2, 0);
            this.KutuOlustur(2, 1);
            this.KutuOlustur(2, 2);
            this.KutuOlustur(2, 3);
        }
        public override bool PozisyonAlt()
        {
            int sabitX = 2;            
            bool dondu =  
            this.Kutular[0].DondurmekIcinTasi(sabitX, 0) &&
            this.Kutular[1].DondurmekIcinTasi(sabitX, 1) &&
            this.Kutular[2].DondurmekIcinTasi(sabitX, 2) &&
            this.Kutular[3].DondurmekIcinTasi(sabitX, 3);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override bool PozisyonSol()
        {
            int sabitY = 1;
            bool dondu = 
            this.Kutular[0].DondurmekIcinTasi(0, sabitY) &&
            this.Kutular[1].DondurmekIcinTasi(1, sabitY) &&
            this.Kutular[2].DondurmekIcinTasi(2, sabitY) &&
            this.Kutular[3].DondurmekIcinTasi(3, sabitY);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override bool PozisyonUst()
        {
            int sabitX = 2;
            bool dondu = 
            this.Kutular[0].DondurmekIcinTasi(sabitX, 0) &&
            this.Kutular[1].DondurmekIcinTasi(sabitX, 1) &&
            this.Kutular[2].DondurmekIcinTasi(sabitX, 2) &&
            this.Kutular[3].DondurmekIcinTasi(sabitX, 3);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override bool PozisyonSag()
        {
            int sabitY = 1;
            bool dondu = 
            this.Kutular[0].DondurmekIcinTasi(0, sabitY) &&
            this.Kutular[1].DondurmekIcinTasi(1, sabitY) &&
            this.Kutular[2].DondurmekIcinTasi(2, sabitY) &&
            this.Kutular[3].DondurmekIcinTasi(3, sabitY);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override Color RenkOku()
        {
            return Color.Red;            
        }

       

    }
}
