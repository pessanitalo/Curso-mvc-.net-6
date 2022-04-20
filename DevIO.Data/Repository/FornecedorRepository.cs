using DevIO.Bussiness.Interfaces;
using DevIO.Bussiness.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking().Include(f => f.Endereco).
                FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                 .Include(f => f.Produtos)
                 .Include(f => f.Endereco)
                 .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
