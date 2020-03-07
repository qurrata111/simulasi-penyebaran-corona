using System;
using System.Collections.Generic;
using System.Linq;

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
                            daerah_temp.setPopulasi(Int32.Parse(line2[i+1]));
                            list_daerah.Add(daerah_temp);
                        }
                    }
                }
            }  
            
            file.Close();  
            System.Console.WriteLine("There were {0} lines.", counter);
            System.Console.WriteLine("Ada {0} daerah", numOfDaerah);
            System.Console.WriteLine("Daerah yang pertama kali diinfeksi {0}", daerah_terinfeksi);
            foreach (Daerah daerah in list_daerah) {
                if (daerah_terinfeksi == daerah.nama) {
                    daerah.setIsInfected(true);
                }
                daerah.printInfo();
            }
            
        }
    }



    public class Daerah {
        public string nama;
        public int populasi, populasi_terinfeksi, first_day_infected, total_hari;
        public Boolean is_infected;
        public Daerah() {
            nama = "";
            populasi = 0;
            populasi_terinfeksi = 0;
            first_day_infected = 0;
            total_hari = 0;
            is_infected = false;
        }
        public Daerah(string nd, int p, int pt, int fd, int th, Boolean ii) {
            nama = nd;
            populasi = p;
            populasi_terinfeksi = pt;
            first_day_infected = fd;
            total_hari = th;
            is_infected = ii;
        }

        public void setNamaDaerah(string n) {
            nama = n;
        }

        public void setPopulasi(int p) {
            populasi = p;
        }
        public void setPopulasiTerinfeksi(int pt) {
            populasi_terinfeksi = pt;
        }
        public void setFirstDayInfected (int fi) {
            first_day_infected = fi;
        }
        public void setTotalHari (int th) {
            total_hari = th;
        }
        public void setIsInfected (Boolean ii) {
            is_infected = ii;
        }

        public void printInfo() {
            System.Console.WriteLine("Nama daerah               : {0}", nama);
            System.Console.WriteLine("Populasi                  : {0}", populasi);
            System.Console.WriteLine("Populasi terinfeksi       : {0}", populasi_terinfeksi);
            System.Console.WriteLine("Hari pertama terinfeksi   : {0}", first_day_infected);
            System.Console.WriteLine("Total hari terinfeksi     : {0}", total_hari);
            System.Console.WriteLine("Apakah terinfeksi         : {0}", is_infected);
        }
    }
}
