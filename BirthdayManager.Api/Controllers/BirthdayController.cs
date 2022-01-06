using BirthdayManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayManager.Api.Controllers
{
    /// <summary>
    /// Controller de Aniversários
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BirthdayController : ControllerBase
    {
        private readonly BirthdayDomain _domain;

        public BirthdayController(BirthdayDomain domain)
        {
            _domain = domain;
        }

        /// <summary>
        /// Obtém uma lista de aniversários
        /// </summary>
        [HttpGet]
        public ActionResult GetAll() => Ok(_domain.GetAllBirthdays());

        [HttpPost]
        public ActionResult Post()
        {

            return Ok();
        }
    }
}
