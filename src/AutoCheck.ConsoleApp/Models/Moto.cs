using AutoCheck.ConsoleApp.Helpers;

namespace AutoCheck.ConsoleApp.Models
{
    public class Moto : Veiculo
    {
        public int Cilindradas { get; set; }

        public Moto(string marca, string modelo, int ano, int quilometragem, int cilindradas) : base(marca, modelo, ano, quilometragem)
        {
            this.Cilindradas = cilindradas;
        }

        public override List<string> ObterChecklistObrigatorio()
        {
            List<string> checklist = base.ObterChecklistObrigatorio();
            checklist.Add("Kit Transmissão/Corrente");
            checklist.Add("Manetes de Freio/Embreagem");
            checklist.Add("Pezinho Lateral");
            return checklist;
        }

        public override void ExibirDadosCadastro()
        {
            base.ExibirDadosCadastro();
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Motor: {this.Cilindradas} cc");
        }
        
    }
}