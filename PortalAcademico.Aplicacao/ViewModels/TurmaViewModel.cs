using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAcademico.Aplicacao.ViewModels
{
    public class TurmaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Ano { get; set; }
    }

}
