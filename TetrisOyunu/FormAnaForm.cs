using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TetrisOyunu.Kutuphane;
using System.Media;

namespace TetrisOyunu
{
    public partial class FormAnaForm : Form
    {
        Oyun Oyun { set; get; }
        SoundPlayer muzikOynatici = new SoundPlayer("tetris_original.wav");
        public FormAnaForm()
        {
            InitializeComponent();
        }
        private void FormAnaForm_Load(object sender, EventArgs e)
        {
            muzikOynatici.PlayLooping();
            Oyun = new Oyun(panel, timer,lblPuan,lblSeviye,pnlSonraki);
            try
            {
                this.panel.Width = 30 * 10;
                this.panel.Height = 30 * 18;
                int w = this.panel.Left + this.panel.Width;
                this.pnlObjeler.Left = w + 20;
                w += 30;
                w += this.pnlObjeler.Width;
                this.Width = w + 20;
                this.Height = this.panel.Top+this.panel.Height + 40;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void FormAnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                timer.Stop();
                FormYardim form = new FormYardim();
                form.ShowDialog();
                timer.Start();
            }
            else
            {
                Oyun.TusOku(e);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Oyun.Indir();
        }

       

       
    }
}
