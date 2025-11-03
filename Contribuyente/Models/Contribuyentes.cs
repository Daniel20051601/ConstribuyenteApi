using System.ComponentModel.DataAnnotations;

namespace ConstribuyenteApi.Contribuyente.Models;

public class Contribuyentes
{
    [Key]
    public int id { get; set; }
    [Required]
    public string cedula { get; set; }
    [Required]
    public string nombre { get; set; }
    [Required]
    public string telefono { get; set; }
    public string direccion { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string fechaRegistro { get; set; } = string.Empty;
}
