using BlogCore.Domain.Entities;

namespace BlogCore.Domain.IRepository
{
    public interface ISliderRepository : IRepository<Slider>
    {
        void Update(Slider slider);
    }
}
