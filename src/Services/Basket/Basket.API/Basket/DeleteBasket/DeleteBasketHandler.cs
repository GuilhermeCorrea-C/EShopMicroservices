
namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeletBasketResult>;

    public record DeletBasketResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }

    public class DeleteBasketHandler(IBasketRepository repository)
        : ICommandHandler<DeleteBasketCommand, DeletBasketResult>
    {
        public async Task<DeletBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            //TODO: delete basket from database and cache
            await repository.DeleteBasket(command.UserName, cancellationToken);

            return new DeletBasketResult(true);
        }
    }
}
