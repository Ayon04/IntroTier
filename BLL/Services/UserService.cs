using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        
       
        public static void Create(UserDTO u)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config); ;
            var st = mapper.Map<User>(u);
            var repo = new UserRepo();
            repo.Create(st);

        }

        public static string Login(string email, string password)
        {
            try
            {
                var repo = new UserRepo(); 

                var userEntity = repo.GetUserByEmailAndPassword(email, password);

                if (userEntity != null)
                {
                    return "Logged in successfully";
                }
                else
                {
                    return "invalied email or password";
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred during login";
            }
           
        }









    }
}
