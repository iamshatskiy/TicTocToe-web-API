using TicTacToe;
using TicTacToe.Entities;
using TicTacToe.Repository.Exceptions;

namespace TicTacToe.Repository
{
    public class RepositoryPF : IRepositoryPF
    {
        private TicTacToeDbContext db;
        public RepositoryPF()
        {
            db = new TicTacToeDbContext();
        }
        public RepositoryPF(TicTacToeDbContext _db)
        {
            db = _db;
        }

        public int[] GetZeroPlayField()
        {
            int[] mtrx = new int[9];
            for (int i = 0; i < 9; i++)
            {
                
                    mtrx[i] = 0;
            }
            return mtrx;
        }
        public void Add(PlayField pf)
        {
            if (pf == null)
                throw new PlayFieldAddException();

            if (pf.PFturn < 0) 
                throw new PlayFieldAddException(pf.PFturn);

            int NewUK = this.db.PlayFields.Any() ? this.db.PlayFields.Max(a => a.PFuk) + 1 : 1;
            pf.PFuk = NewUK;
            pf.PFturn = 0;
            pf.PF = GetZeroPlayField();

            this.db.PlayFields.Add(pf);
            this.db.SaveChanges();
        }

        public PlayField Get(int PFuK)
        {
            var pf = this.db.PlayFields.Where(f => f.PFuk == PFuK).FirstOrDefault();

            if (pf == null)
                throw new PlayFieldNotFoundException(PFuK);

            return pf;
        }

        public IEnumerable<PlayField> GetAll()
        {
            return this.db.PlayFields;
        }

        public void Remove(PlayField pf)
        {
            var playField = this.db.PlayFields.Where(p => p.PFuk == pf.PFuk).FirstOrDefault();

            if (playField == null)
                throw new PlayFiledDeleteException(pf.PFuk);

            this.db.PlayFields.Remove(playField);
            this.db.SaveChanges();
        }

        public State Update(PlayField pf)
        {
            var playField = this.db.PlayFields.Where(p => p.PFuk == pf.PFuk).FirstOrDefault();

            if (playField == null)
                throw new PlayFieldUpdateException(pf.PFuk);

            playField.PFuk = pf.PFuk;
            playField.PFturn = pf.PFturn;
            playField.PF = pf.PF;

            this.db.SaveChanges();

            State winner = (State)CheckWinner(pf.PFturn, pf.PF);
            
            if (winner == State.None)
            {
                //ничья
                if (isPFfull(pf.PF))
                {
                    Remove(pf);
                    return State.Draw;
                }
            }
            else
            {
                Remove(pf);
                return winner;
            }
            return winner;
        }

        public bool isPFfull(int[] pf)
        {
            for (int i = 0; i < 9; i++) 
            {
                
                    if (pf[i] == 0)
                        return false;
            }
            return true;
        }
        public int CheckWinner(int turn, int[] pf)
        {
            turn--;
            int marker = (turn % 2 == 0) ? 1 : 2;

            for (int i = 0; i < 3; i++)
            {
                //по горизонтали
                if (pf[i * 3 + 0] == marker && pf[i * 3 + 1] == marker && pf[i * 3 + 2] == marker)
                {
                    return (turn % 2 + 1);
                }
                //по вертикали
                if (pf[0 * 3 + i] == marker && pf[1 * 3 + i] == marker && pf[2 * 3 + i] == marker)
                {
                    return (turn % 2 + 1);
                }
            }

            //по диагонали
            if ((pf[0] == marker && pf[4] == marker && pf[8] == marker) ||
                (pf[6] == marker && pf[4] == marker && pf[2] == marker))
            {
                return (turn % 2 + 1);
            }
            return -1; //игрок не выиграл
        }
    }
}
