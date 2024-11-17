namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class ProcessFileResponse
    {
        public string Message { get; set; }
        public List<string> NewUsers { get; set; }

        public ProcessFileResponse(string message, List<string> newUsers)
        {
            NewUsers = newUsers;
            Message = message;
        }
    }
}
