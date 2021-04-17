using System;
using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper, IPersonPhoneService personPhoneService, IPhoneNumberTypeService phoneNumberTypeService)
        {
            _personService = personService;
            _mapper = mapper;
            _personPhoneService = personPhoneService;
            _phoneNumberTypeService = phoneNumberTypeService;
        }

        public async Task<PersonListResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonListResponse
            {
                PersonObjects = new List<PersonDto>()
            };
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonResponse> FindPerson(int id)
        {
            var result = await _personService.Find(id);
            var response = new PersonResponse()
            {
                PersonObject = new PersonDto()
                {
                    BusinessEntityID = result.BusinessEntityID,
                    Name = result.Name,
                    Phones = new List<PersonPhoneDto>()
                }
            };

            response.PersonObject.Phones.AddRange(result.Phones.Select(x=> _mapper.Map<PersonPhoneDto>(x)));

            return response;
        }

        public async Task<PersonResponse> RemovePerson(int id)
        {
            var result = await _personService.Find(id);

            if (result == null)
                return null;

            var response = new PersonResponse()
            {
                PersonObject = new PersonDto()
                {
                    BusinessEntityID = result.BusinessEntityID,
                    Name = result.Name,
                    Phones = new List<PersonPhoneDto>()
                }
            };

            response.PersonObject.Phones.AddRange(result.Phones.Select(x => _mapper.Map<PersonPhoneDto>(x)));

            await _personService.Remove(result);

            return response;
        }

        public async Task<PersonPhoneResponse> FindPersonPhone(int id)
        {
            var result = await _personPhoneService.Find(id);
            var response = new PersonPhoneResponse
            {
                PersonPhoneObject = new PersonPhoneDto
                {
                    BusinessEntityID = result.BusinessEntityID,
                    PersonId = result.Person.BusinessEntityID,
                    PhoneNumber = result.PhoneNumber,
                    PhoneNumberType = result.PhoneNumberType.Name
                }
            };

            return response;
        }

        public async Task<PersonPhoneResponse> AddPersonPhone(PersonPhoneDto personPhone)
        {
            var person = await _personService.Find(personPhone.PersonId);
            var newPersonPhone = new PersonPhone
            {
                PhoneNumber = personPhone.PhoneNumber,
                PhoneNumberType = await _phoneNumberTypeService.Find(x=> x.Name == personPhone.PhoneNumberType),
                Person = person
            };

            await _personPhoneService.Add(newPersonPhone);


            var response = new PersonPhoneResponse
            {
                PersonPhoneObject = new PersonPhoneDto
                {
                    BusinessEntityID = newPersonPhone.BusinessEntityID,
                    PersonId = newPersonPhone.Person.BusinessEntityID,
                    PhoneNumber = newPersonPhone.PhoneNumber,
                    PhoneNumberType = newPersonPhone.PhoneNumberType.Name
                }
            };

            return response;
        }

        public async Task<PersonPhoneResponse> UpdatePersonPhone(int id, PersonPhoneDto personPhone)
        {

                var person = await _personService.Find(personPhone.PersonId);

                var personPhoneUpdate = await _personPhoneService.Find(id);

                personPhoneUpdate.PhoneNumber = personPhone.PhoneNumber;
                personPhoneUpdate.PhoneNumberType =
                    await _phoneNumberTypeService.Find(x => x.Name == personPhone.PhoneNumberType);
                personPhoneUpdate.Person = person;


                await _personPhoneService.Update(personPhoneUpdate);


                var response = new PersonPhoneResponse
                {
                    PersonPhoneObject = new PersonPhoneDto
                    {
                        BusinessEntityID = personPhoneUpdate.BusinessEntityID,
                        PersonId = personPhoneUpdate.Person.BusinessEntityID,
                        PhoneNumber = personPhoneUpdate.PhoneNumber,
                        PhoneNumberType = personPhoneUpdate.PhoneNumberType.Name
                    }
                };

                return response;
            

        }

        public async Task<PersonPhoneResponse> RemovePersonPhone(PersonPhoneDto personPhone)
        {
            var removedPersonPhone = await _personPhoneService.Find(x => x.BusinessEntityID == personPhone.BusinessEntityID);

            var response = new PersonPhoneResponse
            {
                PersonPhoneObject = new PersonPhoneDto
                {
                    BusinessEntityID = removedPersonPhone.BusinessEntityID,
                    PersonId = removedPersonPhone.Person.BusinessEntityID,
                    PhoneNumber = removedPersonPhone.PhoneNumber,
                    PhoneNumberType = removedPersonPhone.PhoneNumberType.Name
                }
            };

            await _personPhoneService.Remove(removedPersonPhone);

            return response;
        }
    }
}
