

namespace JWT_Authentication_Web_Api.Models
    {
    public class ResponseDto
        {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }
        public dynamic? Result { get; set; }
        }
    }
