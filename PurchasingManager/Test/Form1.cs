using Dapper;
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

namespace Test
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             IDbConnection connection = new MySqlConnection("Data Source=localhost;Database=dulieuthumua;UID=root;Password=100100" +
                 "; Min Pool Size=0;Max Pool Size=1000;Pooling=true; Connect Timeout=65535;");

            var _res =  connection.Query<AcountModel>("select * from useraccount");
        }
    }
}
