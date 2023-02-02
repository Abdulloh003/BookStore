namespace Domain.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PublisherId { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public string FullName { get; set; }
    public int SubjectId { get; set; }
    public string Subject { get; set; }
}