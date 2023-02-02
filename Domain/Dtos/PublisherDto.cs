using Domain.Entities;

namespace Domain.Dtos;

public class PublisherDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<BookDto> Books { get; set; }




}