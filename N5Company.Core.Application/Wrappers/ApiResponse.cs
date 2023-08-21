namespace N5Company.Core.Application.Wrappers
{
    public class ApiResponse<T>
    {
        public ApiResponse() { }

        public ApiResponse(T data, string? message = null) 
        {
            IsSuccessful = true;
            Data = data;
            Message = message;
        }

        public ApiResponse(string message)
        {
            IsSuccessful = false;
            Message = message;
        }

        public bool IsSuccessful { get; set; }
        public string? Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
        public T? Data { get; set; }
    }
}
