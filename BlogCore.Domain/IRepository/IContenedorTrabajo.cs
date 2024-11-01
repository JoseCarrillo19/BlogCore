namespace BlogCore.Domain.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        ICategoriaRepository Categoria {  get; }

        IArticuloRepository Articulo { get; }

        ISliderRepository Slider { get; }

        IUsuarioRepository Usuario { get; }

        void Save();
    }
}
