using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConvertingValuta;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestServiceForConverter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        // GET: api/<ConverterController>
        [HttpGet]
        [Route("TilDanske/{svenskeKroner}")]
        public double TilDanske(double svenskeKroner)
        {
            return ValutaConverter.TilDanske(svenskeKroner);
        }

        // GET api/<ConverterController>/5
        [HttpGet]
        [Route("TilSvenske/{danskeKroner}")]
        public double Get(double danskeKroner)
        {
            return ValutaConverter.TilSvenske(danskeKroner);
        }

    }
}
