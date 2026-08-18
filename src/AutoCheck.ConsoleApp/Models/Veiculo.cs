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
            ItemVistoria item = new ItemVistoria() { Nome = nome };
            item.DefinirStatus(status);
            this.VistoriaRealizada.Add(item);
        }

        public virtual List<string> ObterChecklistObrigatorio()
        {
            return new List<string>() {"Nível de Óleo do Motor", "Bateria e Sistema Elétrico", "Documentação Regularizada"};
        }
    }
}
