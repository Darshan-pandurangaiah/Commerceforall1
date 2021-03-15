using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using AutoMapper;
using CommerceApi;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataAccessLayer.Models;


namespace CommerceApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        EFCore_DataAccessLayer DAL = new EFCore_DataAccessLayer();
        private readonly IMapper _mapper;

        [JsonConstructor]
        public UsersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/<ProductsController>
        //[HttpGet]
        //public Boolean Get()
        //{
        //    DAL.Validateuser();
        //    return DAL.ValidateUser();
        //    //return new string[] { "value1", "value2" };
        //}

        //GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Boolean Get(string id)
        {

            return false;
        }

        // POST api/<ProductsController>
        [HttpPost]
        
        public Boolean Post([FromBody] User userinput)
        {
           //Models.User userobj = _mapper.Map<Models.User>(userinput);
            
            return DAL.ValidateUser(userinput); 
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JsonResult value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
