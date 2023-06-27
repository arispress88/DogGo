using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your dog's breed")]
        [MaxLength(35)]
        public string Breed { get; set; }
        public string Notes { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public string ImageUrl { get; set; }
    }
}
