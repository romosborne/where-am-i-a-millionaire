using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using where_am_i_a_millionaire.Models;
using where_am_i_a_millionaire.Services;

namespace where_am_i_a_millionaire.Controllers
{
    [Route("/api")]
    public class ApiContoller : Controller
    {
        private readonly IExchangeService _service;

        public ApiContoller(IExchangeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody]Request request)
        {
            var things = await _service.GetEquivalents(request.Amount, request.Currency);

            var response = new Response()
            {
                OriginalAmount = request.Amount,
                OriginalCurrency = request.Currency,
                Results = things
            };

            return new ObjectResult(response);
        }
    }
}
