using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Models
{
    public class UpdatePlayFieldRequest
    {
        [Required]
        public int PFuk { get; set; }

        [Required]
        public int N { get; set; }
        
        [Required]
        public int M { get; set; }
        public UpdatePlayFieldRequest() { }
        public UpdatePlayFieldRequest(int _PFuk, int _n, int _m)
        {
            PFuk = _PFuk;
            N = _n;
            M = _m;
        }
    }
}
