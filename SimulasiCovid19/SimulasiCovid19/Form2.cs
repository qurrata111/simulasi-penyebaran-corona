using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulasiCovid19
{
    public partial class Form2 : Form
    {
        Form1 f1;
        public Form2(Form1 form1)
        {
            string str = form1.inputBox.Text;
            int hari = Int32.Parse(str);
            Info info = new Info(hari);
            InitializeComponent(info.infected_daerah);
            this.f1 = form1;
        }
    }
}
