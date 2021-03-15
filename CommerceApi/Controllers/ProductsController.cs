using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using AutoMapper;
using CommerceApi.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommerceApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        EFCore_DataAccessLayer DAL = new EFCore_DataAccessLayer();
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public List<Models.Product> Get()
        {
            DAL.GetProducts();
            return _mapper.Map<List<Models.Product>>( DAL.GetProducts());
            //return new string[] { "value1", "value2" };
        }

        //GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {

            return DAL.GetProduct(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
