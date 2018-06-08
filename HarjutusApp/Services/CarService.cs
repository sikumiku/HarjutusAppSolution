using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarjutusApp.Models;

namespace HarjutusApp.Services
{
    public class CarService : BaseService
    {
        public async Task<List<Car>> GetCarsAsync()
        {
            return await base.GetAsync<List<Car>>("cars");
        }

        public async Task<Car> AddNewCar(Car car)
            => await base.PostAsync("cars", car);


        public async Task<List<Car>> FindCarsAsync(string licensePlate, int personId)
        {
            return await base.GetAsync<List<Car>>(string.Format("cars/find?licensePlate={0}&personId={1}", licensePlate, personId));
        }

        public async Task<Car> UpdateCar(int id, Car car)
        {
            return await base.PutAsync<Car>($"cars/{id}", car);
        }

        public async Task<Car> RemoveCar(int id)
        {
            return await base.DeleteAsync<Car>($"cars/{id}");
        }
    }
}
