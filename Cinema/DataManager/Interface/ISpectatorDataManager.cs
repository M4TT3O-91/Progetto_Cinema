using Cinema.Models;

namespace Cinema.DataHelper.Interface
{
    public interface ISpectatorDataManager
    {
        public int AddSpectator(SpectatorsViewModels spectator);
        public bool DeleteSpectator(int id);
        public void AddSpectatorToMovieRoom(int roomID);
    }
}
