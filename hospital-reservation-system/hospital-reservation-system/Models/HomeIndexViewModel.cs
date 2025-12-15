using hospital_reservation_system.Domain;
using System.ComponentModel.DataAnnotations;

namespace hospital_reservation_system.Models
{
    public class HomeIndexViewModel
    {
        [Required(ErrorMessage = "Please select a user")]
        public int SelectedUserId { get; set; }
        public List<User> Users { get; set; }
    }
}
