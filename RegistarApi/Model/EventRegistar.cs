using System.ComponentModel.DataAnnotations;

namespace RegistarApi.Model
{
    public class EventRegistar
    {

        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(12)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string ParticipantComment { get; set; }
        
    }
}
