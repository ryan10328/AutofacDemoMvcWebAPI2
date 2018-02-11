using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.ViewModels;

namespace WebDemo.Services
{
    public interface IUserService
    {
        UserModel GetUser();
    }
}
