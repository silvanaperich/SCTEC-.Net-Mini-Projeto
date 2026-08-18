namespace AutoCheck.ConsoleApp.Models
{
    public class ItemVistoria
    {
        private string[] statusValidos = new string[3] { "Bom", "Regular", "Ruim" };
        public string Nome { get; set; }   
        public string Status { get; protected set; }

        public void DefinirStatus(string status)
        {
            if (!ValidarStatus(status))
            {
                throw new ArgumentException("Status Inválido! Valores aceitos: Bom, Regular ou Ruim.");
            }
            this.Status = status;
        }

        private bool ValidarStatus(string status)
        {
            return statusValidos.Contains(status, StringComparer.OrdinalIgnoreCase);
        }
    }
}