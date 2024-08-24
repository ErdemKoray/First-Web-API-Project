namespace LibraryManagement.Models
{
    public class Response
    {
        public bool Success { get; set; } = true;

        public string Message { get; set; } = "Succesfull";

        public Object Data { get; set; } = null;
        public Response() { }
        public Response(bool success, string message, Object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
