using Domain.Entities;

namespace Domain.Dtos;

public class BookReviewDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<ReviewDto> Reviews { get; set; }
    public List<BookDto> Books { get; set; }
}