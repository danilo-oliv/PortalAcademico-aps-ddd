using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalAcademico.Dominio.Validations;

namespace PortalAcademico.Aplicacao.ViewModels
{

    public class AlunoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        [EmailDominio("dominio.edu.br")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Data de nascimento é obrigatória.")]
        [IdadeMinima(16)]
        public DateTime DataNascimento { get; set; }

        public int TurmaId { get; set; }
        public string? TurmaNome { get; set; }
    }


}
