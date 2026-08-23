using AutoCheck.ConsoleApp.Helpers;
using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.UI;

namespace AutoCheck.ConsoleApp.Services
{
    public class MotorVistoria
    {
        private enum TipoVeiculo {
            Carro = 1,
            Moto = 2,
            Caminhao = 3
        };

        private TipoVeiculo SolicitarTipoVeiculo()
        {
            TipoVeiculo tipoVeiculo;

            Funcoes.ExibirLinhaDivisoriaSimples();
            Console.WriteLine("Qual o tipo do veículo para a vistoria?");
            Console.WriteLine("1 - Carro");
            Console.WriteLine("2 - Moto");
            Console.WriteLine("3 - Caminhão");
            Console.Write("Digite a opção desejada: ");
            string opcaoEscolhida = Console.ReadLine();

            while (!Enum.TryParse(opcaoEscolhida, out tipoVeiculo) || !Enum.IsDefined(tipoVeiculo))
            {
                Funcoes.ExibirTextoComDefinicaoDeCor("Opção inválida! Informe novamente o tipo de veículo desejado: ", true, ConsoleColor.Red);
                opcaoEscolhida = Console.ReadLine();
            };

            return tipoVeiculo;
        }

        private Carro InicializarDadosCarro()
        {
            Console.WriteLine("Informe os seguintes dados do Carro:");
            string marca = Funcoes.SolicitarValorTexto("Marca: ");
            string modelo = Funcoes.SolicitarValorTexto("Modelo: ");
            int ano = Funcoes.SolicitarNumeroInteiro("Ano: ");
            int quilometragem = Funcoes.SolicitarNumeroInteiro("Quilometragem: ");
            int quantidadePortas = Funcoes.SolicitarNumeroInteiro("Portas: ");

            Carro carro = new Carro(marca, modelo, ano, quilometragem, quantidadePortas);
            return carro;
        }

        private Moto InicializarDadosMoto()
        {
            Console.WriteLine("Informe os seguintes dados da Moto:");
            string marca = Funcoes.SolicitarValorTexto("Marca: ");
            string modelo = Funcoes.SolicitarValorTexto("Modelo: ");
            int ano = Funcoes.SolicitarNumeroInteiro("Ano: ");
            int quilometragem = Funcoes.SolicitarNumeroInteiro("Quilometragem: ");
            int cilindradas = Funcoes.SolicitarNumeroInteiro("Cilindradas: ");

            Moto moto = new Moto(marca, modelo, ano, quilometragem, cilindradas);
            return moto;
        }

        private Caminhao InicializarDadosCaminhao()
        {
            Console.WriteLine("Informe os seguintes dados da Moto:");
            string marca = Funcoes.SolicitarValorTexto("Marca: ");
            string modelo = Funcoes.SolicitarValorTexto("Modelo: ");
            int ano = Funcoes.SolicitarNumeroInteiro("Ano: ");
            int quilometragem = Funcoes.SolicitarNumeroInteiro("Quilometragem: ");
            int quantidadeEixos = Funcoes.SolicitarNumeroInteiro("Eixos: ");
            double capacidadeCargaToneladas = Funcoes.SolicitarNumeroDecimal("Capacidade (ton): ");

            Caminhao caminhao = new Caminhao(marca, modelo, ano, quilometragem, quantidadeEixos, capacidadeCargaToneladas);
            return caminhao;
        }

        private Veiculo InicializarDadosVeiculo(TipoVeiculo tipo)
        {
            Veiculo veiculo = null;

            switch (tipo)
            {
                case TipoVeiculo.Carro:
                    veiculo = InicializarDadosCarro();
                    break;
                case TipoVeiculo.Moto:
                    veiculo = InicializarDadosMoto();
                    break;
                case TipoVeiculo.Caminhao:
                    veiculo = InicializarDadosCaminhao();
                    break;
            }

            return veiculo;
        }

        private void AplicarChecklistVistoria(Veiculo veiculo)
        {
            List<string> checklist = veiculo.ObterChecklistObrigatorio();
            Funcoes.ExibirCabecalhoLinhaSimples("Iniciando o preenchimento do checklist de vistoria");

            foreach (string itemChecklist in checklist)
            {
                bool itemValido = false;
                while (!itemValido)
                {
                    string status = Funcoes.SolicitarValorTexto($"\"{itemChecklist}\" - Informe o Status: ");
                    try
                    {
                        veiculo.AdicionarItemVistoriado(itemChecklist, status);
                        itemValido = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Funcoes.ExibirTextoComDefinicaoDeCor(ex.Message, false, ConsoleColor.Red);
                    }
                }
            }
        }

        public Veiculo RealizarNovaVistoria()
        {
            TipoVeiculo tipo = SolicitarTipoVeiculo();
            Veiculo veiculo;

            veiculo = InicializarDadosVeiculo(tipo);

            AplicarChecklistVistoria(veiculo);

            return veiculo;
        }

        public void ExibirRelatorio(List<Veiculo> veiculos)
        {
            Console.WriteLine("");

            if (veiculos.Count == 0)
            {
                Funcoes.ExibirTextoComDefinicaoDeCor("Nenhuma vistoria realizada até o momento.", false, ConsoleColor.Red);
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Funcoes.ExibirCabecalho("RELATÓRIO DE VISTORIA(S)");

            int item = 1;
            foreach (Veiculo veiculo in veiculos) {
                Funcoes.ExibirLinhaDivisoriaSimples();
                Funcoes.ExibirTextoComDefinicaoDeCor($"[{item}/{veiculos.Count}] PROCESSANDO VISTORIA", false, ConsoleColor.DarkBlue);
                Funcoes.ExibirLinhaDivisoriaSimples();

                ImprimirRelatorio.ExibirDadosCadastro(veiculo);
                ImprimirRelatorio.ExibirDadosItensInspecionados(veiculo);
                ImprimirRelatorio.ExibirDadosResumoPontuacao(veiculo);
                ImprimirRelatorio.ExibirDadosManutencaoRecomendacao(veiculo);

                item++;
            }

            Funcoes.ExibirCabecalho("FIM DO PROCESSAMENTO DE VISTORIAS");
            Console.ResetColor();
        }
    }
}