// Exemple du design pattern Unit Of Work
// N'est pas utilis� dans cette application

using Miam.Domain.Entities;

namespace Miam.DataLayer
{
    public interface IUnitOfWork
    {
        IEntityRepository<Writer> WriterRepository { get; }
        IEntityRepository<Review> ReviewRepository { get; }
        IEntityRepository<Restaurant> RestaurantRepository { get; }
        IEntityRepository<Tag> TagRepository { get; }
        IEntityRepository<User> UserRepository { get; }

        void Commit();
    }
}