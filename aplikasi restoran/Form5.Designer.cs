namespace aplikasi_restoran
{
    partial class Form5
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            button3 = new Button();
            button4 = new Button();
            dateTimePicker1 = new DateTimePicker();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            lihatToolStripMenuItem = new ToolStripMenuItem();
            cariToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            kembaliToolStripMenuItem = new ToolStripMenuItem();
            keluarAplikasiToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(71, 137);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1053, 304);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Cursor = Cursors.AppStarting;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(859, 464);
            button1.Name = "button1";
            button1.Size = new Size(201, 67);
            button1.TabIndex = 1;
            button1.Text = "Kembali";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 255, 128);
            button2.Cursor = Cursors.AppStarting;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(135, 464);
            button2.Name = "button2";
            button2.Size = new Size(201, 67);
            button2.TabIndex = 2;
            button2.Text = "Lihat";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(403, 37);
            label1.Name = "label1";
            label1.Size = new Size(386, 54);
            label1.TabIndex = 3;
            label1.Text = "LAPORAN PENJUALAN";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 128, 128);
            button3.Cursor = Cursors.AppStarting;
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(619, 464);
            button3.Name = "button3";
            button3.Size = new Size(201, 67);
            button3.TabIndex = 4;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 192, 128);
            button4.Cursor = Cursors.AppStarting;
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(379, 464);
            button4.Name = "button4";
            button4.Size = new Size(201, 67);
            button4.TabIndex = 5;
            button4.Text = "Cari";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Cursor = Cursors.AppStarting;
            dateTimePicker1.Location = new Point(474, 94);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 6;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, keluarAplikasiToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1182, 28);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { lihatToolStripMenuItem, cariToolStripMenuItem, deleteToolStripMenuItem, kembaliToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(170, 24);
            toolStripMenuItem1.Text = "Informasi Penggunaan";
            // 
            // lihatToolStripMenuItem
            // 
            lihatToolStripMenuItem.Name = "lihatToolStripMenuItem";
            lihatToolStripMenuItem.Size = new Size(147, 26);
            lihatToolStripMenuItem.Text = "Lihat";
            lihatToolStripMenuItem.Click += lihatToolStripMenuItem_Click;
            // 
            // cariToolStripMenuItem
            // 
            cariToolStripMenuItem.Name = "cariToolStripMenuItem";
            cariToolStripMenuItem.Size = new Size(147, 26);
            cariToolStripMenuItem.Text = "Cari";
            cariToolStripMenuItem.Click += cariToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(147, 26);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // kembaliToolStripMenuItem
            // 
            kembaliToolStripMenuItem.Name = "kembaliToolStripMenuItem";
            kembaliToolStripMenuItem.Size = new Size(147, 26);
            kembaliToolStripMenuItem.Text = "Kembali";
            kembaliToolStripMenuItem.Click += kembaliToolStripMenuItem_Click;
            // 
            // keluarAplikasiToolStripMenuItem
            // 
            keluarAplikasiToolStripMenuItem.Name = "keluarAplikasiToolStripMenuItem";
            keluarAplikasiToolStripMenuItem.Size = new Size(121, 24);
            keluarAplikasiToolStripMenuItem.Text = "Keluar Aplikasi";
            keluarAplikasiToolStripMenuItem.Click += keluarAplikasiToolStripMenuItem_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 128, 255);
            ClientSize = new Size(1182, 570);
            Controls.Add(dateTimePicker1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form5";
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Label label1;
        private Button button3;
        private Button button4;
        private DateTimePicker dateTimePicker1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem lihatToolStripMenuItem;
        private ToolStripMenuItem cariToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem kembaliToolStripMenuItem;
        private ToolStripMenuItem keluarAplikasiToolStripMenuItem;
    }
}