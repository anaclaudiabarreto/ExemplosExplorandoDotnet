using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExemplosExplorando.Models
{
    public class Venda
    {
        public Venda()
        {
            
        }
        public Venda(int id, string produto, decimal preco, DateTime data, decimal? desconto)
        {
            Id = id;
            Produto = produto;
            Preco = preco;
            Data = data;
            Desconto = desconto;
        }

        public Venda(int id, string produto, decimal preco)
        {
            Id = id;
            Produto = produto;
            Preco = preco;            
        }
        public int Id { get; set; }

        [JsonProperty("nomeProduto")] //utilizamos quando não queremos manter o mesmo nome da prop que veio no json
        public string Produto { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        public decimal? Desconto { get; set; }
    }
}