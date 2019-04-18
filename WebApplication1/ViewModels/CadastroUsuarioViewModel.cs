using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.ViewModels
{
    public class CadastroUsuarioViewModel{

        [Required (ErrorMessage="Informe o nome")]
        [MaxLength(100,ErrorMessage="pode no maximo 100")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "pode no maximo 100")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "pode no maximo 100")]
        [MinLength(6, ErrorMessage ="Tem que ser mais que 6")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [MinLength(6, ErrorMessage = "Tem que ser mais que 6")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e a confirmação não estão iguais")]
        public string ConfirmacaoSenha { get; set; }
    }
}