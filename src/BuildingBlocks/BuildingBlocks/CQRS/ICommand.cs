using MediatR;
namespace BuildingBlocks.CQRS;

public interface ICommand<out TResponse> : IQuery<TResponse>
                                           where TResponse : notnull
{
}

public interface ICommand : ICommand<Unit>
{
}
