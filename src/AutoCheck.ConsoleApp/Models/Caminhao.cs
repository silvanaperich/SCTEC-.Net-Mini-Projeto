using AutoCheck.ConsoleApp.Helpers;

namespace AutoCheck.ConsoleApp.Models
{
    public class Caminhao : Veiculo
    {
        public int QuantidadeEixos { get; set; }
        public double CapacidadeCargaToneladas { get; set; }
        
        public Caminhao(string marca, string modelo, int ano, int quilometragem, int quantidadeEixos, double capacidadeCargaToneladas) : base(marca, modelo, ano, quilometragem)
        {
            this.QuantidadeEixos = quantidadeEixos;
            this.CapacidadeCargaToneladas = capacidadeCargaToneladas;
        }

        public override List<string> ObterChecklistObrigatorio()
        {
            List<string> checklist = base.ObterChecklistObrigatorio();
            checklist.Add("Tacógrafo");
            checklist.Add("Sistema de Freios a Ar");
            checklist.Add("Trava e Lona da Caçamba");
            return checklist;
        }

        protected override void ExibirTipoVeiculo()
        {
            Funcoes.ExibirTextoComIndentacaoUmNivel("Tipo: Caminhão");
        }

        public override void ExibirDadosCadastro()
        {
            base.ExibirDadosCadastro();
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Quantidade de eixos: {this.QuantidadeEixos}");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Capacidade: {this.CapacidadeCargaToneladas:D1} ton");
        }
        
    }
}