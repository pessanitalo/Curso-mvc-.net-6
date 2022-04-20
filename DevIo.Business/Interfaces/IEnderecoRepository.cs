using DevIO.Bussiness.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
