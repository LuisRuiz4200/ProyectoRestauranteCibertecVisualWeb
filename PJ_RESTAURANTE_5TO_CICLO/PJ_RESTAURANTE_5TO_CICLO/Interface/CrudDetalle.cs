namespace PJ_RESTAURANTE_5TO_CICLO.Interface
{
    public interface CrudDetalle<T>
    {
        List<T> listar();
        T buscar(int idHeredado, int idPropio);
        string agregar(T entity);
        string editar(T entity);
        string eliminar(T entity);
    }
}
