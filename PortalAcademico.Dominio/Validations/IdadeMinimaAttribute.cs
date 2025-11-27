using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Dominio.Validations
{
    public class IdadeMinimaAttribute : ValidationAttribute
    {
        private readonly int _idadeMinima;
        public IdadeMinimaAttribute(int idadeMinima)
        {
            _idadeMinima = idadeMinima;
            ErrorMessage = $"O aluno deve ter no mínimo {_idadeMinima} anos.";
        }

        public override bool IsValid(object? value)
        {
            if (value is not DateTime dataNascimento) return false;

            var idade = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento > DateTime.Today.AddYears(-idade)) idade--;

            return idade >= _idadeMinima;
        }
    }
}