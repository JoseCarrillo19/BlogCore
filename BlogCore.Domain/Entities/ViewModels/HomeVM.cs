namespace BlogCore.Domain.Entities.ViewModels
{
    public class HomeVM
    {
       public IEnumerable<Slider>? Sliders { get; set; }
        public IEnumerable<Articulo>? Articulo { get; set; }
    }
}
