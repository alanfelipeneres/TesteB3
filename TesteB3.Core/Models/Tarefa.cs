using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteB3.Core.Models
{
    [Table("Tarefa")]
    public class Tarefa
    {
        [Key]
        public int IdTarefa { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }

        [NotMapped]
        public String DataFormatada
        {
            get
            {
                return Data.ToString("dd/MM/yyyy");
            }
        }

        [NotMapped]
        public String StatusDescricao
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "Inativo";

                    case 1:
                        return "Ativo";

                    default:
                        return "Status não encontrado";
                }
            }
        }
    }
}
