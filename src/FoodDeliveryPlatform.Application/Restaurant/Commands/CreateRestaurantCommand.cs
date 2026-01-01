using FoodDeliveryPlatform.Application.Restaurant.Abstractions;
using FoodDeliveryPlatform.SharedKernel.Abstractions;

namespace FoodDeliveryPlatform.Application.Restaurant.Commands
{
    public class CreateRestaurantCommand : ICommand
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public bool IsOpen { get; set; }
    }

    public class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Result> HandleAsync(CreateRestaurantCommand command, CancellationToken cancellationToken = default)
        {
            var restaurant = Domain.Restaurant.Restaurant.Create(command.Name);
            await _restaurantRepository.AddAsync(restaurant, cancellationToken);
            return new Result(true);
        }
    }
}
