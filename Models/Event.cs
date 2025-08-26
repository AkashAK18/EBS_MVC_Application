using System;
using System.ComponentModel.DataAnnotations;

namespace EventBookingSystem.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event Name is required")]
        [StringLength(100, ErrorMessage = "Event name cannot exceed 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Event Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }

        [Range(1, 10000, ErrorMessage = "Available seats must be between 1 and 10000")]
        public int TotalSeats { get; set; }

        [Range(0, 10000, ErrorMessage = "Available seats must be between 1 and 10000")]
        public int AvailableSeats { get; set; }
    }
}