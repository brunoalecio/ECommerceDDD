using System.Text.RegularExpressions;

namespace ECommerceDDD.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; private set; }

        // Construtor exigido pelo EF Core (necessário, não obrigatório para lógica)
        protected Email() { }

        public Email(string address)
        {
            if (!IsValid(address))
                throw new ArgumentException("E-mail inválido.");

            Address = address.Trim().ToLower();
        }

        public static bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Validação simples para o email
            var regex = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            return Regex.IsMatch(email, regex);
        }

    }
}
