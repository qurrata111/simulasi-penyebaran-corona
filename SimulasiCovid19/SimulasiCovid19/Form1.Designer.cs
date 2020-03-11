namespace SimulasiCovid19
{
    partial class Form1
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
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.button1.Location = new System.Drawing.Point(261, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Check Graf";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Simulasi Penyebaran Covid-19";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(261, 167);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(261, 20);
            this.inputBox.TabIndex = 2;
            this.inputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 11F);
            this.label2.Location = new System.Drawing.Point(341, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Masukkan Hari";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.button2.Location = new System.Drawing.Point(261, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(261, 48);
            this.button2.TabIndex = 4;
            this.button2.Text = "Check Informasi Daerah";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.button3.Location = new System.Drawing.Point(261, 333);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(261, 48);
            this.button3.TabIndex = 5;
            this.button3.Text = "Check Informasi Akhir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox inputBox;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

/*
DataTable d = new DataTable();
String filepath = "C:\\Users\\ASUS\\source\\repos\\SimulasiCovid19\\SimulasiCovid19\\bfs.csv";
StreamReader sr = new StreamReader(filepath);
string[] td = new string[File.ReadAllLines(filepath).Length];
td = sr.ReadLine().Split(',');
while (!sr.EndOfStream)
{
    td = sr.ReadLine().Split(',');
    d.Rows.Add(td[0], td[1], td[2], td[3], td[4], td[5]);
}
dataGridView1.DataSource = d;
*/

