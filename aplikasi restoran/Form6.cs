using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikasi_restoran
{
    public partial class Form6 : Form
    {
        string database = "server = localhost; database=restoran; uid=root; pwd=''";
        private MySqlConnection koneksi;
        private MySqlDataAdapter adp;
        private MySqlCommand cmd;
        private DataTable dt;

        public Form6()
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

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
