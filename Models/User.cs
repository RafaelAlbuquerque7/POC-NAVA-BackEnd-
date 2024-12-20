//isso representa os dados que vou manipular
namespace Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Adicionando um construtor para garantir que as propriedades sejam obrigatórias
        public User(string name, string email)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Isso Garante que o 'Name' não seja nulo
            Email = email ?? throw new ArgumentNullException(nameof(email)); // Isso Garante que 'email' não seja nulo
        }
    }
}

//