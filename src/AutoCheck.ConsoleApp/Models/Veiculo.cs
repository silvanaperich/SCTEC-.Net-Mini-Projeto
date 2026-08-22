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
        
        public virtual void ExibirDadosItensInspecionados()
        {
            Console.WriteLine($"AVALIAÇÃO DOS ITENS INSPECIONADOS ({this.VistoriaRealizada.Count} ITENS):");
            Funcoes.ExibirTextoFormatadoEstiloSumario("Item", "Status", ' ');
            foreach (ItemVistoria item in this.VistoriaRealizada)
            {
                Funcoes.ExibirTextoFormatadoEstiloSumario(item.Nome, $"{item.Status} ({item.RetornarPontosPeloStatus()} pts)", '.');
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
        
        public virtual void ExibirDadosResumoPontuacao()
        {
            int pontuacaoMaximaPossivel = this.VistoriaRealizada.Count * 10;
            int pontuacaoObtida = 0;
            
            foreach (ItemVistoria item in this.VistoriaRealizada)
            {
                pontuacaoObtida += item.RetornarPontosPeloStatus();
            }

            double percentual = (double)pontuacaoObtida / pontuacaoMaximaPossivel * 100;

            string classificacao = RetornarClassificacaoFinal(percentual);            

            Console.WriteLine("RESUMO DA PONTUAÇÃO:");
            Funcoes.ExibirTextoFormatadoEstiloSumario("Pontuação Atingida", $"{pontuacaoObtida} de {pontuacaoMaximaPossivel} pontos possíveis", '.');
            Funcoes.ExibirTextoFormatadoEstiloSumario("Percentual de Aprovação:", $"{percentual:F1}%", '.');
            Funcoes.ExibirTextoFormatadoEstiloSumario("Classificação Final:", classificacao, '.');
        }
    }
}
