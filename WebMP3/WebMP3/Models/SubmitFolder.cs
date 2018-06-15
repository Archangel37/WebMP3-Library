using System.ComponentModel.DataAnnotations;

namespace WebMP3.Models
{
    public class SubmitFolder
    {
        [Required]
        public string Dirrectory { get; set; }
        [Required]
        public bool SubDir { get; set; }
    }
}