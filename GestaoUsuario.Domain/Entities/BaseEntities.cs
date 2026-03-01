using System.ComponentModel.DataAnnotations;

namespace GestaoUsuario.Domain.Entities
{
    public abstract class BaseEntities
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
