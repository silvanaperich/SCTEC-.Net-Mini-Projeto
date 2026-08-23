namespace AutoCheck.ConsoleApp.Helpers
{
    public static class Funcoes
    {
        private static int quantidadeCaracteresPorLinha = 85;
        public static void ExibirLinhaDivisoria(char caracter)
        {
            string tracoDuplo = new string(caracter, quantidadeCaracteresPorLinha);
            Console.WriteLine(tracoDuplo);
        }
        public static void ExibirLinhaDivisoriaSimples()
        {
            ExibirLinhaDivisoria('-');
        }

        public static void CentralizarTexto(string texto, int tamanhoTotal)
        {
            int quantidade = (tamanhoTotal - texto.Length) / 2;
            string espacos = new string(' ', quantidade);
            Console.WriteLine($"{espacos}{texto}");
        }

        public static void ExibirTextoFormatadoEstiloSumario(string textoEsquerdo, string textoDireito, char caracterPreenchimento)
        {
            int tamanhoPreenchimento = quantidadeCaracteresPorLinha - textoEsquerdo.Length - textoDireito.Length;
            string preenchimento = new string(caracterPreenchimento, tamanhoPreenchimento);
            Console.WriteLine($"{textoEsquerdo}{preenchimento}{textoDireito}");
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

        public static void ExibirTextoComIndentacaoUmNivel(string texto)
        {
            Console.WriteLine($"   {texto}");
        }

        public static string SolicitarValorTexto(string texto)
        {
            Console.Write($"{texto}");
            string textoDigitado = Console.ReadLine();
            while (string.IsNullOrEmpty(textoDigitado.Trim()))
            {
                ExibirTextoComDefinicaoDeCor("Campo obrigatório! Digite: ", true, ConsoleColor.Red);
                textoDigitado = Console.ReadLine();
            }
            return textoDigitado;
        }

        public static int SolicitarNumeroInteiro(string texto)
        {
            Console.Write($"{texto}");
            string textoDigitado = Console.ReadLine();
            int inteiro;
            while (!int.TryParse(textoDigitado.Trim(), out inteiro))
            {
                ExibirTextoComDefinicaoDeCor("Obrigatório informar um valor numérico inteiro! Digite novamente: ", true, ConsoleColor.Red);
                textoDigitado = Console.ReadLine();
            }
            return inteiro;
        }

        public static double SolicitarNumeroDecimal(string texto)
        {
            Console.Write($"{texto}");
            string textoDigitado = Console.ReadLine();
            double numero;
            while (!double.TryParse(textoDigitado.Trim(), out numero))
            {
                ExibirTextoComDefinicaoDeCor("Obrigatório informar um valor numérico inteiro ou decimal! Digite novamente: ", true, ConsoleColor.Red);
                textoDigitado = Console.ReadLine();
            }
            return numero;
        }

        public static string RetornarEmojiConformeStatus(string status)
        {
            switch (status.ToLower())
            {
                case "bom":
                    return "🟩";
                case "regular":
                    return "🟨";
                default:
                    return "🟥";
            }
        }

        public static void ExibirTextoComDefinicaoDeCor(string texto, bool mesmaLinha, ConsoleColor cor)
        {
            ConsoleColor corAtual = Console.ForegroundColor;
            Console.ForegroundColor = cor;
            if (mesmaLinha)
            {
                Console.Write(texto);
            }
            else
            {
                Console.WriteLine(texto);
            }
            Console.ForegroundColor = corAtual;
        }

    }
}