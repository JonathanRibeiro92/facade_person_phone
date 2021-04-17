﻿using System.Threading.Tasks;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonListResponse> FindAllAsync();
        Task<PersonPhoneResponse> FindPersonPhone(int id);
        Task<PersonPhoneResponse> AddPersonPhone(PersonPhoneDto personPhone);
        Task<PersonPhoneResponse> UpdatePersonPhone(int id, PersonPhoneDto personPhone);
        Task<PersonPhoneResponse> RemovePersonPhone(PersonPhoneDto personPhone);
        Task<PersonResponse> FindPerson(int id);
    }
}