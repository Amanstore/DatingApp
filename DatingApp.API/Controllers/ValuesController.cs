﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    //GET http://localhost:5000/api/values/5
    //POST http://localhost:5000/api/values/5
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _datacontext;
        
        public ValuesController(DataContext context   )
        {
            _datacontext =context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
             
            var values = await _datacontext.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValueAsync(int id)
        {
            var value = await _datacontext.Values.FirstOrDefaultAsync(x=>x.Id==id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
