using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikasi_restoran
{
    public partial class Form7 : Form
    {
        string database = "server = localhost; database=restoran; uid=root; pwd=''";
        private MySqlConnection koneksi;
        private MySqlDataAdapter adp;
        private MySqlCommand cmd;
        private DataTable dt;
        public Form7()
        {
            InitializeComponent();
            TampilkanData();
        }
        private void Konek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Open();
        }

        private void Disconek()
        {
            if (koneksi != null && koneksi.State == ConnectionState.Open)
            {
                koneksi.Close();
            }
        }

        private void TampilkanData()
        {
            string sql = "SELECT * FROM user";
            dt = new DataTable();

            try
            {
                Konek();
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Disconek();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string role = comboBox1.Text;

            if (username == "" || password == "" || role == "")
            {
                MessageBox.Show("Semua field harus diisi.");
                return;
            }

            try
            {
                Konek();
                string query = "INSERT INTO user (username, pasword, role) VALUES (@username, @pasword, @role)";
                cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pasword", password);
                cmd.Parameters.AddWithValue("@role", role);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("User berhasil ditambahkan.");
                    TampilkanData();
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan user.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Disconek();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;

            if (username == "")
            {
                MessageBox.Show("Silakan masukkan User Name yang ingin dihapus.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Apakah kamu yakin ingin menghapus user ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Konek();
                    string query = "DELETE FROM user WHERE username = @username";
                    cmd = new MySqlCommand(query, koneksi);
                    cmd.Parameters.AddWithValue("@username", username);
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("User berhasil dihapus.");
                        TampilkanData();
                    }
                    else
                    {
                        MessageBox.Show("User tidak ditemukan.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Disconek();
                }
            }
        }
    }
}
