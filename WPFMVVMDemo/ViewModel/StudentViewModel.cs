using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WPFMVVMDemo.Model;

namespace WPFMVVMDemo.ViewModel
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }
        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            //lisätään esimerkin vuoksi muutama opiskelija, oikeassa sovelluksessa tulisivat vaikka tietokannasta
            students.Add(new Student { FirstName = "Kalle", LastName = "Jalkanen", AsioId="1234543" });
            students.Add(new Student { FirstName = "Teppo", LastName = "Testaaja", AsioId = "rewqwerewq" });
            students.Add(new Student { FirstName = "Tomi", LastName = "Töttersätänst", AsioId = "fdsasdfdwsa" });
            students.Add(new Student { FirstName = "Anni", LastName = "Anjolkainen", AsioId = "bvcdzxcv" });
            Students = students;
        }
        //metodi StudentViewModeliin jolla haetaan oppilastiedot mysql-palvemilta
        public void LoadStudentsFromMysql()
        {
            try
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                //luodaan yhteys labranetin mysql-palvelimelle
                string connStr = GetMysqlConnectionString();
                string sql = "SELECT firstname, lastname, asioid FROM student";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WPFMVVMDemo.Model.Student s = new Model.Student();
                            s.FirstName = reader.GetString(0);
                            s.LastName = reader.GetString(1);
                            s.AsioId = reader.GetString(2);
                            students.Add(s);
                        }
                        Students = students;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private string GetMysqlConnectionString()
        {
            string pw = WPFMVVMDemo.Properties.Settings.Default.passu;
            //haetaan salasana App.Config-tiedostosta  ^
            //initial catalog == tietokannan nimi  v
            return string.Format("Data source=mysql.labranet.jamk.fi; Initial Catalog=K8721; user=K8721; password={0}", pw);
        }
    }
}
