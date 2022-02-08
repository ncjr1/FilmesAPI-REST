using AutoMapper;
using FIlmesAPI.Data.Dtos;
using FIlmesAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FIlmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<FilmeProfile, ReadFilmeDTO>();
            CreateMap<UpdateFilmeDTO, Filme>();
        }
    }
}
