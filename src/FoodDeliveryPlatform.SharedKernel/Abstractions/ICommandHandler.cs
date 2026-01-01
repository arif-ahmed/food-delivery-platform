using System.Collections.Generic;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryPlatform.SharedKernel.Abstractions
{
    public sealed record Result(bool IsSuccess, IReadOnlyCollection<string>? Errors = null);

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
    }
}
