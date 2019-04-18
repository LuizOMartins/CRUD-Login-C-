using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class AlterarSenhaViewModel {

        [Required(ErrorMessage ="Informe a senha atual")]
        [DataType(DataType.Password)]
        [Display(Name ="Senha Atual")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Informe a nova senha atual")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Corfirme a senha")]
        [Compare(nameof(NovaSenha),ErrorMessage ="As senhas não conferem")]
        public string ConfirmacaoSenha { get; set;}
    }
}