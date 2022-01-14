using System;

namespace BirthdayManager.Api.Models
{
    public class CreateBirthdayModel
    {
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