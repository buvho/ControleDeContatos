
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do Usuario")]
        [EmailAddress(ErrorMessage ="Email invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "informe o perfil")]
        public PerfilEnum? Perfil { get; set; }

    }
}
