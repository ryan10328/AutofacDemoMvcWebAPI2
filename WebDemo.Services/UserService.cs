using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebDemo.Models;
using WebDemo.ViewModels;

namespace WebDemo.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserModel GetUser()
        {
            var user = new User
            {
                Id = 1,
                Email = "123@123.123",
                Name = "RyanTseng",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var userModel = _mapper.Map<UserModel>(user);

            return userModel;
        }

    }
}
