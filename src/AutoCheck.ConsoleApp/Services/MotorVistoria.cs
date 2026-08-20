using AutoCheck.ConsoleApp.Helpers;
using AutoCheck.ConsoleApp.Models;

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
            
            while (!Enum.TryParse(opcaoEscolhida, out tipoVeiculo))
            {
                Console.Write("Opção inválida! Informe novamente o tipo de veículo desejado: ");
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

        public Veiculo RealizarNovaVistoria()
        {
            TipoVeiculo tipo = SolicitarTipoVeiculo();
            Veiculo veiculo;

            veiculo = InicializarDadosVeiculo(tipo);

            return veiculo;
        }

        public void ExibirRelatorio(List<Veiculo> veiculos)
        {
            Console.WriteLine("implementacao pendente...");
        }
    }
}