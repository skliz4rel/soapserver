using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculateService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CalculateService.CalculatorSoapClient;

namespace ConsumeSoap.RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {

        public CalculateController()
        {

        }

        [HttpGet("{id}/{id1}")]
        [ActionName("add")]
        public async Task<int> Add(int id, int id1)
        {
            int a = id; int b = id1;
          
            CalculatorSoapClient client =
             new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap12);

            int result = await client.AddAsync(a,b);

            return result;
        }

        [HttpGet("{id}/{id1}")]
        [ActionName("subtract")]
        public async Task<int> Subtract(int id, int id1)
        {
            int a = id; int b = id1;

            CalculatorSoapClient client =
             new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap12);

            int result = await client.SubtractAsync(a, b);

            return result;
        }

        [HttpGet("{id}/{id1}")]
        [ActionName("divide")]
        public async Task<int> Divide(int id, int id1)
        {
            int a = id; int b = id1;

            CalculatorSoapClient client =
             new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap12);

            int result = await client.DivideAsync(a, b);

            return result;
        }

        [HttpGet("{id}/{id1}")]
        [ActionName("multiply")]
        public async Task<int> Multiply(int id, int id1)
        {
            int a = id; int b = id1;

            CalculatorSoapClient client =
             new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap12);

            int result = await client.MultiplyAsync(a, b);

            return result;
        }

    }
}