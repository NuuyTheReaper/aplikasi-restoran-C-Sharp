using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace aplikasi_restoran
{
    public partial class Form1 : Form
    {
        private MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            string connString = "server=localhost;database=restoran;uid=root;pwd=;";
            conn = new MySqlConnection(connString);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text.Trim();
            string pasword = textBox2.Text.Trim();

            if (LoginUser(username, pasword, out string role))
            {
                MessageBox.Show($"Login berhasil sebagai {role}!", "Sukses", MessageBoxButtons.OK);

                if (role == "admin")
                {
                    Form3 adminForm = new Form3();
                    adminForm.Show();
                }
                else if (role == "pelanggan")
                {
                    Form2 pelangganForm = new Form2();
                    pelangganForm.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau pasword salah.", "Gagal", MessageBoxButtons.OK);
            }
        }
        private bool LoginUser(string username, string pasword, out string role)
        {
            try
            {
                conn.Open();
                string query = "SELECT role FROM user WHERE username = @username AND pasword = @pasword";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pasword", pasword);

                object result = cmd.ExecuteScalar();
                role = result?.ToString();

                return result != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                role = null;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Mengosongkan input
            textBox1.Clear();
            textBox2.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 informasi = new Form6();
            informasi.Show();
        }

        private void infoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult pilih = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (pilih == DialogResult.Yes)
            {
                MessageBox.Show("Terimakasih telah menggunakan aplikasi restoran kami", "keluar");
                Application.Exit();
            }
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 adduser = new Form7();
            adduser.Show();
            Hide();
        }
    }
}
