using AutoMapper;
using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<ReadEnderecoDTO, EnderecoProfile>();
            CreateMap<UpdateEnderecoDTO, Endereco>();
        }
    }
}
