namespace Comex
{
    public class Cliente
    {
        public string Nome { get; private set; }

        public Cliente(string nome)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        }
    }
}
