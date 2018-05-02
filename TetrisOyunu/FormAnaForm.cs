using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TetrisOyunu.Kutuphane;

namespace TetrisOyunu
{
    public partial class FormAnaForm : Form
    {
        Oyun Oyun { set; get; }
        public FormAnaForm()
        {
            InitializeComponent();
        }
        private void FormAnaForm_Load(object sender, EventArgs e)
        {
            Oyun = new Oyun(panel, timer,lblPuan,lblSeviye,pnlSonraki);
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
