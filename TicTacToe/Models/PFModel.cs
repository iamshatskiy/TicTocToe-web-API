namespace TicTacToe.Models
{
    
    public class PFModel
    {
        public int ID { get; set; }
        public int Turn { get; set; }
        public int[] PF { get; set; }
        public PFModel() { }
        public PFModel(int _id, int _turn, int[] _pf)
        {
            ID = _id;
            Turn = _turn;
            PF = _pf;
        }
    }
}
