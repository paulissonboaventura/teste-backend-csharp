using Application.TorreHanoi.Message;

namespace Application.TorreHanoi.Validation
{
    internal static class AdicionarNovoProcessoValidation
    {
        internal static AdicionarNovoProcessoResponse Validation(this int numeroDiscos)
        {
            var response = new AdicionarNovoProcessoResponse();

            if (numeroDiscos >= 1)
            {
                return response;
            }
            response.AdicionarMensagemDeErro("É necessario ao menos um disco para executar a torre de hanoi");
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;

            return response;
        }
    }
}
