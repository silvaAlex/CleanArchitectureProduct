namespace CleanArchitectureProduct.Exception
{
    public class ErrorOnValidateException : CleanArchitectureProductException
    {
        public ErrorOnValidateException(string message) : base(message) { }
    }
}