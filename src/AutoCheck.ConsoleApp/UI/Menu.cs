using AutoCheck.ConsoleApp.Helpers;

namespace AutoCheck.ConsoleApp.UI
{
    public class Menu
    {
        public void Executar()
        {
            string opcaoEscolhida;


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
                        //RealizarNovaVistoria();
                        Console.WriteLine("RealizarNovaVistoria");
                        break;
                    case "2":
                        //ExibirRelatorio();
                        Console.WriteLine("ExibirRelatorio");
                        break;
                    case "0":
                        Funcoes.ExibirCabecalho("AUTOCHECK .NET - SISTEMA ENCERRADO...");
                        break;        
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
                Console.WriteLine();
            } while (opcaoEscolhida != "0");
        }
    }
}