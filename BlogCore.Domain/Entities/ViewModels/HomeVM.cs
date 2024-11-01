namespace BlogCore.Domain.Entities.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider>? Sliders { get; set; }
        public IEnumerable<Articulo>? Articulo { get; set; }

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
