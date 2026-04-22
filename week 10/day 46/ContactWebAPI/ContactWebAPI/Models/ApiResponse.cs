namespace ContactWebAPI.Models
{
    /// <summary>
    /// Standardised API response envelope used across all endpoints.
    /// Makes it easy to validate structure in Postman tests.
    /// </summary>
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApiResponse<T> Ok(T data, string message = "Success")
            => new() { Success = true, Message = message, Data = data };

        public static ApiResponse<T> Fail(string message)
            => new() { Success = false, Message = message };
    }
}
