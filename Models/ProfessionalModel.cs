namespace ConnectHealthApi.Models
{
    public class ProfessionalModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public char Gender { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Especiality { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}