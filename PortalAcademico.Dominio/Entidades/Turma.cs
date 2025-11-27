using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Dominio.Entidades
{
    public class Turma
    {
        public Turma()
        {
            Alunos = new List<Aluno>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Ano { get; set; }

        public ICollection<Aluno> Alunos { get; set; }
    }

}
