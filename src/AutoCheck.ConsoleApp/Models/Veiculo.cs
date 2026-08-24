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

        public int CalcularPontuacaoObtida()
        {
            int pontuacaoObtida = 0;

            foreach (ItemVistoria item in this.VistoriaRealizada)
            {
                pontuacaoObtida += item.RetornarPontosPeloStatus();
            }

            return pontuacaoObtida;
        }

        public string RetornarClassificacaoFinal()
        {
            double percentual = CalcularPercentualAprovacao();
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

        public double CalcularPercentualAprovacao()
        {
            int pontuacaoMaxima = VistoriaRealizada.Count * 10;
            if (pontuacaoMaxima == 0)
            {
                return 0;
            }
            return ((double)CalcularPontuacaoObtida() / pontuacaoMaxima) * 100;
        }

        public string RetornarAcaoCorporativa()
        {
            double percentual = CalcularPercentualAprovacao();
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

    }
}
