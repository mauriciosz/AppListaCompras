using AppListaCompras.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Libraries.Validations
{
    public class AddItemValidator : AbstractValidator<Product?> // utilita o AbastractValidator do FluentValidation que foi instalado, para validar alguma coisa, nesse caso, o Product
    {
        public AddItemValidator() 
        {   
            // RuleFor => 'Regra para' .. validação de algum objecto/campo/etc..
            // Aqui estamos validando um Product e é utilizado uma lambda 'x=>x' para pegar as propriedades do Product. Nessa caso o 'Name'.
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo 'Nome' é obrigatório!")  // valida se não está vazio e retorna mensagem de erro..
                .MinimumLength(3).WithMessage("O campo 'Nome' deve ter pelo menos 3 caracteres!"); // valida tamanho mínimo de caracteres para o 'Name'

            When(x => x.HasCaugth, () => // Faz as validações abaixo APENAS se o usuário marcou o produto como selecionado.
            {
                RuleFor(x => x.Quantity)
                    .NotEmpty().WithMessage("O campo 'Quantidade' é obrigatório!")
                    .Must(MaiorQueZero).WithMessage("O campo 'Quantidade' deve ser maior que 0 (zero)!");

                RuleFor(x => x.Price)
                    .NotEmpty().WithMessage("O campo 'Preço' é obrigatório!")
                    .Must(MaiorQueZero).WithMessage("O valor do produto deve ser maior que R$ 0,00 !");
            });
        }

        // NOTA : repare na validação acima tem um 'Must()' que chama a função abaixo. Ou seja, é uma forma de chamar uma validação exclusiva...
        // E consigo usá-la na validação de diversos campos..
        private bool MaiorQueZero(decimal quantity)
        {
            return quantity > 0;
        }

    }
}
