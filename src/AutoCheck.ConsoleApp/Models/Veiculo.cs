using AutoCheck.ConsoleApp.Helpers;

namespace AutoCheck.ConsoleApp.Models
{
    public abstract class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public List<ItemVistoria> VistoriaRealizada { get; set; }

        public Veiculo(string marca, string modelo, int ano, int quilometragem)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Quilometragem = quilometragem;       
            this.VistoriaRealizada = new List<ItemVistoria>();     
        }

        public void AdicionarItemVistoriado(string nome, string status)
        {
            ItemVistoria item = new ItemVistoria(nome);
            item.DefinirStatus(status);
            this.VistoriaRealizada.Add(item);
        }

        public virtual List<string> ObterChecklistObrigatorio()
        {
            return new List<string>() {"Nível de Óleo do Motor", "Bateria e Sistema Elétrico", "Documentação Regularizada"};
        }

        public virtual void ExibirDadosCadastro()
        {
            Console.WriteLine("DADOS DO VEÍCULO:");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Tipo: {this.GetType().Name}");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Marca: {this.Marca}");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Modelo: {this.Modelo}");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Ano: {this.Ano}");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Quilometragem: {this.Quilometragem}");
        }
        
        public void ExibirDadosItensInspecionados()
        {
            Console.WriteLine("");
            Console.WriteLine($"AVALIAÇÃO DOS ITENS INSPECIONADOS ({this.VistoriaRealizada.Count} ITENS):");
            Funcoes.ExibirTextoFormatadoEstiloSumario("Item", "Status", ' ');
            foreach (ItemVistoria item in this.VistoriaRealizada)
            {
                string textoItem = $"{Funcoes.RetornarEmojiConformeStatus(item.Status)} {item.Nome}";
                string textoStatus = $"{item.Status} ({item.RetornarPontosPeloStatus()} pts)";
                Funcoes.ExibirTextoFormatadoEstiloSumario(textoItem, textoStatus, '.');
            }
        }

        private string RetornarClassificacaoFinal(double percentual)
        {
            switch (percentual)
            {
                case >= 90:
                    return "APROVADO COM EXCELÊNCIA";
                case >= 60:
                    return "APROVADO COM APONTAMENTOS";
                default:
                    return "REPROVADO NA VISTORIA";
            }
        }

        private string RetornarAcaoCorporativa(double percentual)
        {
            switch (percentual)
            {
                case >= 90:
                    return "Liberado para compra/revenda imediata";
                case >= 60:
                    return "Exige desconto na compra para reparos da oficina";
                default:
                    return "Veículo recusado pela concessionária";
            }
        }
        
        public void ExibirDadosResumoPontuacao()
        {
            int pontuacaoMaximaPossivel = this.VistoriaRealizada.Count * 10;
            int pontuacaoObtida = 0;
            
            foreach (ItemVistoria item in this.VistoriaRealizada)
            {
                pontuacaoObtida += item.RetornarPontosPeloStatus();
            }

            double percentual = (double)pontuacaoObtida / pontuacaoMaximaPossivel * 100;

            string classificacao = RetornarClassificacaoFinal(percentual);  
            string acaoCorporativa = RetornarAcaoCorporativa(percentual);            

            Console.WriteLine("");
            Console.WriteLine("RESUMO DA PONTUAÇÃO:");
            Funcoes.ExibirTextoFormatadoEstiloSumario("Pontuação Atingida", $"{pontuacaoObtida} de {pontuacaoMaximaPossivel} pontos possíveis", '.');
            Funcoes.ExibirTextoFormatadoEstiloSumario("Percentual de Aprovação:", $"{percentual:F1}%", '.');
            Funcoes.ExibirTextoFormatadoEstiloSumario("Classificação Final:", classificacao, '.');
            Funcoes.ExibirTextoFormatadoEstiloSumario("Ação Corporativa:", acaoCorporativa, '.');
        }

        private bool VerificarExisteItemVistoriaPeloStatus(string status)
        {
            foreach (ItemVistoria item in this.VistoriaRealizada)
            {
                if (item.Status == status)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual string RetornarRecomendacaoItemConformeStatus(string item, string status)
        {
            switch (item)
            {
                case "Nível de Óleo do Motor":
                    return (status == "Ruim") ? "Completar óleo imediatamente e checar possíveis vazamentos no cárter" : "Agendar troca preventiva de óleo e filtro nos próximos 1.000 km";
                case "Bateria e Sistema Elétrico":
                    return (status == "Ruim") ? "Substituir bateria com falha de carga e testar o alternador" : "Limpar terminais (descarbonização) e monitorar a tensão na partida";
                case "Documentação Regularizada":
                    return (status == "Ruim") ? "Regularizar IPVA e licenciamento vencido antes de circular" : "Verificar prazo de vencimento da taxa de licenciamento para o próximo mês";
                default:
                    return string.Empty;
            }
        }

        public void ExibirDadosManutencaoRecomendacao()
        {
            bool contemItemStatusRuim = VerificarExisteItemVistoriaPeloStatus("Ruim");
            bool contemItemStatusRegular = VerificarExisteItemVistoriaPeloStatus("Regular");

            Console.WriteLine("");
            Console.WriteLine("RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:");
            Console.WriteLine("");

            if (!contemItemStatusRegular & !contemItemStatusRuim)
            {
                Console.WriteLine("🟢 Nenhuma pendência mecânica identificada. Veículo liberado para operação!");  
                Console.WriteLine("");
                return;
            }          

            if (contemItemStatusRuim){
                Console.WriteLine("🔴 ITENS CRÍTICOS / REPROVADOS (AÇÃO IMEDIATA):");  

                foreach (ItemVistoria item in this.VistoriaRealizada)
                {
                    if (item.Status == "Ruim")
                    {
                        string recomendacao = RetornarRecomendacaoItemConformeStatus(item.Nome, "Ruim");
                        Console.WriteLine($"{item.Nome}:");
                        Funcoes.ExibirTextoComIndentacaoUmNivel($"{recomendacao}.");
                    }
                }

                Console.WriteLine("");
            }     

            if (contemItemStatusRegular){
                Console.WriteLine("🟡 ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):");  

                foreach (ItemVistoria item in this.VistoriaRealizada)
                {
                    if (item.Status == "Regular")
                    {
                        string recomendacao = RetornarRecomendacaoItemConformeStatus(item.Nome, "Regular");
                        Console.WriteLine($"{item.Nome}:");
                        Funcoes.ExibirTextoComIndentacaoUmNivel($"{recomendacao}.");
                    }
                }

                Console.WriteLine("");
            }
        }
    }
}
