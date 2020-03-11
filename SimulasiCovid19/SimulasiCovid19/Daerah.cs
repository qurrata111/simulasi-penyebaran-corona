using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulasiCovid19
{
    public class Daerah
    {
        public string nama, infected_from;
        public int populasi, populasi_terinfeksi, first_day_infected, total_hari;
        public Boolean is_infected;
        public SortedList<string, float> daerah_tetangga;
        public int jumlah_tetangga = 0;

        public Daerah()
        {
            nama = "";
            infected_from = "";
            populasi = 0;
            populasi_terinfeksi = 0;
            first_day_infected = (int)Math.Pow(10, 10);
            total_hari = 0;
            is_infected = false;
            daerah_tetangga = new SortedList<string, float>();
        }
        public Daerah(string nd, int p, int pt, int fd, int th, Boolean ii)
        {
            nama = nd;
            populasi = p;
            populasi_terinfeksi = pt;
            first_day_infected = fd;
            total_hari = th;
            is_infected = ii;
        }

        public void setNamaDaerah(string n)
        {
            nama = n;
        }

        public void setPopulasi(int p)
        {
            populasi = p;
        }
        public void setPopulasiTerinfeksi(int pt)
        {
            populasi_terinfeksi = pt;
        }
        public void setFirstDayInfected(int fi)
        {
            first_day_infected = fi;
        }
        public void setTotalHari(int th)
        {
            total_hari = th;
        }
        public void setIsInfected(Boolean ii)
        {
            is_infected = ii;
        }
        public void setInfectedFrom(string nm)
        {
            infected_from = nm;
        }
        public void printInfo()
        {
            System.Console.WriteLine("Nama daerah                   : {0}", nama);
            System.Console.WriteLine("Populasi                      : {0}", populasi);
            System.Console.WriteLine("Populasi terinfeksi           : {0}", populasi_terinfeksi);
            System.Console.WriteLine("Hari pertama terinfeksi       : {0}", first_day_infected);
            System.Console.WriteLine("Total hari terinfeksi         : {0}", total_hari);
            System.Console.WriteLine("Apakah terinfeksi             : {0}", is_infected);
            System.Console.WriteLine("Terinfeksi dari               : {0}", infected_from);
            foreach (KeyValuePair<string, float> kvp in daerah_tetangga)
            {
                System.Console.WriteLine("Nama tetangga                 : {0}", kvp.Key);
                System.Console.WriteLine("Peluang melakukan perjalanan  : {0}", kvp.Value);
            }
            System.Console.WriteLine("Jumlah tetangga               : {0}", jumlah_tetangga);
        }

        

        public void addChildren(string child, float n)
        {
            daerah_tetangga.Add(child, n);
            jumlah_tetangga += 1;
        }

        public void count_populasiTerinfeksi()
        {
            double total = (double)total_hari / (double)4;
            populasi_terinfeksi = populasi / (int)(1 + ((populasi - 1) * Math.Pow(Math.E, -(total))));
        }

        public Boolean berhasil_terinfeksi(double peluang)
        {
            count_populasiTerinfeksi();
            return ((populasi_terinfeksi * peluang) >= 1);
        }
    }

    public class Info
    {
        public List<Daerah> init_daerah;
        public List<Daerah> infected_daerah;
        
        public Info(int hari)
        {
            init_daerah = getInfoDaerah();
            infected_daerah = findInfectedDaerah(hari);
           
        }

        public void writeBFSIntoCSV()
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\ASUS\source\repos\SimulasiCovid19\SimulasiCovid19\file-external\bfs.csv"))
            {
                file.WriteLine("Nama Daerah,Berhasil Terinfeksi,Daerah Asal Infeksi,Populasi,Populasi Terinfeksi,Hari Pertama Terinfeksi");
                foreach (Daerah d in infected_daerah)
                {
                    string line = "";
                    for (int i = 1; i < 7; i++) {
                        if (i==1)
                        {
                            line += d.nama + ",";
                        } else if (i==2)
                        {
                            if (d.is_infected)
                            {
                                line += "Berhasil,";
                            }
                            else
                            {
                                line += "Tidak Berhasil,";
                            }
                        } else if (i==3)
                        {
                            if (d.is_infected)
                            {
                                line += d.infected_from + ",";
                            }
                            else
                            {
                                line += "Tidak Berhasil,";
                            }
                        } else if (i == 4)
                        {
                            line += d.populasi + ",";
                        } else if (i== 5)
                        {
                            line += d.populasi_terinfeksi + ",";
                        } else if (i==6)
                        {
                            if (d.is_infected)
                            {
                                line += d.first_day_infected;
                            }
                            else
                            {
                                line += "-";
                            }
                        }
                    }
                    file.WriteLine(line);   
                }
            }
        }

        static public List<Daerah> getInfoDaerah()
        {
            int counter = 0, numOfDaerah = 0;
            string line, line3, daerah_terinfeksi = "";
            List<Daerah> list_daerah = new List<Daerah>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"C:\Users\ASUS\source\repos\SimulasiCovid19\SimulasiCovid19\file-external\populasi-daerah.txt");
            while ((line = file.ReadLine()) != null)
            {
                counter++;
                if (counter == 1)
                {
                    string[] line1 = line.Split(' ');
                    for (int i = 0; i < line1.Length; i++)
                    {
                        if (i == 0)
                        {
                            numOfDaerah = Int32.Parse(line1[i]);
                        }
                        else if (i == 1)
                        {
                            daerah_terinfeksi = line1[i];
                        }
                    }
                }
                else if (counter > 1)
                {
                    string[] line2 = line.Split(' ');
                    for (int i = 0; i < line2.Length; i++)
                    {
                        Daerah daerah_temp = new Daerah();
                        if (i == 0)
                        {
                            daerah_temp.setNamaDaerah(line2[i]);
                            daerah_temp.setPopulasi(Int32.Parse(line2[i + 1]));
                            daerah_temp.setFirstDayInfected(100000000);
                            list_daerah.Add(daerah_temp);
                        }
                    }
                }
            }

            counter = 0;
            System.IO.StreamReader file1 =
            new System.IO.StreamReader(@"C:\Users\ASUS\source\repos\SimulasiCovid19\SimulasiCovid19\file-external\daerah-dan-keterhubungan.txt");
            while ((line3 = file1.ReadLine()) != null)
            {
                counter++;
                if (counter > 1)
                {
                    string[] line4 = line3.Split(' ');
                    int i = 0;
                    int a = 0;
                    bool found = false;
                    while (a < list_daerah.Count && !found)
                    {
                        if (list_daerah[a].nama == line4[i])
                        {
                            found = true;
                        }
                        else
                        {
                            a += 1;
                        }
                    }
                    Daerah daerah_temp = list_daerah[a];
                    daerah_temp.addChildren(line4[i + 1], float.Parse(line4[i + 2]));
                }
            }

            file1.Close();
            file.Close();
            // System.Console.WriteLine("There were {0} lines.", counter);
            System.Console.WriteLine("Ada {0} daerah", numOfDaerah);
            System.Console.WriteLine("Daerah yang pertama kali diinfeksi {0}", daerah_terinfeksi);
            foreach (Daerah daerah in list_daerah)
            {
                if (daerah_terinfeksi == daerah.nama)
                {
                    daerah.setIsInfected(true);
                }
            }
            return list_daerah;
        }

        static public List<Daerah> findInfectedDaerah(int jumlahHari)
        {
            List<Daerah> list_daerah = new List<Daerah>();
            Queue<string> sumber = new Queue<string>();
            Queue<String> tujuan = new Queue<String>();
            Queue<float> peluang_travel = new Queue<float>();

            // BACA FILE
            list_daerah = getInfoDaerah();
            foreach (Daerah daerah in list_daerah)
            {
                System.Console.WriteLine();
                daerah.printInfo();
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\ASUS\source\repos\SimulasiCovid19\SimulasiCovid19\bfs-queue.csv"))
            {
                file.WriteLine("Nama Daerah,Berhasil Terinfeksi,Daerah Asal Infeksi,Populasi Terinfeksi,Hari Pertama Terinfeksi");
                string line = "";

                // INISIASI QUEUE PERTAMA
                Daerah first_daerah = new Daerah();
                string first;
                foreach (Daerah daerah in list_daerah)
                {
                    if (daerah.is_infected)
                    {
                        first_daerah = daerah;
                    }
                }

                first = first_daerah.nama;
                int i = find_index(list_daerah, first);
                list_daerah[i].setFirstDayInfected(0);
                list_daerah[i].setTotalHari(jumlahHari - list_daerah[i].first_day_infected);

                foreach (KeyValuePair<string, float> kvp in list_daerah[i].daerah_tetangga)
                {
                    sumber.Enqueue(list_daerah[i].nama);
                    tujuan.Enqueue(kvp.Key);
                    peluang_travel.Enqueue(kvp.Value);
                }

                // LOOPING
                while (tujuan.Count() > 0)
                {
                    line = "";
                    string c_sumber = sumber.Dequeue();
                    string c_tujuan = tujuan.Dequeue();
                    float c_peluang_travel = peluang_travel.Dequeue();

                    int s = find_index(list_daerah, c_sumber);
                    int t = find_index(list_daerah, c_tujuan);

                    // MENGECEK APAKAH BERHASIL TERINFEKSI/TIDAK
                    if (list_daerah[s].berhasil_terinfeksi(c_peluang_travel) == true)
                    {
                        list_daerah[t].setIsInfected(true);
                        list_daerah[t].setInfectedFrom(list_daerah[s].nama);
                        double p = list_daerah[s].populasi;
                        double tr = c_peluang_travel;
                        double day = -4 * (1 / Math.Log(Math.E, (p * tr - 1) / (p - 1))) + 1;

                        int first_day_new = (int)day + list_daerah[s].first_day_infected;
                        System.Console.WriteLine("first_day_new {0}", first_day_new);
                        System.Console.WriteLine("first_day_old {0}", list_daerah[t].first_day_infected);

                        // ANAK DARI NODE AKAN DIMASUKKAN KE QUEUE APABILA FIRST DAY INFECTED LEBIH KECIL DARI YANG LAMA
                        if (first_day_new < list_daerah[t].first_day_infected)
                        {
                            list_daerah[t].setFirstDayInfected(first_day_new);
                            list_daerah[t].setTotalHari(jumlahHari - list_daerah[t].first_day_infected);
                            System.Console.WriteLine("day pertama {0} terinfeksi = {1}", list_daerah[t].nama, list_daerah[t].first_day_infected);
                            foreach (KeyValuePair<string, float> kvp in list_daerah[t].daerah_tetangga)
                            {
                                sumber.Enqueue(list_daerah[t].nama);
                                tujuan.Enqueue(kvp.Key);
                                peluang_travel.Enqueue(kvp.Value);
                            }
                        }
                    }
                    line += list_daerah[t].nama + ",";
                    if (list_daerah[t].is_infected)
                    {
                        line += "Berhasil" + ",";
                    }
                    else
                    {
                        line += "Tidak Berhasil" + ",";
                    }
                    line += list_daerah[t].infected_from + ",";
                    line += list_daerah[t].populasi_terinfeksi + ",";
                    if (list_daerah[t].is_infected)
                    {
                        line += list_daerah[t].first_day_infected + "";
                    }
                    else
                    {
                        line += "-";
                    }
                    file.WriteLine(line);
                }
            }
            return list_daerah;
        }
        public static int find_index(List<Daerah> list_daerah, string a)
        {
            int i = 0;
            Boolean found = false;
            while (i < list_daerah.Count && !found)
            {
                if (a == list_daerah[i].nama)
                {
                    found = true;
                }
                else
                {
                    i += 1;
                }
            }
            return i;
        }


    }

}
