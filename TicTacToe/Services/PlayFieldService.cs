using AutoMapper;
using TicTacToe.Entities;
using TicTacToe.Models;
using TicTacToe.Repository;

namespace TicTacToe.Services
{
    public class PlayFieldService : IPlayFieldService
    {
        private readonly IRepositoryPF _pf;
        private readonly IMapper _mapper;

        public PlayFieldService(IRepositoryPF pf, IMapper mapper)
        {
            _pf = pf;
            _mapper = mapper;
        }

        public bool CheckCoords(int n, int m)
        {
            return (n >= 0 && n <= 2 && m <= 2 && m >= 0) ? true : false;
        }

        
        
        public void CreatePlayField(PFModel pfModel)
        {
            if (pfModel == null)
                return;

            var pf = _mapper.Map<PlayField>(pfModel);

            _pf.Add(pf);
        }

        public void DeletePlayField(PFModel pf)
        {
            _pf.Remove(_mapper.Map<PlayField>(pf));
        }

        public List<PFModel> GetAll()
        {
            List<PFModel> res = new List<PFModel>();

            foreach (PlayField p in _pf.GetAll())
                res.Add(_mapper.Map<PFModel>(p));

            return res;
        }

        public PFModel GetById(int id)
        {
            return _mapper.Map<PFModel>(_pf.Get(id));
        }

        public PlayField GetByIdPlayField(int id)
        {
            return _pf.Get(id);
        }

        public State Update(UpdatePlayFieldRequest updateModel)
        {
            if (CheckCoords(updateModel.N, updateModel.M))
            {
                var pf = _pf.GetAll().FirstOrDefault(p => p.PFuk == updateModel.PFuk);

                if (pf != null && pf.PF[updateModel.N * 3 +updateModel.M] == 0)
                {
                    pf.PF[updateModel.N * 3 + updateModel.M] = (pf.PFturn % 2 == 0) ? 1 : 2;

                    pf.PFturn++;

                    return _pf.Update(pf);
                }
                else
                {
                    return State.NotEmpty;
                }
            }
            return State.Unable;
        }

    }
}
