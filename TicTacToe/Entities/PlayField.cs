using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToe.Entities
{
    public partial class PlayField
    {
        public PlayField() { }
        public PlayField(int _PFuK, int _PFturn, int[] _PF)
        {
            PFuk = _PFuK;
            PFturn = _PFturn;
            PF = _PF;
        }
        public int PFuk { get; set; }
        public int PFturn { get; set; }
        public int[] PF { get; set; }

    }
}

