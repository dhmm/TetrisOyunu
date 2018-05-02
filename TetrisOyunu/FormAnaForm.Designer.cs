namespace TetrisOyunu
{
    partial class FormAnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnaForm));
            this.panel = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPuan = new System.Windows.Forms.Label();
            this.lblSeviye = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlSonraki = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlObjeler = new System.Windows.Forms.Panel();
            this.pnlObjeler.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Black;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(300, 540);
            this.panel.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Interval = 800;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(3, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.ForeColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(3, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seviye";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPuan
            // 
            this.lblPuan.BackColor = System.Drawing.Color.Chocolate;
            this.lblPuan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPuan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPuan.Location = new System.Drawing.Point(3, 268);
            this.lblPuan.Name = "lblPuan";
            this.lblPuan.Size = new System.Drawing.Size(180, 44);
            this.lblPuan.TabIndex = 3;
            this.lblPuan.Text = "0";
            this.lblPuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSeviye
            // 
            this.lblSeviye.BackColor = System.Drawing.Color.Chocolate;
            this.lblSeviye.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblSeviye.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSeviye.Location = new System.Drawing.Point(3, 379);
            this.lblSeviye.Name = "lblSeviye";
            this.lblSeviye.Size = new System.Drawing.Size(180, 44);
            this.lblSeviye.TabIndex = 4;
            this.lblSeviye.Text = "0";
            this.lblSeviye.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.ForeColor = System.Drawing.Color.Cornsilk;
            this.label6.Location = new System.Drawing.Point(3, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sonraki";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSonraki
            // 
            this.pnlSonraki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSonraki.Location = new System.Drawing.Point(3, 33);
            this.pnlSonraki.Name = "pnlSonraki";
            this.pnlSonraki.Size = new System.Drawing.Size(180, 180);
            this.pnlSonraki.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Yardim icin F1 e basin";
            // 
            // pnlObjeler
            // 
            this.pnlObjeler.Controls.Add(this.label6);
            this.pnlObjeler.Controls.Add(this.label3);
            this.pnlObjeler.Controls.Add(this.label1);
            this.pnlObjeler.Controls.Add(this.pnlSonraki);
            this.pnlObjeler.Controls.Add(this.label2);
            this.pnlObjeler.Controls.Add(this.lblPuan);
            this.pnlObjeler.Controls.Add(this.lblSeviye);
            this.pnlObjeler.Location = new System.Drawing.Point(327, 12);
            this.pnlObjeler.Name = "pnlObjeler";
            this.pnlObjeler.Size = new System.Drawing.Size(190, 540);
            this.pnlObjeler.TabIndex = 9;
            // 
            // FormAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 568);
            this.Controls.Add(this.pnlObjeler);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris Oyunu v 0.2";
            this.Load += new System.EventHandler(this.FormAnaForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAnaForm_KeyDown);
            this.pnlObjeler.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPuan;
        private System.Windows.Forms.Label lblSeviye;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlSonraki;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlObjeler;
    }
}

