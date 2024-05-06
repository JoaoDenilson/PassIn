namespace PassIn.Communication.Requests;
public class RequestConcertJson
{
    public string Title { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public int MaximumAttendees { get; set; }
}
