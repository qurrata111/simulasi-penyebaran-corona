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
            string line, line3, daerah_terinfeksi = "";
            List<Daerah> list_daerah = new List<Daerah>();
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file =   
            new System.IO.StreamReader(@"/Users/r4r4s274/Documents/RARAS/TUBES/simulasi-penyebaran-corona/populasi-daerah.txt");  
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

            counter = 0;
            System.IO.StreamReader file1 =   
            new System.IO.StreamReader(@"/Users/r4r4s274/Documents/RARAS/TUBES/simulasi-penyebaran-coronadaerah-dan-keterhubungan.txt");  
            while((line3 = file1.ReadLine()) != null)  
            {
                System.Console.WriteLine(line3);  
                counter++; 
                if (counter > 1) {
                    string[] line4 = line3.Split(' ');
                    int i = 0;
                        int a = 0;
                        bool found = false;
                        while (a < list_daerah.Count && !found){
                            if (list_daerah[a].nama_daerah == line4[i]){
                                found = true;
                            }
                            else{
                                a +=1;
                            }
                        }
                        Daerah daerah_temp = list_daerah[a];
                        // Daerah child = new Daerah();
                        // if (i==0) {
                            // child.setNamaDaerah(line4[i+1]);
                            // System.Console.WriteLine("{0}", line4[i+1]);
                            daerah_temp.addChildren(line4[i+1], float.Parse(line4[i+2]));
                        // }
                    // }
                }
            }  

            file1.Close();
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
        public Dictionary<string, float> daerah_tetangga;
        public int jumlah_tetangga = 0;

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
            foreach ( KeyValuePair<string, float> kvp in daerah_tetangga){
                System.Console.WriteLine("Nama tetangga                 : {0}", kvp.Key);
                System.Console.WriteLine("Peluang melakukan perjalanan  : {0}", kvp.Value);
            }
            System.Console.WriteLine("Jumlah tetangga               : {0}", jumlah_tetangga);
        }

        public void addChildren(string child, float n){
            daerah_tetangga.Add(child, n);
            jumlah_tetangga +=1;
        }
    }
}
