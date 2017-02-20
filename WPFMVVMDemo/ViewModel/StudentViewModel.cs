using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
