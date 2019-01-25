using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Pergunta
    {
        public int Id { get; set; }
        [Required]
        public string Texto { get; set; }
        public bool Ativo { get; set; }
        public List<QuestionarioPergunta> Questionario { get; set; }

        public Pergunta(string pergunta)
        {
            Texto = pergunta;
        }

        public Pergunta()
        {

        }

        internal bool EhValida()
        {
            if (string.IsNullOrEmpty(Texto) || Texto.Length <= 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
