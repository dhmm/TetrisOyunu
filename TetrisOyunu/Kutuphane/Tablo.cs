using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisOyunu.Kutuphane
{
    public class Tablo
    {
        public Oyun Oyun { set; get; }
        public readonly int GENISLIK = 10;
        public readonly int YUKSEKLIK = 18;
        public readonly int UST_BOSLUK = 4;
        public readonly int KUTU_GENISLIK = 30;
        public readonly int KUTU_YUKSEKLIK = 30;
        
        public Kutu[,] Kutular { set; get; }
        public INesne AktifNesne { set; get; }
        public INesne SonrakiNesne { set; get; }

        public Panel PanelTablo { set; get; }
        public Panel PnlSonrakiNesne { set; get; }
        //public Timer Timer { set; get; }

        public Tablo(Oyun oyun, Panel panel,Panel pnlSonrakiNesne)
        {
            this.Oyun = oyun;
            this.PanelTablo = panel;
            this.PnlSonrakiNesne = pnlSonrakiNesne;

            Kutular = new Kutu[GENISLIK, YUKSEKLIK + UST_BOSLUK];    
            AktifNesne = NesneFactory.NesneUret(this);
            AktifNesne.PaneleEkle(PanelTablo);
            SonrakiNesneUretGoster();
        }
        public Kutu this[int x,int y]
        {
            set
            {                
                this.Kutular[x, y] = value;                
            }
            get
            {
                return this.Kutular[x, y];
            }
        }
        public void Dondur()        
        {
            this.AktifNesne.Dondur();
        }
        public void SagaGit()
        {
            this.AktifNesne.SagaGit();
        }
        public void SolaGit()
        {
            this.AktifNesne.SolaGit();
        }
        public void Indir()
        {
            if (this.AktifNesne.AsagiIn() == false)
            {
                if (this.AktifNesne.UsteCarptiMi())
                {
                    Oyun.UsteCarpti();                    
                }
                else
                {
                    this.SonrakiNesneyeGec();
                }
            }
        }

        private void SonrakiNesneyeGec()
        {
            this.AktifNesne.Sabitle();
            this.OKSatirVarMiDenetle();
            this.AktifNesne = this.SonrakiNesne;
            this.AktifNesne.PaneleEkle(this.PanelTablo);


            SonrakiNesneUretGoster();
        }
        private void SonrakiNesneUretGoster()
        {
            this.SonrakiNesne = NesneFactory.NesneUret(this);
            SonrakiNesne.SonrakiPaneldeGoster(this.PnlSonrakiNesne);
        }
        private void OKSatirVarMiDenetle()
        {            
            List<int> okSatirlar = new List<int>();
            for(int satir = YUKSEKLIK + UST_BOSLUK  - 1 ;satir>=UST_BOSLUK;satir--)
            {                
                if(SatirOKMi(satir))
                {                    
                    okSatirlar.Add(satir);                                        
                }
                else
                {
                    if (okSatirlar.Count > 0)
                    {
                        this.Oyun.PuanVer(okSatirlar.Count());
                        OKSatirlariKaldir(okSatirlar);
                        okSatirlar = new List<int>();
                    }
                }
            }
        }
        private bool SatirOKMi(int satir)
        {
            bool satirOk = true;
            for (int sutun = 0; sutun < GENISLIK; sutun++)
            {
                if (this.Kutular[sutun, satir] == null)
                {
                    satirOk = false;
                    continue;
                }
            }
            return satirOk;
        }

        private void OKSatirlariKaldir(List<int> okSatirlar)
        {            
            if (okSatirlar.Count > 0)
            {
                OKSatirlariYokEt(okSatirlar);
                OKSatirlarinYerleriniDoldur(okSatirlar);
            }
        }
        private void PuanArttir(int okSatirSayisi)
        {
            int puan = okSatirSayisi * 10;
        }
        private void OKSatirlariYokEt(List<int> okSatirlar)
        {
            foreach (int okSatir in okSatirlar)
            {
                for (int okSutun = 0; okSutun < GENISLIK; okSutun++)
                {
                    this.Kutular[okSutun, okSatir].PanelKutu.Dispose();
                    this.Kutular[okSutun, okSatir] = null;
                }
            }
        }
        private void OKSatirlarinYerleriniDoldur(List<int> okSatirlar)
        {
            int minSatir = okSatirlar.Min();
            int satirBoslugu = okSatirlar.Count();

            for (int i = minSatir; i >= UST_BOSLUK; i--)
            {
                for (int j = 0; j < GENISLIK; j++)
                {
                    if (Kutular[j, i] != null)
                    {
                        Kutular[j, i].SatirIndir(satirBoslugu);
                    }
                }
            }
        }

        
    }
}
