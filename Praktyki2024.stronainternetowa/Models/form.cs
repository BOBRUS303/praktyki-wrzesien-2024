using System.ComponentModel.DataAnnotations;

namespace Praktyki2024.stronainternetowa.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adres email jest wymagany.")]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wiadomość jest wymagana.")]
        public string Message { get; set; }
    }
}