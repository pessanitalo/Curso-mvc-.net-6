using DevIO.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
