using FilmesAPI.Data.Dtos;
using FIlmesAPI.Models;
using AutoMapper;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<CinemaProfile, ReadCinemaDTO>();
            CreateMap<UpdateCinemaDTO, Cinema>();
        }
    }
}
