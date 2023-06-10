using System.ComponentModel.DataAnnotations;

namespace ConnectHealthApi.ViewModels
{
    public class EditorProfessionalViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public char Gender { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "O campo Especialidade é obrigatório")]
        public string Especiality { get; set; } = null!;

        [Required(ErrorMessage = "O campo Usuário é obrigatório")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}