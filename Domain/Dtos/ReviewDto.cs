using Domain.Entities;

namespace Domain.Dtos;

public class ReviewDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public int UserId { get; set; }
    public string User { get; set; }
    public string FullName { get; set; }

}