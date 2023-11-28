using System.ComponentModel.DataAnnotations;

namespace Sejlklub23.Models
{
    public class Boats
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Name { get; set; }

        public Boats (int id, string model, string name)
        {
            Id = id;
            Model = model;
            Name = name;
        }
    }
}
