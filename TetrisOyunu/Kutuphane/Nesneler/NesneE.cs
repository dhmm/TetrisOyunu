using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisOyunu.Kutuphane.Nesneler
{
    public class NesneE : Nesne, INesne
    {
        public NesneE(Tablo tablo)
            : base(tablo, new Nokta(2,0))
        {           
        }
        public override void NesneOlustur()
        {            
            this.KutuOlustur(1, 1);
            this.KutuOlustur(1, 2);
            this.KutuOlustur(1, 3);
            this.KutuOlustur(2, 3);
        }
        public override bool PozisyonAlt()
        {                   
            bool dondu =  
            this.Kutular[0].DondurmekIcinTasi(1, 1) &&
            this.Kutular[1].DondurmekIcinTasi(1, 2) &&
            this.Kutular[2].DondurmekIcinTasi(1, 3) &&
            this.Kutular[3].DondurmekIcinTasi(2, 3);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override bool PozisyonSol()
        {
            bool dondu =
            this.Kutular[0].DondurmekIcinTasi(1, 2) &&
            this.Kutular[1].DondurmekIcinTasi(2, 2) &&
            this.Kutular[2].DondurmekIcinTasi(3, 2) &&
            this.Kutular[3].DondurmekIcinTasi(1, 3);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override bool PozisyonUst()
        {
            bool dondu =
            this.Kutular[0].DondurmekIcinTasi(1, 1) &&
            this.Kutular[1].DondurmekIcinTasi(2, 1) &&
            this.Kutular[2].DondurmekIcinTasi(2, 2) &&
            this.Kutular[3].DondurmekIcinTasi(2, 3);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override bool PozisyonSag()
        {
            bool dondu =
            this.Kutular[0].DondurmekIcinTasi(2, 2) &&
            this.Kutular[1].DondurmekIcinTasi(0, 3) &&
            this.Kutular[2].DondurmekIcinTasi(1, 3) &&
            this.Kutular[3].DondurmekIcinTasi(2, 3);
            if (dondu)
            {
                this.PanelleriTasi();
            }
            return dondu;
        }
        public override Color RenkOku()
        {
            return Color.Pink;            
        }
    }
}
