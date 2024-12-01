using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Data.Repositories.Interfaces;
using PharmacyAPI.DTOs;
using PharmacyAPI.Models;

namespace PharmacyAPI.Services
{
    public class PersonService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _personRepository.GetAll();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _personRepository.GetById(id);
        }

        public void AddPerson(Person person)
        {
            _personRepository.Add(person);
        }

        public void UpdatePerson(Person person)
        {
            _personRepository.Update(person);
        }

        public void DeletePerson(int id)
        {
            _personRepository.Delete(id);
        }
    }
}
