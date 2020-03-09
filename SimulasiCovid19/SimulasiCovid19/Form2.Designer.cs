using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulasiCovid19
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(List<Daerah> list_daerah)
        {
            //this.components = new System.ComponentModel.Container();
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(800, 450);
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            form.Size = new System.Drawing.Size(800, 450);
            form.Text = "Graf";

            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object
            Daerah child = new Daerah();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("Graf");
            foreach (Daerah parent in list_daerah)
            {
                foreach (KeyValuePair<string, float> anak in parent.daerah_tetangga)
                {
                    // jika anak terinfeksi dan asalnya dari daerah maka beri warna
                    // cari nama anak di list_daerah
                    foreach (Daerah daerah in list_daerah)
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
                        } else
                        {
                            graph.AddEdge(parent.nama, anak.Key);
                        }
                    } else
                    {
                        graph.AddEdge(parent.nama, anak.Key);
                    }
                }
            }
            // mewarnai node
            foreach (Daerah daerah in list_daerah)
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
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            //show the form 
            form.ShowDialog();


        }

        #endregion
    }

}