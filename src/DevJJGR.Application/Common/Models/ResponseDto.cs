using System.Text.Json.Serialization;

namespace DevJJGRCore.Common.Models
{
    public class ResponseDto<T>
    {
        public ResponseDto()
        {
            this.Errors = new List<string>();
            this.Success = true;
        }
        public ResponseDto(T data, string message = "")
        {
            this.Data = data;
            this.Message = message;
            this.Code = StatusCode.OK;
            this.Errors = new List<string>();
            this.Success = true;
        }
        public ResponseDto(string message, StatusCode code)
        {
            this.Success = false;
            this.Message = message;
            this.Code = code;
            this.Errors = new List<string>();
        }
        public void SetMessage(string message)
        {
            this.Success = false;
            this.Message = message;
        }
        public void SetStatusError(string message, StatusCode status)
        {
            this.Success = false;
            this.Message = message;
            this.Code = status;
        }
        public void SetErrors(List<string> errors)
        {
            this.Errors = errors;
        }
        public void AddError(string error)
        {
            this.Errors.Add(error);
            this.Success = false;
        }
        public void SetData(T data, StatusCode status)
        {
            this.Data = data;
            this.Code = status;
        }
        public void SetStatusCode(StatusCode status)
        {
            this.Code = status;
        }

        [JsonIgnore]
        public StatusCode Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
