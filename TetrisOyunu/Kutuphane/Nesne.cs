using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisOyunu.Kutuphane
{
    public abstract class Nesne
    {
        public Tablo Tablo { set; get; }
        public List<Kutu> Kutular { set; get; }
        public int Poziyon { set; get; }
                
        public bool Tasindi { set; get; }
        public Nokta ReferansNoktasi { set; get; }        

        public Nesne(Tablo tablo,Nokta referansNoktasi)
        {
            this.Tablo = tablo;
            this.ReferansNoktasi = referansNoktasi;
            this.Kutular = new List<Kutu>();
            this.Poziyon = Pozisyonlar.ALT;
            this.NesneOlustur();                       
            this.Tasindi = false;            
        }
        public abstract void NesneOlustur();
        public abstract bool PozisyonAlt();
        public abstract bool PozisyonSol();
        public abstract bool PozisyonUst();
        public abstract bool PozisyonSag();
        public abstract Color RenkOku();

        public void PaneleEkle(Panel panel)
        {
            foreach (Kutu k in this.Kutular)
            {
                panel.Controls.Add(k.PanelKutu);
            }
        }
        public void Dondur()
        {            
            if (GorunenKismiVarMi())
            {                
                switch (this.Poziyon)
                {
                    case Pozisyonlar.ALT:
                        SolaDondur();
                        break;
                    case Pozisyonlar.SOL:
                        UsteDondur();
                        break;
                    case Pozisyonlar.UST:
                        SagaDondur();
                        break;
                    case Pozisyonlar.SAG:
                        AltaDondur();
                        break;
                }                
            }
        }
        public void SagaGit()
        {
            if (SagaGidebilirMi())
            {
                TasinmadiAyarla();
                
                foreach (Kutu k in this.Kutular)
                {
                    k.SagaGit();
                }
                this.ReferansNoktasi.X++;
            }
        }
        public void SolaGit()
        {
            if (SolaGidebilirMi())
            {
                TasinmadiAyarla();
                
                foreach (Kutu k in this.Kutular)
                {
                    k.SolaGit();
                }
                this.ReferansNoktasi.X--;
            }
        }
        public bool AsagiIn()
        {
            if (AsagiInebilirMi())
            {
                TasinmadiAyarla();
                foreach (Kutu k in this.Kutular)
                {
                    k.AsagiIn();
                }
                this.ReferansNoktasi.Y++;                
                return true;
            }
            return false;
        }
        public void Sabitle()
        {
            foreach (Kutu k in this.Kutular)
            {
                k.Statu = Statuler.SABIT;
            }
        }
        public bool UsteCarptiMi()
        {
            foreach (Kutu k in this.Kutular)
            {
                if (k.Nokta.Y < this.Tablo.UST_BOSLUK)
                {
                    return true;
                }
            }
            return false;
        }
        public void SonrakiPaneldeGoster(Panel pnlSonraki)
        {
            pnlSonraki.Controls.Clear();
            foreach (Kutu k in this.Kutular)
            {                                
                Panel panel = new Panel();
                panel.Width = this.Tablo.KUTU_GENISLIK;
                panel.Height = this.Tablo.KUTU_YUKSEKLIK;
                panel.Left = (k.Nokta.X * this.Tablo.KUTU_GENISLIK - (this.ReferansNoktasi.X * this.Tablo.KUTU_GENISLIK)) + this.Tablo.KUTU_GENISLIK;
                panel.Top = (k.Nokta.Y * this.Tablo.KUTU_YUKSEKLIK - (this.ReferansNoktasi.Y * this.Tablo.KUTU_YUKSEKLIK)) + this.Tablo.KUTU_YUKSEKLIK;
                panel.BackColor = k.PanelKutu.BackColor;
                panel.BorderStyle = BorderStyle.FixedSingle;
                pnlSonraki.Controls.Add(panel);
            }
        }
        protected void KutuOlustur(int x, int y)
        {
            this.Kutular.Add(new Kutu(Tablo,ReferansNoktasi, x, y,this.RenkOku()));            
        }
        protected void PanelleriTasi()
        {
            foreach (Kutu k in this.Kutular)
            {
                k.PanelKutu.Left = k.Nokta.X * this.Tablo.KUTU_GENISLIK;
                k.PanelKutu.Top = k.Nokta.Y * this.Tablo.KUTU_YUKSEKLIK - (this.Tablo.UST_BOSLUK * this.Tablo.KUTU_YUKSEKLIK);
            }         
        }

        private void TasinmadiAyarla( )
        {
            foreach(Kutu k in this.Kutular)
            { 
                k.Tasindi = false;
            }
        }         
        private void AltaDondur()
        {
            if (this.PozisyonAlt())
            {
                this.Poziyon = Pozisyonlar.ALT;
            }
            else
            {
                this.PozisyonSag();
            }
        }
        private void SolaDondur()
        {
            if (this.PozisyonSol())
            {
                this.Poziyon = Pozisyonlar.SOL;
            }
            else
            {
                this.PozisyonAlt();
            }
        }
        private void UsteDondur()
        {
            if (this.PozisyonUst())
            {
                this.Poziyon = Pozisyonlar.UST;
            }
            else
            {
                this.PozisyonSol();
            }
        }
        private void SagaDondur()
        {
            if (this.PozisyonSag())
            {
                this.Poziyon = Pozisyonlar.SAG;
            }
            else
            {
                this.PozisyonUst();
            }
        }
        private bool SagaGidebilirMi()
        {
            if (GorunenKismiVarMi())
            {
                bool gidebilirMi = true;
                foreach (Kutu k in this.Kutular)
                {
                    gidebilirMi = gidebilirMi && k.SagaGidebilirMi();
                }
                return gidebilirMi;
            }
            return false;
        }         
        private bool SolaGidebilirMi()
        {            
            if (GorunenKismiVarMi())
            {
                bool gidebilirMi = true;
                foreach (Kutu k in this.Kutular)
                {
                    gidebilirMi = gidebilirMi && k.SolaGidebilirMi();
                }
                return gidebilirMi;
            }
            return false;            
        }
        private bool AsagiInebilirMi()
        {
            bool inebilirMi = true;
            foreach (Kutu k in this.Kutular)
            {
                inebilirMi = inebilirMi && k.AsagiInebilirMi();
            }
            return inebilirMi;
        }
        private bool GorunenKismiVarMi()
        {            
            foreach (Kutu k in this.Kutular)
            {
                if (k.Nokta.Y >= this.Tablo.UST_BOSLUK)
                {
                    return true;
                }
            }
            return false;
        }        
        
    }
}
