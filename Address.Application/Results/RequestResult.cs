using Address.Application.DTOs;

namespace Address.Application.Results
{
    public class RequestResult
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; } = string.Empty;
        public object Data { get; private set; } = null!;

        public RequestResult Ok(object data)
        {
            this.StatusCode = 200;
            this.Message = "Request succeeded";
            this.Data = data;
            return this;
        }
        public RequestResult BadRequest(string detail, object data)
        {
            this.StatusCode = 400;
            this.Message = $"Fail in request. More details: {detail}";
            this.Data = data;
            return this;
        }
        public RequestResult BadRequest(string detail)
        {
            this.StatusCode = 400;
            this.Message = $"Fail in request. More details: {detail}";
            return this;
        }
    }
}