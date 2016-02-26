namespace GeekDinner.ClientModels
{
    public class RsvpResult
    {
        public RsvpResult(string status)
        {
            Status = status;
        }

        public string Status { get; set; }
    }
}
