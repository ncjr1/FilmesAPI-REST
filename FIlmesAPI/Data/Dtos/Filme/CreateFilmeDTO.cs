using System.ComponentModel.DataAnnotations;

namespace FIlmesAPI.Data.Dtos
{
    public class CreateFilmeDTO
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Genero pode ter até 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração do filme é de no máximo 600 minutos")]
        public int Duracao { get; set; }
    }
}
