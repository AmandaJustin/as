using System;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Data { get; set; }

    public decimal ValorTotal { get; set; }

    public required string Status { get; set; }

    public required string Descricao { get; set; }
}