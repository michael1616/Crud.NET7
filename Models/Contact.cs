using System.ComponentModel.DataAnnotations;

namespace Crud.NET7.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        [Phone]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]
        public string CellPhone { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Email { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
