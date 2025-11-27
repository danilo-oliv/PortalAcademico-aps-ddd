using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Dominio.Validations
{
    public class EmailDominioAttribute : ValidationAttribute
    {
        private readonly string _dominio;
        public EmailDominioAttribute(string dominio)
        {
            _dominio = dominio;
            ErrorMessage = $"O email deve ser do domínio {_dominio}.";
        }

        public override bool IsValid(object? value)
        {
            if (value is not string email) return false;
            return email.EndsWith("@" + _dominio, StringComparison.OrdinalIgnoreCase);
        }
    }
}
