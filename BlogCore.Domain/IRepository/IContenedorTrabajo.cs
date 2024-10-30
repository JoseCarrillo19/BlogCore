namespace BlogCore.Domain.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        ICategoriaRepository Categoria {  get; }

        void Save();
    }
}
