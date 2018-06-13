using Application.TorreHanoi.Message;

namespace Application.TorreHanoi.Interface
{
    public interface ITorreHanoiApplicationService
    {
        AdicionarNovoProcessoResponse AdicionarNovoProcesso(int numeroDiscos);

        ObterProcessoPorResponse ObterProcessoPor(string id);

        ObterTodosProcessosResponse ObterTodosProcessos();

        ObterImagemProcessoPorResponse ObterImagemProcessoPor(string id);
    }
}
