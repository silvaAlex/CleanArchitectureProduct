
namespace CleanArchitectureProduct.Communication.Response
{
    public  class ResponseErrorJSON
    {
        public string Message { get; set; } = string.Empty;
        public ResponseErrorJSON(string message) 
        { 
            Message = message;
        }
    }
}
