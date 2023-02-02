using AutoMapper;
using Domain.Dtos;
using Domain.Entities;


namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<PublisherDto, Publisher>();
        CreateMap<Publisher, PublisherDto>();
        CreateMap<BookDto, Book>();
        CreateMap<Book, BookDto>();
        CreateMap<ReviewDto, Review>();
        CreateMap<Review, ReviewDto>();
        
    }
}