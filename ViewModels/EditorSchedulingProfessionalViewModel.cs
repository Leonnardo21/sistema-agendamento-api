using ConnectHealthApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ConnectHealthApi.ViewModels
{
    public class EditorSchedulingProfessionalViewModel
    {
        [Required(ErrorMessage = "O campo Data é obrigatório")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "O campo Horário é obrigatório")]
        public TimeSpan TimeTable { get; set; }

        [Required(ErrorMessage = "O campo Duração é obrigatório")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "O campo Local é obrigatório")]
        public string Local { get; set; } = null!;

        //Foreign Key
        public int ProfessionalId { get; set; }
        public UserModel? Professional { get; set; }
    }
}
