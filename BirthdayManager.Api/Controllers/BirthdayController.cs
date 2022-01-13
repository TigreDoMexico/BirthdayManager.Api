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
        /// Obtém a lista de todos os aniversários
        /// </summary>
        [HttpGet]
        public ActionResult GetAll() => Ok(_domain.GetAllBirthdays());

        /// <summary>
        /// Obtém a quantidade de registros de Aniversários no Banco de Dados
        /// </summary>
        [HttpGet("Count")]
        public ActionResult<long> GetCount() => Ok(_domain.CountAllBirthdays());

        /// <summary>
        /// Obtém um registro de aniversário pelo Id
        /// </summary>
        [HttpGet("{id:string}")]
        public ActionResult GetById(string id) => Ok(_domain.GetBirthday(id));

        /// <summary>
        /// Obtém uma lista de aniversários
        /// </summary>
        [HttpPost]
        public ActionResult Post()
        {

            return Ok();
        }
    }
}
