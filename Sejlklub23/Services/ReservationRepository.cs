using Sejlklub23.Interfaces;
using Sejlklub23.Models;
using Sejlklub23.Helpers;
namespace Sejlklub23.Services
{
    public class ReservationRepository : IReservationRepository
    {

        private string fileNameJson = "@Data/Reservations.json"; 
        public void CreateReservation(Reservation res)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservation(int id)
        {
            List<Reservation> reservations = GetAllReservations();

        }

        public List<Reservation> GetAllReservations()
        {
            return JsonFileReader<Reservation>.ReadJson(fileNameJson);
        }

        public Reservation GetReservation(int id)
        {
            return GetAllReservations().Find(x => x.Id == id);
        }

        public void UpdateReservation(Reservation res)
        {
            throw new NotImplementedException();
        }
    }
}
