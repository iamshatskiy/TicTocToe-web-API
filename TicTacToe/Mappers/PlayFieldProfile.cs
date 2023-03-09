using AutoMapper;
using TicTacToe.Entities;
using TicTacToe.Models;
using TicTacToe.Mappers;


namespace TicTacToe.Mappers
{

    public class PlayFieldProfile : Profile
    {
        public PlayFieldProfile()
        {
            
            CreateMap<PFModel, PlayField>()
                .ForMember(dst => dst.PFuk, opt => opt.MapFrom(src => src.ID))
                .ForMember(dst => dst.PFturn, opt => opt.MapFrom(src => src.Turn))
                .ForMember(dst => dst.PF, opt => opt.MapFrom(src => src.PF))
                ;
            CreateMap<PlayField,PFModel>()
                .ForMember(dst => dst.ID, opt => opt.MapFrom(src => src.PFuk))
                .ForMember(dst => dst.Turn, opt => opt.MapFrom(src => src.PFturn))
                .ForMember(dst => dst.PF, opt => opt.MapFrom(src => src.PF))
                ;
        }
    }
}
