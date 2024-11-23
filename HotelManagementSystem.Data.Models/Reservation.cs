﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Data.Models
{
    public class Reservation
    {
        [Key]
        [Comment("Reservation Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("Room Identifier")]
        public int RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; } = null!;

        [Required]
        [Comment("User id of the guest")]
        public Guid GuestId { get; set; }

        [ForeignKey(nameof(GuestId))]
        public ApplicationUser Guest { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [Comment("Check in date")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Comment("Check out date")]
        public DateTime CheckOutDate { get; set; }

        [DataType(DataType.Date)]
        [Comment("Date of reservation")]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [Required]
        [Comment("Reservation price")]
        public decimal TotalPrice { get; set; }

        [Required]
        [DefaultValue("Pending")]
        [Comment("Reservation status")]
        public string Status { get; set; } = null!;
    }
}