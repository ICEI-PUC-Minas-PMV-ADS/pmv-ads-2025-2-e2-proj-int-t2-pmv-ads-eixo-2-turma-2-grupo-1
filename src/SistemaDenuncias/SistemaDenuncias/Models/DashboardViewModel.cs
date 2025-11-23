namespace SistemaDenuncias.Models
{
    public class DashboardViewModel
    {
        public int DenunciasAbertas { get; set; }
        public int DenunciasEmAnalise { get; set; }
        public int DenunciasFechadas { get; set; }
        public int UsuariosEmPerigo { get; set; } // Para o contador em tempo real
        public string NomeAdmin { get; set; }
    }
}