﻿using System;
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
        //private readonly CsvService _csvService;

        //public CsvController(CsvService csvService)
        //{
        //    _csvService = csvService;
        //}

        [HttpGet]
        [Route("All")]
        public ActionResult All()
        {
            return Ok(Json("Este é o retorno do método All"));
        }

        [HttpGet("{id:length(24)}")]
        [Route("ById")]
        public ActionResult ById(string id)
        {
            return Ok(Json("Este é o retorno do método ById com Id: " + id));
        }

        [HttpGet("{filtro:length(24)}")]
        [Route("ByName")]
        public ActionResult ByName(string filtro)
        {
            return Ok(Json("Este é o retorno do método ByName com filtro: " + filtro));
        }

    }
}