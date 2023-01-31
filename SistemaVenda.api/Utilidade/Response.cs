namespace SistemaVenda.api.Utilidade
{
    public class Response<T>
    {
        public bool status { get; set; }
        public T valor { get; set; }

        public string msg { get; set; }

    }
}
