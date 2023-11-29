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
        /*Missing list of Boat
        [Required]
        public Boats BoatId{ get; set; }
        */
        /*Missing list of Members
        [Required]
        public Members MemberId{ get; set; }
        */
        public Reservation(int id, DateTime startOfLoacation, int locationDuration, bool isReturned)
        {
            Id = id;
            StartOfLocation = startOfLoacation;
            LocationDuration = locationDuration;
            IsReturned = isReturned;
        }
    }
}
