using FoodDeliveryPlatform.Application.Restaurant.Abstractions;
using FoodDeliveryPlatform.Domain.Restaurant.Events;
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
        private readonly IServiceBus _serviceBus;
        
        public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository, IServiceBus serviceBus)
        {
            _restaurantRepository = restaurantRepository;
            _serviceBus = serviceBus;
        }

        public async Task<Result> HandleAsync(CreateRestaurantCommand command, CancellationToken cancellationToken = default)
        {
            RestaurantCreatedEvent restaurantCreatedEvent;

            var restaurant = Domain.Restaurant.Restaurant.Create(out restaurantCreatedEvent, command.Name);
            await _restaurantRepository.AddAsync(restaurant, cancellationToken);

            restaurantCreatedEvent = new RestaurantCreatedEvent(restaurant.Id, restaurant.Name);

            await _serviceBus.PublishAsync(restaurantCreatedEvent, cancellationToken);

            return new Result(true);
        }
    }
}
