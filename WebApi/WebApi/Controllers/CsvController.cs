using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/csv")]
    public class CsvController : Controller
    {
        private readonly CsvService _csvService;

        public CsvController(CsvService csvService)
        {
            _csvService = csvService;
        }

        [HttpGet]
        [Route("all")]
        [Authorize]
        public ActionResult<List<Csv>> GetAll() => _csvService.Get();

        [HttpGet("{id:length(24)}")]
        [Route("byId")]
        [Authorize]
        public ActionResult<Csv> GetById(string id)
        {
            if (id == null)
                return NotFound();

            return _csvService.Get(id);
        }

        [HttpGet("{filtro:length(24)}")]
        [Route("byName")]
        [Authorize]
        public ActionResult<List<Csv>> GetByName(string filtro)
        {
            if (filtro == null)
                return NotFound();

            return _csvService.Get(filtro, filtro, filtro);
        }

        [HttpPost()]
        [Authorize]
        [Route("post")]
        public void PostCsv()
        {
            _csvService.SetCsv();
        }

    }
}
