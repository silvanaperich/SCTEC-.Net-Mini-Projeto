using AutoCheck.ConsoleApp.Helpers;
using AutoCheck.ConsoleApp.Models;

namespace AutoCheck.ConsoleApp.UI
{
    public class ImprimirRelatorio
    {
        public static void ImprimirRelatorioVeiculo(Veiculo veiculo)
        {
            ExibirDadosCadastro(veiculo);
            ExibirDadosItensInspecionados(veiculo);
            ExibirDadosResumoPontuacao(veiculo);
            ExibirDadosManutencaoRecomendacao(veiculo);
        }
        
        public static void ExibirDadosCadastro(Veiculo veiculo)
        {
            Console.WriteLine("DADOS DO VEÍCULO:");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Tipo: {veiculo.GetType().Name}");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Marca: {veiculo.Marca}");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Modelo: {veiculo.Modelo}");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Ano: {veiculo.Ano}");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Quilometragem: {veiculo.Quilometragem}");

            switch (veiculo)
            {
                case Carro carro:
                    Funcoes.ExibirTextoComIndentacaoUmNivel($"Portas: {carro.QuantidadePortas}");
                    break;
                case Moto moto:
                    Funcoes.ExibirTextoComIndentacaoUmNivel($"Motor: {moto.Cilindradas} cc");
                    break;
                case Caminhao caminhao:
                    Funcoes.ExibirTextoComIndentacaoUmNivel($"Quantidade de eixos: {caminhao.QuantidadeEixos}");
                    Funcoes.ExibirTextoComIndentacaoUmNivel($"Capacidade: {caminhao.CapacidadeCargaToneladas:F1} ton");
                    break;
            }
        }

        public static void ExibirDadosItensInspecionados(Veiculo veiculo)
        {
            Console.WriteLine("");
            Console.WriteLine($"AVALIAÇÃO DOS ITENS INSPECIONADOS ({veiculo.VistoriaRealizada.Count} ITENS):");
            Funcoes.ExibirTextoFormatadoEstiloSumario("Item", "Status", ' ');
            foreach (ItemVistoria item in veiculo.VistoriaRealizada)
            {
                string textoItem = $"{Funcoes.RetornarEmojiConformeStatus(item.Status)} {item.Nome}";
                string textoStatus = $"{item.Status} ({item.RetornarPontosPeloStatus()} pts)";
                Funcoes.ExibirTextoFormatadoEstiloSumario(textoItem, textoStatus, '.');
            }
        }

        public static void ExibirDadosResumoPontuacao(Veiculo veiculo)
        {
            int pontuacaoMaximaPossivel = veiculo.VistoriaRealizada.Count * 10;
            int pontuacaoObtida = 0;

            foreach (ItemVistoria item in veiculo.VistoriaRealizada)
            {
                pontuacaoObtida += item.RetornarPontosPeloStatus();
            }

            double percentual = (double)pontuacaoObtida / pontuacaoMaximaPossivel * 100;

            string classificacao = veiculo.RetornarClassificacaoFinal();
            string acaoCorporativa = veiculo.RetornarAcaoCorporativa();

            Console.WriteLine("");
            Console.WriteLine("RESUMO DA PONTUAÇÃO:");
            Funcoes.ExibirTextoFormatadoEstiloSumario("Pontuação Atingida", $"{pontuacaoObtida} de {pontuacaoMaximaPossivel} pontos possíveis", '.');
            Funcoes.ExibirTextoFormatadoEstiloSumario("Percentual de Aprovação:", $"{percentual:F1}%", '.');
            Funcoes.ExibirTextoFormatadoEstiloSumario("Classificação Final:", classificacao, '.');
            Funcoes.ExibirTextoFormatadoEstiloSumario("Ação Corporativa:", acaoCorporativa, '.');
        }

        private static bool VerificarExisteItemVistoriaPeloStatus(Veiculo veiculo, string status)
        {
            foreach (ItemVistoria item in veiculo.VistoriaRealizada)
            {
                if (item.Status == status)
                {
                    return true;
                }
            }
            return false;
        }

        public static void ExibirDadosManutencaoRecomendacao(Veiculo veiculo)
        {
            bool contemItemStatusRuim = VerificarExisteItemVistoriaPeloStatus(veiculo, "Ruim");
            bool contemItemStatusRegular = VerificarExisteItemVistoriaPeloStatus(veiculo, "Regular");

            Console.WriteLine("");
            Console.WriteLine("RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:");
            Console.WriteLine("");

            if (!contemItemStatusRegular & !contemItemStatusRuim)
            {
                Funcoes.ExibirTextoComDefinicaoDeCor("🟢 Nenhuma pendência mecânica identificada. Veículo liberado para operação!", false, ConsoleColor.Green);
                Console.WriteLine("");
                return;
            }

            if (contemItemStatusRuim){
                Funcoes.ExibirTextoComDefinicaoDeCor("🔴 ITENS CRÍTICOS / REPROVADOS (AÇÃO IMEDIATA):", false, ConsoleColor.Red);

                foreach (ItemVistoria item in veiculo.VistoriaRealizada)
                {
                    if (item.Status == "Ruim")
                    {
                        string recomendacao = veiculo.RetornarRecomendacaoItemConformeStatus(item.Nome, "Ruim");
                        Console.WriteLine($"{item.Nome}:");
                        Funcoes.ExibirTextoComIndentacaoUmNivel($"{recomendacao}.");
                    }
                }

                Console.WriteLine("");
            }

            if (contemItemStatusRegular){
                Funcoes.ExibirTextoComDefinicaoDeCor("🟡 ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):", false, ConsoleColor.Yellow);

                foreach (ItemVistoria item in veiculo.VistoriaRealizada)
                {
                    if (item.Status == "Regular")
                    {
                        string recomendacao = veiculo.RetornarRecomendacaoItemConformeStatus(item.Nome, "Regular");
                        Console.WriteLine($"{item.Nome}:");
                        Funcoes.ExibirTextoComIndentacaoUmNivel($"{recomendacao}.");
                    }
                }

                Console.WriteLine("");
            }
        }
    }
}