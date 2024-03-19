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

namespace filmArsiv
{
    public partial class formelestiriler : Form
    {
        public formelestiriler()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost;Database=film_arsiv;Uid=root;Pwd='';";
        void verigetir()
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                baglanti.Open();
                string sorgu = "SELECT filmler.film_ad,\r\nelestiriler.elestiri_metin,\r\nelestiriler.puan,\r\nelestiriler.elestiri_tarihi,\r\nelestiriler.elestirmen\r\nFROM elestiriler\r\nJOIN filmler ON filmler.film_id=elestiriler.elestiri_id;";
                MySqlCommand cmd = new MySqlCommand(sorgu, baglanti);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tablo = new DataTable();

                adapter.Fill(tablo);

                dgvelestiriler.DataSource = tablo;


            }
        }
        private void formelestiriler_Load(object sender, EventArgs e)
        {
            verigetir();
            
        }

       
    }
}
