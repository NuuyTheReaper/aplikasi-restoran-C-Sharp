namespace aplikasi_restoran
{
    partial class Form3
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 255, 128);
            button1.Cursor = Cursors.AppStarting;
            button1.Font = new Font("Segoe Print", 24F, FontStyle.Bold | FontStyle.Italic);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(122, 107);
            button1.Name = "button1";
            button1.Size = new Size(443, 202);
            button1.TabIndex = 0;
            button1.Text = "Tambah Menu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 192, 128);
            button2.Cursor = Cursors.AppStarting;
            button2.Font = new Font("Segoe Print", 24F, FontStyle.Bold | FontStyle.Italic);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(626, 107);
            button2.Name = "button2";
            button2.Size = new Size(443, 202);
            button2.TabIndex = 1;
            button2.Text = "Laporan Penjualan";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 128, 128);
            button3.Cursor = Cursors.AppStarting;
            button3.Font = new Font("Segoe Print", 24F, FontStyle.Bold | FontStyle.Italic);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(378, 352);
            button3.Name = "button3";
            button3.Size = new Size(443, 202);
            button3.TabIndex = 2;
            button3.Text = "Keluar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 128, 255);
            ClientSize = new Size(1182, 603);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form3";
            Text = "Pilihan Admin";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
    }
}