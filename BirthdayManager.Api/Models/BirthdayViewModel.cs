using System;

namespace BirthdayManager.Api.Models
{
    public class BirthdayViewModel
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
        public string Data { get; set; }
    }
}