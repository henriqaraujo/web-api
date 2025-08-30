using System.ComponentModel.DataAnnotations;

namespace web_api.Models {
    public class Personagem {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome precisa ter no máximo 50 Caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Tipo é um campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Tipo precisa ter no máximo 50 Caracteres")]
        public string Tipo { get; set; }
    }
}
