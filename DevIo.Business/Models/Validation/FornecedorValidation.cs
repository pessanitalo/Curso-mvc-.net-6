using DevIO.Business.Models.Validations.Documentos;
using DevIO.Bussiness.Models;
using FluentValidation;

namespace DevIO.Business.Models.Validation
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("Campo Obrigatório")
                .Length(2, 100)
                .WithMessage("Campo {PropertyName} precisa ter entre {MinLength} {MaxLength} caracteres");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
             {
                 RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                 .WithMessage("O campo documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                 RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                 .WithMessage("O Documento fornecido é inválido.");
             });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                 .WithMessage("O campo documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                  RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                 .WithMessage("O Documento fornecido é inválido.");
            });
        }
    }
}
