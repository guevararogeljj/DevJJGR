namespace DevJJGRCore.Common.Models
{
    public class ResultDto
    {
        public ResultDto()
        {
            this.Success = true;
            this.Code = StatusCode.OK;
            this.Message = string.Empty;
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
        }
        public void SetStatus(StatusCode status)
        {
            this.Code = status;
        }
        public StatusCode Code { get; set; }
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public List<string> Errors { get; protected set; }
    }
}
