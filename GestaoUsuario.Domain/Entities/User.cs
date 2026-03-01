using System.ComponentModel.DataAnnotations;

namespace GestaoUsuario.Domain.Entities
{
    public class User : BaseEntities
    {
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }
}
