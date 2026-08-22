using AutoCheck.ConsoleApp.Helpers;

namespace AutoCheck.ConsoleApp.Models
{
    public class Carro : Veiculo
    {
        public int QuantidadePortas { get; set; }

        public Carro(string marca, string modelo, int ano, int quilometragem, int quantidadePortas) : base(marca, modelo, ano, quilometragem)
        {
            this.QuantidadePortas = quantidadePortas;
        }

        public override List<string> ObterChecklistObrigatorio()
        {
            List<string> checklist = base.ObterChecklistObrigatorio();
            checklist.Add("Estepe e Macaco");
            checklist.Add("Triângulo de Sinalização");
            checklist.Add("Ar Condicionado Funcional");
            return checklist;
        }

        public override void ExibirDadosCadastro()
        {
            base.ExibirDadosCadastro();
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Portas: {this.QuantidadePortas}");
        }
    }
}