using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BicycleRoute
{
    public partial class DataDefender : Form
    {
        public DataDefender()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "1537")
            {
                BicycleRouteEntities2 br = new BicycleRouteEntities2();
                var delete_all = from c in br.Data select c;
                br.Data.RemoveRange(delete_all);
                br.SaveChanges();
                MessageBox.Show("Данные удалены!");
            }
            else
                MessageBox.Show("Неправильный код.");
            textBox1.Clear();
        }
    }
}
