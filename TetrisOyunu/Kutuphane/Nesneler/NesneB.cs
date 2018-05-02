using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisOyunu.Kutuphane.Nesneler
{
    public class NesneB : Nesne, INesne
    {
        public NesneB(Tablo tablo)
            : base(tablo, new Nokta(4, 2))
        {            
        }
        public override void NesneOlustur()
        {            
            this.KutuOlustur(0, 0);
            this.KutuOlustur(0, 1);
            this.KutuOlustur(1, 0);
            this.KutuOlustur(1, 1);
        }
        public override bool PozisyonAlt()
        {
            bool dondu =  
            this.Kutular[0].DondurmekIcinTasi(0, 0) &&
            this.Kutular[1].DondurmekIcinTasi(0, 1) &&
            this.Kutular[2].DondurmekIcinTasi(1, 0) &&
            this.Kutular[3].DondurmekIcinTasi(1, 1);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override bool PozisyonSol()
        {
            bool dondu =  
            this.Kutular[0].DondurmekIcinTasi(0, 0) &&
            this.Kutular[1].DondurmekIcinTasi(0, 1) &&
            this.Kutular[2].DondurmekIcinTasi(1, 0) &&
            this.Kutular[3].DondurmekIcinTasi(1, 1);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override bool PozisyonUst()
        {
            bool dondu =  
            this.Kutular[0].DondurmekIcinTasi(0, 0)&&
            this.Kutular[1].DondurmekIcinTasi(0, 1)&&
            this.Kutular[2].DondurmekIcinTasi(1, 0)&&
            this.Kutular[3].DondurmekIcinTasi(1, 1);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override bool PozisyonSag()
        {
            bool dondu =  
            this.Kutular[0].DondurmekIcinTasi(0, 0) &&
            this.Kutular[1].DondurmekIcinTasi(0, 1) &&
            this.Kutular[2].DondurmekIcinTasi(1, 0) &&
            this.Kutular[3].DondurmekIcinTasi(1, 1);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override Color RenkOku()
        {
            return Color.Yellow;
        }
    }
}
