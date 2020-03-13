using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Services;
using System.Text.Json;
using System.Collections.Generic;

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
        [Route("All")]
        public ActionResult<List<Csv>> All() => _csvService.Get();

        [HttpGet("{id:length(24)}")]
        [Route("ById")]
        public ActionResult<Csv> ById(string id)
        {
            if (id == null)
                return NotFound();

            return _csvService.Get(id);
        }

        [HttpGet("{filtro:length(24)}")]
        [Route("ByName")]
        public ActionResult<List<Csv>> ByName(string filtro)
        {
            if (filtro == null)
                return NotFound();

            return _csvService.Get(filtro, filtro, filtro);
        }

    }
}
