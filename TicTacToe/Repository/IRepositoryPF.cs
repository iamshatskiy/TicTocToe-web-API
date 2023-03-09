using TicTacToe.Entities;

namespace TicTacToe.Repository
{
    public enum State 
    {
        Unable = -3,
        NotEmpty,
        None,
        Draw,
        First,
        Second
    };

    public interface IRepositoryPF
    {
        public int CheckWinner(int turn, int[] pf);
        void Add(PlayField pf);
        IEnumerable<PlayField> GetAll();
        PlayField Get(int PFuK);
        void Remove(PlayField pf);
        State Update(PlayField pf);
    }
}
