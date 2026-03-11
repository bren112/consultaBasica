using Postgrest.Attributes;
using Postgrest.Models;
using System;

namespace umaConsulta
{
    [Table("atletas")]
    public class Atletas : BaseModel
    {
        [PrimaryKey("id", false)]
        public string Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("modalidade")]
        public string Modalidade { get; set; }

        [Column("celular")]
        public string Celular { get; set; }

        [Column("data_nascimento")]
        public DateTime? DataNascimento { get; set; }
    }
}