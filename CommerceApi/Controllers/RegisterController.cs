using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer;
using AutoMapper;
using System.Text.Json.Serialization;

namespace CommerceApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        EFCore_DataAccessLayer DAL = new EFCore_DataAccessLayer();
        private readonly IMapper _mapper;

        [JsonConstructor]
        public RegisterController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpPost]

        public Boolean Post([FromBody] User userinput)
        {
            User userobj = _mapper.Map<User>(userinput);

            return DAL.InsertUser(userobj);
        }
    }
}
