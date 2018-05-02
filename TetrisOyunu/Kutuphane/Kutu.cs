using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisOyunu.Kutuphane
{
    public class Kutu
    {
        public Tablo Tablo { set; get; }
        public Nokta Nokta { set; get; }
        public int Statu { set; get; }

        public bool Tasindi { set; get; }
        public Nokta ReferansNoktasi { set; get; }

        public Panel PanelKutu { set; get; }

        //Kutu olsuturmada referans noktasi baz alinir
        public Kutu(Tablo tablo,Nokta referansNoktasi, int x, int y,Color color)
        {
            this.Tablo = tablo;
            this.ReferansNoktasi = referansNoktasi;
            this.Nokta = new Nokta(referansNoktasi.X+x,referansNoktasi.Y+ y);
            this.Tablo[referansNoktasi.X + x, referansNoktasi.Y+y] = this;
            this.Statu = Statuler.INDIRILEN;
            this.Tasindi = true;
            PanelOlustur(color);
        }
        //Kutu dondurmede referans noktasi baz alinir        
        public bool DondurmekIcinTasi(int x, int y)
        {
            if (TasinaBilirMi(this.ReferansNoktasi.X + x, this.ReferansNoktasi.Y + y))
            {
                Tablo[this.Nokta.X, this.Nokta.Y] = null;                
                this.Nokta.X = this.ReferansNoktasi.X + x;
                this.Nokta.Y = this.ReferansNoktasi.Y + y;
                Tablo[this.ReferansNoktasi.X + x, this.ReferansNoktasi.Y + y] = this;                
                return true;
            }
            return false;
        }                
        public void SagaGit()
        {
            if (!Tasindi)
            {
                int eskiX = this.Nokta.X;
                int eskiY = this.Nokta.Y;
                int yeniX = this.Nokta.X + 1;
                int yeniY = this.Nokta.Y;

                if (this.Tablo[yeniX, yeniY] != null)
                {
                    this.Tablo[yeniX, yeniY].SagaGit();
                }
                Tablo[eskiX, eskiY] = null;
                this.Nokta.X = yeniX;
                this.Nokta.Y = yeniY;
                Tablo[yeniX, yeniY] = this;
                this.Tasindi = true;
                this.PanelKutu.Left += this.Tablo.KUTU_GENISLIK;
            }

        }
        public void SolaGit()
        {
            if (!Tasindi)
            {
                int eskiX = this.Nokta.X;
                int eskiY = this.Nokta.Y;
                int yeniX = this.Nokta.X - 1;
                int yeniY = this.Nokta.Y;

                if (this.Tablo[yeniX, yeniY] != null)
                {
                    this.Tablo[yeniX, yeniY].SolaGit();
                }
                Tablo[eskiX, eskiY] = null;
                this.Nokta.X = yeniX;
                this.Nokta.Y = yeniY;
                Tablo[yeniX, yeniY] = this;
                this.Tasindi = true;
                this.PanelKutu.Left -= this.Tablo.KUTU_GENISLIK;
            }
        }
        public void AsagiIn()
        {
            if (!Tasindi)
            {
                int eskiX = this.Nokta.X;
                int eskiY = this.Nokta.Y;
                int yeniX = this.Nokta.X;
                int yeniY = this.Nokta.Y+1;

                if (this.Tablo[yeniX, yeniY] != null)
                {
                    this.Tablo[yeniX, yeniY].AsagiIn();
                }
                Tablo[eskiX, eskiY] = null;
                this.Nokta.X = yeniX;
                this.Nokta.Y = yeniY;
                Tablo[yeniX, yeniY] = this;
                this.Tasindi = true;
                this.PanelKutu.Top += this.Tablo.KUTU_YUKSEKLIK;                
            }
        }
        public bool SagaGidebilirMi()
        {
            Nokta nokta = new Nokta(this.Nokta.X + 1, this.Nokta.Y);

            if (TabloIcindeMi(nokta))
            {
                Kutu sagKutu = this.Tablo[this.Nokta.X + 1, this.Nokta.Y];
                return sagKutu == null || sagKutu.Statu == Statuler.INDIRILEN;
            }
            else
            {
                return false;
            }
        }
        public bool SolaGidebilirMi()
        {                 
            Nokta nokta = new Nokta(this.Nokta.X - 1, this.Nokta.Y);

            if (TabloIcindeMi(nokta))
            {
            Kutu solKutu = this.Tablo[this.Nokta.X - 1, this.Nokta.Y];
            return solKutu == null || solKutu.Statu == Statuler.INDIRILEN;
            }
            else
            {
                return false;
            }
        }
        public bool AsagiInebilirMi()
        {            
            Nokta nokta = new Nokta(this.Nokta.X, this.Nokta.Y+1);
            if (TabloIcindeMi(nokta))
            {
                Kutu altKutu = this.Tablo[this.Nokta.X, this.Nokta.Y+1];
                return altKutu == null || altKutu.Statu == Statuler.INDIRILEN;
            }
            else
            {
                return false;
            }
        }
        public void SatirIndir(int satirSayisi)
        {
            int eskiY = this.Nokta.Y;
            this.Nokta.Y += satirSayisi;
            this.PanelKutu.Top += satirSayisi * this.Tablo.KUTU_YUKSEKLIK;
            this.Tablo[this.Nokta.X, this.Nokta.Y] = this;
            this.Tablo[this.Nokta.X, eskiY] = null;
        }
        private bool TasinaBilirMi(int x,int y)
        {
            bool tasinabilirMi = true;
            Nokta nokta = new Nokta(x, y);
            if (!TabloIcindeMi(nokta))
            {
                return false;
            }
            if (Tablo[x, y] != null)
            {
                if (Tablo[x, y].Statu == Statuler.SABIT)
                {
                    tasinabilirMi = false;
                }
            }
            return tasinabilirMi;
        }
        private bool TabloIcindeMi(Nokta nokta)
        {
            return nokta.X >= 0 && nokta.X < this.Tablo.GENISLIK && nokta.Y < Tablo.YUKSEKLIK + Tablo.UST_BOSLUK;
        }        
        private void PanelOlustur(Color color)
        {
            PanelKutu = new Panel();
            PanelKutu.Width = this.Tablo.KUTU_GENISLIK;
            PanelKutu.Height = this.Tablo.KUTU_YUKSEKLIK;
            PanelKutu.BackColor = color;
            PanelKutu.BorderStyle = BorderStyle.FixedSingle;
            PanelKutu.Left = this.Nokta.X * this.Tablo.KUTU_GENISLIK;
            PanelKutu.Top = this.Nokta.Y * this.Tablo.KUTU_YUKSEKLIK - (this.Tablo.UST_BOSLUK * this.Tablo.KUTU_YUKSEKLIK);
        }
        
    }
}
