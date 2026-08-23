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

        public override void ExibirDadosCadastro()
        {
            base.ExibirDadosCadastro();
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Quantidade de eixos: {this.QuantidadeEixos}");
            Funcoes.ExibirTextoComIndentacaoUmNivel($"Capacidade: {this.CapacidadeCargaToneladas:F1} ton");
        }

        public override string RetornarRecomendacaoItemConformeStatus(string item, string status)
        {
            switch (item)
            {
                case "Tacógrafo":
                    return (status == "Ruim") ? "Realizar aferição/calibração do tacógrafo no Inmetro e reparar registrador" : "Substituir disco/fita do tacógrafo e alinhar o relógio interno do dispositivo";
                case "Sistema de Freios a Ar":
                    return (status == "Ruim") ? "Sanar vazamentos no circuito de ar e drenar água do reservatório (risco gravíssimo)" : "Drenar o reservatório de ar e checar espessura das lonas de freio";
                case "Trava e Lona da Caçamba":
                    return (status == "Ruim") ? "Substituir lona rasgada e consertar travas mecânicas da caçamba" : "Reajustar esticadores da lona e lubrificar ganchos de amarração";
                default:
                    return base.RetornarRecomendacaoItemConformeStatus(item, status);
            }
        }

    }
}