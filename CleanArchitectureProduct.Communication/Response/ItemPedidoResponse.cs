﻿namespace CleanArchitectureProduct.Communication.Response
{
    public partial class PedidoResponse
    {
        public class ItemPedidoResponse
        {
            public int Id { get; set; }
            public int IdProduto { get; set; }
            public string? NomeProduto { get; set; }
            public decimal? ValorUnitario { get; set; }
            public int Quantidade { get; set; }
        }
    }
}
}