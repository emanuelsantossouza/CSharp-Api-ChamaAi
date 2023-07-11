using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiChamaAi.DataTransferObjects
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email ou Nome de Usuário  requirido")]
        public string id { get; set; }

    }
}