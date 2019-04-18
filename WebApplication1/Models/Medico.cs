using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace WebApplication1.Models {
    public class Medico {
        public int MedicoID { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int CidadeID { get; set; }
        public int EspecialidadeID { get; set; }


        [ForeignKey("CidadeID")]
        public virtual Cidade Cidade { get; set; }

        [ForeignKey("EspecialidadeID")]
        public virtual Especialidade Especialidade { get; set; }
    }
}