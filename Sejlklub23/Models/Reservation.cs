using System.ComponentModel.DataAnnotations;

namespace Sejlklub23.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartOfLocation { get; set; }
        [Required]
        public int LocationDuration { get; set;}
        [Required]
        public bool IsReturned { get; set; }
        [Required]
        public int BoatId{ get; set; }
        [Required]
        public int MemberId{ get; set; }
        
        public Reservation(int id, DateTime startOfLoacation, int locationDuration, bool isReturned)
        {
            Id = id;
            StartOfLocation = startOfLoacation;
            LocationDuration = locationDuration;
            IsReturned = isReturned;
        }
    }
}
