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
using HarjutusApp.Models;
using HarjutusApp.ViewModels;

namespace HarjutusApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM _vm;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = new MainWindowVM();
            _vm.LoadData();
            DataContext = _vm;
        }
        #region PersonActions
        private void Person_Search_Click(object sender, RoutedEventArgs e)
        {
            _vm.FindPeople(txtIdCodeLookup.Text, txtFirstnameLookup.Text);
        }

        private void Person_Post_Click(object sender, RoutedEventArgs e)
        {
#warning validation

            var p = new Person
            {
                Firstname = txtFirstname.Text,
                Lastname = txtLastname.Text,
                Birthday = txtBirthday.Text,
                IdCode = txtIdCode.Text
            };

            _vm.AddNewPerson(p);

        }

        private void Person_Put_Click(object sender, RoutedEventArgs e)
        {
            var p = new Person
            {
                Firstname = txtFirstname.Text,
                Lastname = txtLastname.Text,
                Birthday = txtBirthday.Text,
                IdCode = txtIdCode.Text
            };
            _vm.UpdatePerson(int.Parse(txtUpdatePersonId.Text), p);
        }

        private void Person_Deactivate_Click(object sender, RoutedEventArgs e)
        {
            _vm.DeactivatePerson(int.Parse(txtDeletePersonId.Text));
        }

        private void Person_Delete_Click(object sender, RoutedEventArgs e)
        {
            _vm.DeletePerson(int.Parse(txtDeletePersonId.Text));
        }
        #endregion
        #region CarActions
        private void Car_Post_Click(object sender, RoutedEventArgs e)
        {
            var car = new Car
            {
                ManufactureYear = txtManufactureYear.Text,
                CarBrand = txtCarBrand.Text,
                CarModel = txtCarModel.Text,
                LicensePlate = txtLicensePlate.Text,
                PersonId = int.Parse(txtCarAddPersonId.Text)
            };

            _vm.AddNewCar(car);

        }

        private void Car_Put_Click(object sender, RoutedEventArgs e)
        {
            var car = new Car
            {
                ManufactureYear = txtManufactureYear.Text,
                CarBrand = txtCarBrand.Text,
                CarModel = txtCarModel.Text,
                LicensePlate = txtLicensePlate.Text
            };
            _vm.UpdateCar(int.Parse(txtCarUpdateId.Text), car);
        }

        private void Car_Remove_Click(object sender, RoutedEventArgs e)
        {
            _vm.RemoveCar(int.Parse(txtCarDeleteId.Text));
        }

        private void Car_Search_Click(object sender, RoutedEventArgs e)
        {
            _vm.FindCars(txtLicensePlateLookup.Text);
        }

        private void PersonCar_Show_Click(object sender, RoutedEventArgs e)
        {
            _vm.FindPersonCars(int.Parse(txtDisplayCarsByPersonId.Text));
        }
        #endregion
    }
}
