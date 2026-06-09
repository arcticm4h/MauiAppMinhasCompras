using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto //No produto não aprofundei muito, só estabeleci os métodos como na aula exemplo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public double Quantidade { get; set; }
        public double Preco { get; set; }

        [Ignore]
        public double Total => Quantidade * Preco;
    }
}
