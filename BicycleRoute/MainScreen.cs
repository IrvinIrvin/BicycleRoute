using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;

namespace BicycleRoute
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }
        List<string[]> used = new List<string[]>();
        private void button1_Click(object sender, EventArgs e)
        {
            EnterData ed = new EnterData();
            ed.Show();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bicycleRouteDataSet.Data". При необходимости она может быть перемещена или удалена.
            this.dataTableAdapter.Fill(this.bicycleRouteDataSet.Data);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            string connectString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BicycleRoute;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(connectString);
            myConnection.Open();
            string query = "SELECT Distance, Date FROM Data";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }
            reader.Close();
            myConnection.Close();
            foreach (string[] s in data)
            {
                chart1.Series[0].Points.AddXY(s[1], s[0]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataDefender dd = new DataDefender();
            dd.Show();
        }
    }
}
