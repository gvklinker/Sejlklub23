﻿using System.ComponentModel.DataAnnotations;

namespace Sejlklub23.Models
{
    public class Events
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartOfEvent { get; set;}
        [Required]
        public int EventDuration { get; set;}
        [Required]
        public string Address { get; set; }

        public Events (int id, string title, string description, DateTime startOfEvent, int eventDuration, string address)
        {
            Id = id;
            Title = title;
            Description = description;
            StartOfEvent = startOfEvent;
            EventDuration = eventDuration;
            Address = address;
        }
    }
}
