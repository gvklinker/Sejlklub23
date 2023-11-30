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
        public Boat BoatId{ get; set; }
        
        [Required]
        public Member MemberId{ get; set; }
        
        public Reservation(int id, DateTime startOfLoacation, int locationDuration, bool isReturned, Boat boatId, Member memberId)
        {
            Id = id;
            StartOfLocation = startOfLoacation;
            LocationDuration = locationDuration;
            IsReturned = isReturned;
            BoatId = boatId;
            MemberId = memberId;
        }
    }
}
