namespace AutoCheck.ConsoleApp.Models
{
    public class ItemVistoria
    {
        private string[] statusValidos = new string[3] { "Bom", "Regular", "Ruim" };
        public string Nome { get; set; }   
        public string Status { get; protected set; }

        public ItemVistoria(string nome)
        {
            this.Nome = nome;
        }

        public void DefinirStatus(string status)
        {
            if (!ValidarStatus(status))
            {
                throw new ArgumentException("Status Inválido! Valores aceitos: Bom, Regular ou Ruim.");
            }

            switch (status.ToLower())
            {
                case "bom":
                    this.Status = statusValidos[0];
                    break;
                case "regular":
                    this.Status = statusValidos[1];
                    break;
                default:
                    this.Status = statusValidos[2];
                    break;
            }            
        }

        private bool ValidarStatus(string status)
        {
            return statusValidos.Contains(status, StringComparer.OrdinalIgnoreCase);
        }

        public int RetornarPontosPeloStatus()
        {
            switch (this.Status.ToLower())
            {
                case "bom":
                    return 10;
                case "regular":
                    return 5;
                default:
                    return 0;
            }
        }
    }
}