using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using New.Hope.Application;
using Newtonsoft.Json;

namespace New.Hope.Api.Controllers
{
    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }

        public string Message { get; set; }

        public string Value { get; set; }

        public ValidationError(string field, string message, string value)
        {
            this.Field = field != string.Empty ? field : null;

            this.Message = message;

            this.Value = value;
        }
    }

    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly INotifier _notifier;
        private readonly ILogger<BaseController> _logger;

        protected BaseController(INotifier notifier, ILogger<BaseController> logger)
        {
            _notifier = notifier;
            _logger = logger;
        }

        protected bool OperacaoValida()
        {
            return !_notifier.Errors.Any();
        }

        public IActionResult CustomResponse()
        {
            return CustomResponse(null);
        }

        public IActionResult CustomResponse(object ret)
        {
            if (!OperacaoValida())
            {
                return BadRequest(_notifier.Errors);
            }

            return Ok(new DefaultResponse()
            {
                data = ret,
                messages = _notifier.Warnings
            });
        }

        public ActionResult CustomResponse(object ret
                                         , int totalItens
                                         , int pageSize
                                         , int page)
        {
            if (_notifier.Errors.Any())
            {
                return BadRequest(_notifier.Errors);
            }

            return Ok(new DefaultResponse()
            {
                data = new Pagination()
                {
                    objects = ret,
                    links = new Links(totalItens, pageSize, page),
                    TotalItens = totalItens,
                    TotalPages = totalItens / pageSize
                },
                messages = _notifier.Warnings
            });
        }

        protected IActionResult CustomErrorResponse(ModelStateDictionary modelState)
        {
            NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Keys
                 .SelectMany(key => modelState[key].Errors
                                                    .Select(error => GetValidationError(key, error, modelState[key])))
                                                    .ToList();

            if (erros.Any())
            {
                var _notify = new Notify("validacao_erro", "Erro na validação de campos");

                foreach (var erro in erros)
                {
                    var _notification = new Notification(erro.Field, erro.Message, erro.Value);

                    _notify.Fields.Add(_notification);
                }
                _notifier.Errors.Add(_notify);
            }
        }

        private ValidationError GetValidationError(string key, ModelError error, ModelStateEntry modelState)
        {
            string value = string.Empty;

            if (!String.IsNullOrEmpty(modelState.AttemptedValue))
            {
                value = modelState.AttemptedValue;
            }

            return new ValidationError(key, error.ErrorMessage, value);
        }

    }
}