using Sejlklub23.Models;

namespace Sejlklub23.Interfaces
{
    public interface IReservationRepository
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservation(int id);
        void CreateReservation(Reservation res);
        void DeleteReservation(Reservation res);
        void UpdateReservation(Reservation res);
    }
}
