using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class UserService
{
    private readonly DataContext _contex;
    private readonly IMapper _mapper;

    public UserService(DataContext contex, IMapper mapper)
    {
        _contex = contex;
        _mapper = mapper;
    }

    public async Task<Response<List<BookDto>>> GetAuthorandBooks()
    {
        var first = (from b in _contex.Books
            join ba in _contex.AuthorBooks on b.Id equals ba.BookId
            join a in _contex.Authors on ba.AuthorId equals a.Id
            select new BookDto()
            {
                Id = b.Id,
                Title = b.Title,
                FullName = string.Concat(a.Firstname, " ", a.Lastname),
                PublisherId = b.PublisherId,
                SubjectId = b.SubjectId,
                PublishDate = b.PublishDate,
            }).ToList();
        return new Response<List<BookDto>>(first);
    }
}