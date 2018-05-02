using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TetrisOyunu.Kutuphane
{
    public class Oyun
    {
        public const int TEK_SATIR_PUANI = 40;
        public const int IKI_SATIR_PUANI = 100;
        public const int UC_SATIR_PUANI = 300;
        public const int DORT_SATIR_PUANI = 1200;
        

        internal Tablo Tablo { set; get; }
        internal Panel Panel { set; get; }
        internal Panel PnlSonrakiNesne { set; get; }
        internal Timer Timer { set; get; }

        internal bool OynaniyorMu { set; get; }
        private int _seviye = 0;
        internal int Seviye 
        {
            set
            {
                this._seviye = value;
                this.LblSeviye.Text = value.ToString();
            }
            get
            {
                return this._seviye;
            }
        }
        Label LblSeviye { set; get; }
        private int _puan = 0;
        internal int Puan 
        {
            set
            {
                this._puan = value;
                this.LblPuan.Text = value.ToString();
            }
            get
            {
                return this._puan;
            }
        }
        Label LblPuan { set; get; }
        private int SeviyeBasiSatirSayisi = 0;

        public Oyun(Panel panel, Timer timer,Label lblPuan,Label lblSeviye,Panel pnlSonrakiNesne)
        {
            this.Panel = panel;
            this.Timer = timer;
            this.LblPuan = lblPuan;
            this.LblSeviye = lblSeviye;
            this.PnlSonrakiNesne = pnlSonrakiNesne;
            this.Timer.Enabled = false;
            this.OynaniyorMu = false;            
        }
        public void Yeni()
        {
            Panel.Controls.Clear();
            Tablo = new Tablo(this, Panel, PnlSonrakiNesne);
            this.Seviye = 0;
            this.Puan = 0;
            this.SeviyeBasiSatirSayisi = 0;
            this.Timer.Interval = Seviyeler.SeviyeHiziAl(0, this.Seviye);
            this.Timer.Enabled = true;
            this.OynaniyorMu = true;            
        }
        public void Indir()
        {
            if (OynaniyorMu)
            {
                Tablo.Indir();
            }
        }
        public void DuraklatDevamEttir()
        {
            this.Timer.Enabled = !this.Timer.Enabled;            
        }
        public void TusOku(KeyEventArgs e)
        {
            if (OynaniyorMu)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        Timer.Stop();
                        if (MessageBox.Show("Yeniden baslasin mi ?", "Yeniden?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            Yeni();
                        }
                        else
                        {
                            Timer.Start();
                        }
                        break;
                    case Keys.Left:
                        Tablo.SolaGit();
                        break;
                    case Keys.Right:
                        Tablo.SagaGit();
                        break;
                    case Keys.Down:
                        Tablo.Indir();
                        break;
                    case Keys.A:
                        Tablo.Dondur();
                        break;
                    case Keys.Pause:
                        DuraklatDevamEttir();
                        break;                   
                }
            }
            else
            {
                if (e.KeyCode == Keys.F2)
                {
                    Yeni();
                }
            }

        }
        public void SeviyeArttir()
        {
            this.SeviyeBasiSatirSayisi = 0;
            Seviye++;
            this.Timer.Interval = Seviyeler.SeviyeHiziAl(this.Timer.Interval, this.Seviye);
            
            
        }
        public void PuanVer(int satirSayisi)
        {
            this.SeviyeBasiSatirSayisi += satirSayisi;

            int puan = 0;
            switch (satirSayisi)
            {
                case 1:
                    puan += TEK_SATIR_PUANI;                    
                    break;
                case 2:
                    puan += IKI_SATIR_PUANI;
                    break;
                case 3:
                    puan += UC_SATIR_PUANI;
                    break;
                case 4:
                    puan += DORT_SATIR_PUANI;
                    break;
            }
            puan += (puan * this.Seviye);
            this.Puan += puan;

            if (Seviyeler.SeviyeArtsinMi(this.Seviye, this.SeviyeBasiSatirSayisi))
            {                
                this.SeviyeArttir();
            }
        }
        internal void UsteCarpti()
        {
            Timer.Stop();
            MessageBox.Show("Oyun bitti");
        }
       
    }
}
