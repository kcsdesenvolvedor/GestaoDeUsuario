using System.ComponentModel.DataAnnotations;

namespace GestaoUsuario.API.Models
{
    public class UserRequest
    {
        [Required(ErrorMessage = "O campo 'Name' é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo 'Name' deve conter no máximo 100 caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo 'Email' deve conter no máximo 100 caracteres.")]
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
