using System.Text.Json.Serialization;
namespace Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

       [JsonPropertyName("dataNascimento")]
    public DateTime DataDeNascimento { get; set; }
        public string Senha { get; set; } 

        
        public User(string name, string email, DateTime dataDeNascimento, string senha)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
              DataDeNascimento = dataDeNascimento.ToUniversalTime();
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
        }
    }
}