using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BicycleRoute
{
    public partial class EnterData : Form
    {
        public EnterData()
        {
            InitializeComponent();
        }

        DateTime today = DateTime.Now;
        string stToday;
        int intToday;
        string stDate;
        int intDate;
        Regex rx = new Regex(@"^\d{2}|^\d"); // RegEx для поиска дня в дате вида dd-MM-yyyy|d-MM-yyyy
        //public System.Windows.Forms.DataVisualization.Charting.Chart char1; // Должно было обновлять гравик
        BicycleRouteEntities2 br = new BicycleRouteEntities2();
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            MainScreen ms = new MainScreen();
            Data data = new Data(); // Таблица из бд BicycleRoute
            data.Id = Guid.NewGuid(); // Id
            data.Distance = Convert.ToInt32(textBox1.Text); //Distance
            data.Date = dateTimePicker1.Text; // Date
            stDate = data.Date; // Строковая дата, для перевода в число
            stToday = DateTime.Now.ToString(); // Строковая дата текущего дня для перевода в число
            if (rx.IsMatch(stToday))
            {
                Match match = rx.Match(stToday);
                stToday = match.ToString();
                intToday = Convert.ToInt32(stToday);
            }
            
            if (rx.IsMatch(stDate))
            {
                Match match = rx.Match(stDate);
                stDate = match.ToString();
                intDate = Convert.ToInt32(stDate);
                if (intDate < intToday)
                {
                    textBox1.Clear();
                    MessageBox.Show("День прошёл! Данные не были сохранены.");
                }
                else
                {
                    br.Data.Add(data);
                    br.SaveChanges();
                    //char1.Update(); // Должно было обновлять график
                    textBox1.Clear();
                    MessageBox.Show("Новое значение добавлено!");
                }
            }
            
        }

        private void EnterData_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }
    }
}
