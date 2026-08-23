using AutoCheck.ConsoleApp.Helpers;
using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.Services;

namespace AutoCheck.ConsoleApp.UI
{
    public class Menu
    {
        public void Executar()
        {
            string opcaoEscolhida;
            List<Veiculo> listaVeiculos = new List<Veiculo>();
            MotorVistoria motor = new MotorVistoria();

            Funcoes.ExibirCabecalho("AUTOCHECK .NET - MOTOR DE VISTORIA VEICULAR");

            do
            {
                Funcoes.ExibirCabecalhoLinhaSimples("Menu");
                Console.WriteLine("1 - Realizar Nova Vistoria");
                Console.WriteLine("2 - Exibir Relatório das Vistorias");
                Console.WriteLine("0 - Sair");
                Console.Write("Digite a opção desejada: ");

                opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida)
                {
                    case "1":
                        Veiculo veiculoAdicionado = motor.RealizarNovaVistoria();
                        listaVeiculos.Add(veiculoAdicionado);
                        break;
                    case "2":
                        motor.ExibirRelatorio(listaVeiculos);
                        break;
                    case "0":
                        Funcoes.ExibirCabecalho("AUTOCHECK .NET - SISTEMA ENCERRADO...");
                        break;
                    default:
                        Funcoes.ExibirTextoComDefinicaoDeCor("Opção inválida! Tente novamente.", false, ConsoleColor.Red);
                        break;
                }
                Console.WriteLine();
            } while (opcaoEscolhida != "0");
        }
    }
}