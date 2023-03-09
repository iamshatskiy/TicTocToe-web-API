using TicTacToe.Entities;
using TicTacToe.Models;
using TicTacToe.Repository;

namespace TicTacToe.Services
{
    public interface IPlayFieldService
    {
        State Update(UpdatePlayFieldRequest updateModel); //done
        List<PFModel> GetAll(); //done
        PFModel GetById(int id); //done
        
        public bool CheckCoords(int n, int m); //done
        void DeletePlayField(PFModel pf); //done
        PlayField GetByIdPlayField(int id); //done
        void CreatePlayField(PFModel pfModel); //done
    }
}
