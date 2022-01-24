using BirthdayManager.Api.Factory;
using BirthdayManager.Api.Models;
using BirthdayManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BirthdayManager.Api.Controllers
{
    /// <summary>
    /// Controller de registros de Aniversários
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BirthdayController : ControllerBase
    {
        private readonly BirthdayDomain _domain;

        /// <summary>
        /// Construtor da Controller
        /// </summary>
        /// <param name="domain">Domínio de Aniversário</param>
        public BirthdayController(BirthdayDomain domain)
        {
            _domain = domain;
        }

        /// <summary>
        /// Obtém a lista de todos os aniversários
        /// </summary>
        [HttpGet]
        public ActionResult<List<BirthdayModel>> GetAll() =>
            Ok(_domain.GetAllBirthdays().ToModel());

        /// <summary>
        /// Obtém a quantidade de registros de Aniversários no Banco de Dados
        /// </summary>
        [HttpGet("Count")]
        public ActionResult<long> GetCount() =>
            Ok(_domain.CountAllBirthdays());

        /// <summary>
        /// Obtém um registro de aniversário pelo Id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<BirthdayModel> GetById(string id) =>
            Ok(_domain.GetBirthday(id).ToModel());

        /// <summary>
        /// Insere um novo registro de aniversário
        /// </summary>
        [HttpPost]
        public ActionResult Post([FromBody] CreateBirthdayModel data)
        {
            _domain.AddBirthday(data.ToDTO());
            return Ok();
        }

        /// <summary>
        /// Atualiza um registro de aniversário pelo Id
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] CreateBirthdayModel data)
        {
            _domain.UpdateBirthday(id, data.ToDTO());
            return Ok();
        }

        /// <summary>
        /// Deleta um registro de aniversário pelo Id
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _domain.DeleteBirthday(id);
            return Ok();
        }
    }
}
