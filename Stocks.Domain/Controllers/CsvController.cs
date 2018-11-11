using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stocks.Data.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stocks.Domain.Controllers
{
    [Route("api/[controller]")]
    public class CSVController : Controller
    {
        // GET api/csvtest
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DummyData());
        }

        [HttpGet]
        [Route("data.csv")]
        [Produces("text/csv")]
        public IActionResult GetDataAsCsv()
        {
            return Ok(DummyData());
        }

        private static IEnumerable<LocalCSV> DummyData()
        {
            var model = new List<LocalCSV>
            {
                new LocalCSV
                {
                    Id = 1,
                    Key = "test",
                    Text = "test text",
                    LocalizationCulture = "en-US",
                    ResourceKey = "test"

                },
                new LocalCSV
                {
                    Id = 2,
                    Key = "test",
                    Text = "test2 text de-CH",
                    LocalizationCulture = "de-CH",
                    ResourceKey = "test"

                }
            };

            return model;
        }

        // POST api/csvtest/import
        [HttpPost]
        [Route("import")]
        public IActionResult Import([FromBody]List<LocalCSV> value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                List<LocalCSV> data = value;
                return Ok();
            }
        }

    }
}
