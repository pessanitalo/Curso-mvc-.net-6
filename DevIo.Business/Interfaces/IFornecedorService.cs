using DevIO.Bussiness.Models;

namespace DevIO.Business.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Remover(Guid id);

        //fornecedor possui endereço
        Task AtualizarEndereco(Endereco endereco);
    }
}
