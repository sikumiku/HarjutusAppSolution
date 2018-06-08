using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HarjutusApp.Models;

namespace HarjutusApp.Services
{
    public class PeopleService:BaseService
    {
        public async Task<List<Person>> GetPeopleAsync()
        {
            return await base.GetAsync<List<Person>>("people");
        }

        public async Task<Person> AddNewPerson(Person p)
            => await base.PostAsync("people", p);

        public async Task<Person> GetPersonById(int id)
        {
            return await base.GetAsync<Person>($"people/{id}");
        }

        public async Task<List<Person>> FindPeopleAsync(string idCode, string firstname)
        {
            return await base.GetAsync<List<Person>>(string.Format("people/find?idCode={0}&firstname={1}", idCode, firstname));
        }

        public async Task<Person> UpdatePerson(int id, Person p)
        {
            return await base.PutAsync<Person>($"people/{id}", p);
        }

        public async Task<Person> DeactivatePerson(int id)
        {
            return await base.DeleteAsync<Person>($"people/deactivate/{id}");
        }

        public async Task<Person> DeletePerson(int id)
        {
            return await base.DeleteAsync<Person>($"people/{id}");
        }
    }
}
