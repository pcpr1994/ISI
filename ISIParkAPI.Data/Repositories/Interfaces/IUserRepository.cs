﻿/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetAllUser();
        Task<UserLogin> GetUserByEmail(string email);
        Task<UserDTO> GetUserById(int id);
        Task<bool> InsertUser(UserDTO user);
        Task<bool> UpdateUser(UserDTO user);
        Task<bool> DeleteUser(UserDTO user);
    }
}
