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

        public override string RetornarRecomendacaoItemConformeStatus(string item, string status)
        {
            switch (item)
            {
                case "Kit Transmissão/Corrente":
                    return (status == "Ruim") ? "Trocar imediatamente o kit transmissão (corrente folgada, coroa e pinhão gastos)" : "Ajustar a tensão da corrente, realizar limpeza e aplicar lubrificante próprio";
                case "Manetes de Freio/Embreagem":
                    return (status == "Ruim") ? "Trocar manetes quebrados/empenados e regular folga do cabo/sistema hidráulico" : "Ajustar a folga dos cabos e lubrificar as articulações dos manetes";
                case "Pezinho Lateral":
                    return (status == "Ruim") ? "Substituir mola de retorno quebrada ou pezinho empenado (risco de queda)" : "Reapertar parafusos de fixação e aplicar desingripante na articulação";
                default:
                    return base.RetornarRecomendacaoItemConformeStatus(item, status);
            }
        }

    }
}