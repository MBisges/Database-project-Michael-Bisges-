using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<PersonModel> people = new List<PersonModel>();
        public MainWindow()
        {
            InitializeComponent();
            LoadPeopleList();
        }

        private void LoadPeopleList()
        {
            people = SqliteDataAccess.LoadPeople();

            WireUpPeopleList();
        }
        private void WireUpPeopleList()
        {
            foreach(PersonModel p in people)
            {
                persons.Items.Add(p.FullName);
            }
        }

        private void Save_New_person(object sender, RoutedEventArgs e)
        {
            PersonModel p = new PersonModel();

            p.FirstName = FirstNametxt.Text;
            p.LastName = LastNametxt.Text;

            SqliteDataAccess.SavePerson(p);

            FirstNametxt.Text = "";
            LastNametxt.Text = "";
        }

        private void Load_DataBase(object sender, RoutedEventArgs e)
        {
            LoadPeopleList();
        }
    }
}
