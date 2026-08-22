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

        public override string RetornarRecomendacaoItemConformeStatus(string item, string status)
        {
            switch (item)
            {
                case "Estepe e Macaco":
                    return (status == "Ruim") ? "Substituir estepe danificado/careca e adquirir macaco mecânico funcional" : "Calibrar pneu reserva e verificar funcionamento do macaco";
                case "Triângulo de Sinalização":
                    return (status == "Ruim") ? "Repor equipamento obrigatório ausente/danificado" : "Ajustar suporte de fixação do triângulo dentro do porta-malas";
                case "Ar Condicionado Funcional":
                    return (status == "Ruim") ? "Efetuar reparo no compressor e recarga do gás refrigerante" : "Realizar higienização dos dutos de ar e trocar o filtro de cabine";
                default:
                    return base.RetornarRecomendacaoItemConformeStatus(item, status);
            }
        }
    }
}