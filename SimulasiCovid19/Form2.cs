﻿using System;
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

            //InitializeComponent(info.infected_daerah);
            InitializeComponent();
            this.f1 = form1;
            this.Text = "Graf Daerah";
        }

        public void Form2_Load(Form1 form1)
        {
            string file_keterhubungan = f1.textBox2.Text;
            string file_populasi = f1.textBox1.Text;
            string str = f1.inputBox.Text;
            int hari = Int32.Parse(str);
            Info info = new Info(hari, file_keterhubungan, file_populasi);
            info.writeBFSIntoCSV();

            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object
            Daerah child = new Daerah();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("Graf");
            foreach (Daerah parent in info.infected_daerah)
            {
                foreach (KeyValuePair<string, float> anak in parent.daerah_tetangga)
                {
                    // jika anak terinfeksi dan asalnya dari daerah maka beri warna
                    // cari nama anak di info.infected_daerah
                    foreach (Daerah daerah in info.infected_daerah)
                    {
                        if (anak.Key == daerah.nama)
                        {
                            child = daerah;
                        }
                    }
                    // jika child terinfeksi dan asalnya dari parent maka beri warna
                    if (child.is_infected)
                    {
                        if ((child.infected_from == parent.nama))
                        {
                            graph.AddEdge(parent.nama, child.nama).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        }
                        else
                        {
                            graph.AddEdge(parent.nama, anak.Key);
                        }
                    }
                    else
                    {
                        graph.AddEdge(parent.nama, anak.Key);
                    }
                }
            }
            // mewarnai node
            foreach (Daerah daerah in info.infected_daerah)
            {
                if (daerah.is_infected)
                {
                    graph.FindNode(daerah.nama).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                }
                else
                {
                    graph.FindNode(daerah.nama).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Gray;
                }
            }
            viewer.Graph = graph;
            //associate the viewer with the form 
            this.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}