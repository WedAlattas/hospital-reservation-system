using hospital_reservation_system.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace hospital_reservation_system.Models
{
    public class AppointmentCreateViewModel
    {

        [BindNever, ValidateNever]
        public List<TimeSlot?>? TimeSlots { get; set; } = new();
        [BindNever, ValidateNever]
        public List<Doctors?>? Doctors { get; set; } = new();


        [Required(ErrorMessage = "Please select a Doctor")]
        public int SelectedDoctorId { get; set; }
        [Required(ErrorMessage = "Please select at least one time slot")]
        public List<int> SelectedTimeSlot { get; set; } = new List<int>();
    }
}
