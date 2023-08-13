namespace PJ_RESTAURANTE_5TO_CICLO.Interface
{
    public interface Crud<T>
    {
        List<T> listar();
        T? buscar (int id);
        string agregar (T entity);
        string editar (T entity);
        string eliminar (int id);
    }
}
