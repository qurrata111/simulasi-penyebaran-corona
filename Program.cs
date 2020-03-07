using System;
using System.Collections.Generic;

namespace simulasi_penyebaran_covid_19
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0, numOfDaerah = 0;
            string line, daerah_terinfeksi = "";
            List<Daerah> list_daerah = new List<Daerah>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file =   
            new System.IO.StreamReader(@"/media/qurrata111/Data/QA/kuliah/sems 4/stima/stima/tubes-2/simulasi-penyebaran-covid-19/populasi-daerah.txt");  
            while((line = file.ReadLine()) != null)  
            {  
                System.Console.WriteLine(line);  
                counter++; 
                if (counter == 1) {
                    string[] line1 = line.Split(' ');
                    for (int i=0; i<line1.Length; i++) {
                        if (i==0) {
                            numOfDaerah = Int32.Parse(line1[i]);
                        } else if (i==1) {
                            daerah_terinfeksi = line1[i];
                        }
                    }
                } else if (counter > 1) {
                    string[] line2 = line.Split(' ');
                    for (int i=0; i<line2.Length; i++) {
                        Daerah daerah_temp = new Daerah();
                        if (i==0) {
                            daerah_temp.setNamaDaerah(line2[i]);
                            daerah_temp.setPopulasiDaerah(Int32.Parse(line2[i+1]));
                            list_daerah.Add(daerah_temp);
                        }
                    }
                }
            }  
            
            file.Close();  
            System.Console.WriteLine("There were {0} lines.", counter);
            System.Console.WriteLine("Ada {0} daerah", numOfDaerah);
            System.Console.WriteLine("Daerah yang pertama kali diinfeksi {0}", daerah_terinfeksi);
            foreach (Daerah daerah in list_daerah)
            {
                daerah.printInfo();
            }
        }
    }

    public class Daerah {
        public string nama_daerah;
        public int populasi_daerah;
        public Daerah() {
            nama_daerah = ""; populasi_daerah = 0;
        }
        public Daerah(string nd, int pd) {
            nama_daerah = nd; populasi_daerah = pd;
        }

        public void setNamaDaerah(string nama) {
            nama_daerah = nama;
        }

        public void setPopulasiDaerah(int populasi) {
            populasi_daerah = populasi;
        }

        public void printInfo() {
            System.Console.WriteLine("Nama daerah    : {0}", nama_daerah);
            System.Console.WriteLine("Populasi daerah: {0}", populasi_daerah);
        }
    }
}
