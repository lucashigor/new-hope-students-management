using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using New.Hope.Application;
using New.Hope.Application.Interfaces.Application.Commands;
using New.Hope.Application.Interfaces.ExternalServices;
using New.Hope.Domain;

namespace New.Hope.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class StudentsController : BaseController
    {
        private readonly ILogger<BaseController> _logger;
        private readonly IStudentsQueries _studentsqueries;
        private readonly IStudentsCommands _studentsCommands;

        private readonly IIbgeExternalService _ibgeExternalService;

        public StudentsController(
            ILogger<BaseController> logger,
            INotifier notifier,
            IStudentsQueries queries,
            IStudentsCommands studentsCommands,
            IIbgeExternalService ibgeExternalService) : base(notifier, logger)
        {
            _logger = logger;
            _studentsqueries = queries;
            _studentsCommands = studentsCommands;
            _ibgeExternalService = ibgeExternalService;
        }

        [HttpGet("{idStudent}")]
        public IActionResult Get(int idStudent)
        {
            var ret = _studentsqueries.GetById(idStudent);

            var red = _ibgeExternalService.RegionsAsync().GetAwaiter().GetResult();

            return CustomResponse(ret);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            if (!ModelState.IsValid)
            {
                return CustomErrorResponse(ModelState);
            }

            var ret = _studentsCommands.CreateStudent(student);

            return CustomResponse(ret);
        }
    }
}
