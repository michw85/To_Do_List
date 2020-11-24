using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        //Конструктор
        public Form1()
        {
            InitializeComponent();
        }

        //О Программе
        private void button2_Click(object sender, EventArgs e)
        {
            var a = new AboutBox1();
            a.ShowDialog();
        }
        
        //Просмотр событий
        private void button3_Click(object sender, EventArgs e)
        {
            var f = new MainMenu();
            f.ShowDialog();
        }
       
        //Выход
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
