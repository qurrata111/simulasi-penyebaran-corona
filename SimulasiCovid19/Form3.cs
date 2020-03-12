using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulasiCovid19
{
    public partial class Form3 : Form
    {
        Form1 f1;
        public Form3(Form1 form1)
        {
            InitializeComponent();
            this.f1 = form1;
            this.Text = "Informasi Daerah";
        }

        public void Form3_Load(Form1 form1)
        {
            DataTable d = new DataTable();
            d.Columns.Add("Nama Daerah");
            d.Columns.Add("Berhasil Terinfeksi");
            d.Columns.Add("Daerah Asal Infeksi");
            d.Columns.Add("Populasi Terinfeksi");
            d.Columns.Add("Hari Pertama Terinfeksi");
            String filepath = @"C:\Users\ASUS\source\repos\SimulasiCovid19\SimulasiCovid19\file-external\bfs-queue.csv";
            StreamReader sr = new StreamReader(filepath);
            string[] td = new string[File.ReadAllLines(filepath).Length];
            td = sr.ReadLine().Split(',');
            while (!sr.EndOfStream)
            {
                td = sr.ReadLine().Split(',');
                d.Rows.Add(td[0],td[1],td[2],td[3],td[4]);
            }
            dataGridView1.DataSource = d;
    
        }

        public void Form3_Load1(Form1 form1)
        {
            DataTable d = new DataTable();
            d.Columns.Add("Nama Daerah");
            d.Columns.Add("Berhasil Terinfeksi");
            d.Columns.Add("Daerah Asal Infeksi");
            d.Columns.Add("Populasi Daerah");
            d.Columns.Add("Populasi Terinfeksi");
            d.Columns.Add("Hari Pertama Terinfeksi");
            String filepath = @"C:\Users\ASUS\source\repos\SimulasiCovid19\SimulasiCovid19\file-external\bfs.csv";
            StreamReader sr = new StreamReader(filepath);
            string[] td = new string[File.ReadAllLines(filepath).Length];
            td = sr.ReadLine().Split(',');
            while (!sr.EndOfStream)
            {
                td = sr.ReadLine().Split(',');
                d.Rows.Add(td[0], td[1], td[2], td[3], td[4], td[5]);
            }
            dataGridView1.DataSource = d;
        }
    }
}
