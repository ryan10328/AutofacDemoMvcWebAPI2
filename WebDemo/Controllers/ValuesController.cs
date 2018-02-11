using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDemo.Services;

namespace WebDemo.Controllers
{
    [RoutePrefix("api/World")]
    public class ValuesController : ApiController
    {
        private readonly IUserService _userService;

        public ValuesController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Hello"), HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_userService.GetUser());
        }

    }
}
