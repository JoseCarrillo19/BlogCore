namespace BlogCore.Domain.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        ICategoriaRepository Categoria {  get; }

        IArticuloRepository Articulo { get; }

        ISliderRepository Slider { get; }

        void Save();
    }
}
