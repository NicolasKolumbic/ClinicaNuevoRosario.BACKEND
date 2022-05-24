namespace ClinicaNuevoRosario.API.Errors
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusErrorCode, string? errorMessage = null)
        {
            StatusErrorCode = statusErrorCode;
            ErrorMessage = errorMessage ?? GetDefaultMessageStatusCode(statusErrorCode);
        }

        public int StatusErrorCode { get; set; }
        public string? ErrorMessage { get; set; } = string.Empty;

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "La peticion tiene errores",
                401 => "No autorizado",
                404 => "No se encontro el recurso solicitado",
                500 => "Se producieron errores en el servidor",
                _ => string.Empty
            };
        }
    }
}
