namespace ClinicaNuevoRosario.API.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Details { get; set; }

        public CodeErrorException(int statusErrorCode, string? errorMessage = null, string? details = null) : base(statusErrorCode, errorMessage)
        {
            Details = details;
        }
    }
}
