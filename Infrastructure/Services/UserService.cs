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
            join p in _contex.Publishers on b.PublisherId equals p.Id
            orderby b.PublishDate
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

    public async Task<Response<List<PublisherDto>>> GetPublishersBook()
    {
        var second = (from p in _contex.Publishers
            join b in _contex.Books on p.Id equals b.PublisherId
            join a in _contex.Authors on b.Id equals a.Id
            group b by new {p.Id, p.Name} into g
            select new PublisherDto()
            {
                Id = g.Key.Id,
                Name = g.Key.Name,
                Books = _mapper.Map<List<BookDto>>(g.ToList())
            }).ToList();
        return new Response<List<PublisherDto>>(second);
    }

    public async Task<Response<List<AuthorDto>>> GetAuthorbooks()
    {
        var third = (from a in _contex.Authors
            join ba in _contex.AuthorBooks on a.Id equals ba.AuthorId
            join b in _contex.Books on ba.BookId equals b.Id
            group b by new {a.Id,FullName = string.Concat(a.Firstname, " ", a.Lastname)} into g
            select new AuthorDto()
            {
                Id = g.Key.Id,
                FullName = g.Key.FullName,
                Books = _mapper.Map<List<BookDto>>(g.ToList())
                
            }).ToList();
        return new Response<List<AuthorDto>>(third);
    }

    public async Task<Response<List<BookReviewDto>>> GetBookandReviews()
    {
        var Fourth = (from b in _contex.Books
                join r in _contex.Reviews on b.Id equals r.BookId
                join u in _contex.Users on r.UserId equals u.Id
                group r by new {b.Id,b.Title} into g
                    select  new BookReviewDto()
                    {
                        Id = g.Key.Id,
                        Title = g.Key.Title,
                        Reviews = (from r in g
                            join u in _contex.Users on r.UserId equals u.Id
                            select new ReviewDto()
                            {
                                Id = r.Id,
                                Title = r.Title,
                                Comment = r.Comment,
                                Rating = r.Rating,
                                UserId = r.UserId,
                                FullName = string.Concat(u.FirstName, " ", u.LastName)
                            }).ToList(),
                    }).ToList();
                
        return new Response<List<BookReviewDto>>(Fourth);
    }
    
    public async Task<Response<List<AuthorDtoV2>>> GetBookOfAuthot()
    {
        var secon = (from a in _contex.Authors
            join ab in _contex.AuthorBooks on a.Id equals ab.AuthorId
            join b in _contex.Books  on ab.BookId equals b.Id 
             
            group b by new {a.Id, FullName= string.Concat(a.Firstname, "  ", a.Lastname)} into g
            select new AuthorDtoV2()
            {
                Id = g.Key.Id,
                FullName = g.Key.FullName ,
                Books = g.Count()
            }).ToList();
        return new Response<List<AuthorDtoV2>>(secon);
    }


 }