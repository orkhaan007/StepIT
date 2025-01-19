namespace Redis.UI.Dtos;

public class RepsonseDTO
{
    public List<MovieDTO>? Search {  get; set; }
    public string? TotalResults {  get; set; }
    public string? Response {  get; set; }
}
