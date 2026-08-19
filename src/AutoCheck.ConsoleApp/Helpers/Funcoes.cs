namespace AutoCheck.ConsoleApp.Helpers
{
    public static class Funcoes
    {
        private static int quantidadeCaracteresPorLinha = 80;
        public static void ExibirLinhaDivisoria(char caracter)
        {
            string tracoDuplo = new string(caracter, quantidadeCaracteresPorLinha);
            Console.WriteLine(tracoDuplo);
        }

        public static void CentralizarTexto(string texto, int tamanhoTotal)
        {
            int quantidade = (tamanhoTotal - texto.Length) / 2;
            string espacos = new string(' ', quantidade);
            Console.WriteLine($"{espacos}{texto}");            
        }
        
        public static void ExibirCabecalho(string titulo)
        {
            ExibirLinhaDivisoria('=');
            CentralizarTexto(titulo.ToUpper(), quantidadeCaracteresPorLinha);
            ExibirLinhaDivisoria('=');
        }
        
        public static void ExibirCabecalhoLinhaSimples(string titulo)
        {
            ExibirLinhaDivisoria('-');
            CentralizarTexto(titulo.ToUpper(), quantidadeCaracteresPorLinha);
            ExibirLinhaDivisoria('-');
        }
        
    }
}