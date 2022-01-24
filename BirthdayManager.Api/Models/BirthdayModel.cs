using System;

namespace BirthdayManager.Api.Models
{
    /// <summary>
    /// Classe Model do Registro de Aniversário
    /// </summary>
    public class BirthdayModel
    {
        /// <summary>
        /// Id do registro de aniversário
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nome de quem ou do que faz o aniversário
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Data do Aniversário
        /// </summary>
        public DateTime Data { get; set; }
    }
}