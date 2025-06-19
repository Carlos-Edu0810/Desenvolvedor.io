using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEFCore.Domain
{
    [Table("Clientes")] //define qual vai ser o nome da tabela dentro do banco de dados
    public class Cliente
    {
        [Key] //define que essa propriedade será a "primary key"
        public int Id { get; set; }
        [Required] //define que essa propriedade não poderá ser nula.
        public string Nome { get; set; }
        [Column("Phone")] //define qual vai ser o nome da coluna dentro do banco de dados (quando não informado assume o nome da propriedade.)
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
    }
}