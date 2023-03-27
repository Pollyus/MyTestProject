﻿using Coordinator.Repositories;
using Coordinator.Services;
using Microsoft.AspNetCore.Mvc;
using TestAppData;
using TestReport;


namespace Coordinator.Controllers
{
    /// <summary>
    /// Контроллер отчетов
    /// </summary>
    [Route("api/report")]
    [ApiController]
    public class ReportController : Controller
    {
        readonly IReportRepository _repository;
        //private readonly TestAppContext context;

        public ReportController (IReportRepository repository)
        {
            _repository = repository;
           
        }

        /// Получение всех отчетов 
        [HttpGet("get/all")]
        public IActionResult GetResult()
        {
            return Ok(_repository.Reports());
        }

        //Загрузка отчетов на сервер
        [HttpPost("load")]
        public Task<IActionResult> UploadFile([FromBody] TestReportLoad testReport)
        { 
           
            return Task.FromResult<IActionResult>(_repository.AddReport(testReport) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError));
           
        }


    }
}
