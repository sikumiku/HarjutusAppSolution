using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HarjutusApp.Models;
using HarjutusApp.Services;

namespace HarjutusApp.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private List<Person> _persons;
        private List<Car> _cars;
        private List<Car> _personCars;
        private readonly PeopleService _peopleService;
        private readonly CarService _carService;

        public List<Person> Persons
        {
            get
            {
                return _persons;
            }
            private set
            {
                _persons = value;
                NotifyPropertyChanged("Persons");
            }
        }

        public List<Car> Cars
        {
            get
            {
                return _cars;
            }
            private set
            {
                _cars = value;
                NotifyPropertyChanged("Cars");
            }
        }

        public List<Car> PersonCars
        {
            get
            {
                return _personCars;
            }
            private set
            {
                _personCars = value;
                NotifyPropertyChanged("PersonCars");
            }
        }

        #region PersonMethods
        internal async void FindPeople(string idCode, string firstname)
        {
            Persons = await _peopleService.FindPeopleAsync(idCode, firstname);
        }

        internal async void UpdatePerson(int id, Person p)
        {
            await _peopleService.UpdatePerson(id, p);
            LoadData();
        }

        internal async void DeactivatePerson(int id)
        {
            await _peopleService.DeactivatePerson(id);
            LoadData();
        }

        internal async void DeletePerson(int id)
        {
            await _peopleService.DeletePerson(id);
            LoadData();
        }

        internal async void AddNewPerson(Person person)
        {
            var response = await _peopleService.AddNewPerson(person);
            LoadData();
        }
        #endregion

        #region carMethods

        internal async void AddNewCar(Car car)
        {
            var response = await _carService.AddNewCar(car);
            LoadData();
        }

        internal async void UpdateCar(int id, Car car)
        {
            await _carService.UpdateCar(id, car);
            LoadData();
        }

        internal async void RemoveCar(int id)
        {
            await _carService.RemoveCar(id);
            LoadData();
        }

        internal async void FindCars(string licensePlate)
        {
            Cars = await _carService.FindCarsAsync(licensePlate, 0);
        }

        internal async void FindPersonCars(int personId)
        {
            PersonCars = await _carService.FindCarsAsync(null, personId);
        }
        #endregion

        public MainWindowVM()
        {
            _persons = new List<Person>();
            _peopleService = new PeopleService();
            _carService = new CarService();
        }

        public async void LoadData()
        {
            Persons = await _peopleService.GetPeopleAsync();
            Cars = await _carService.GetCarsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
