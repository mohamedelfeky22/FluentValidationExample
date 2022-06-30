using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using FluentValidationExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationExample.Controllers
{
    [Route("[controller]")]
    public class PeopleController : Controller
    {
        private IValidator<Person> _validator;


        public PeopleController(IValidator<Person> validator)
        {
            // Inject our validator and also a DB context for storing our person object.
            _validator = validator;
        }

        [HttpPost("validate")]
        public async Task<ValidationResult> validateAsync([FromBody]Person person)
        {
            ValidationResult result = await _validator.ValidateAsync(person);
            return result;
        }
    }
}
