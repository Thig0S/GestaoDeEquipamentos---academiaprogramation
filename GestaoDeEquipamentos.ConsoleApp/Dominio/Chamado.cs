using System;
using System.Data;

namespace GestaoDeEquipamentos.ConsoleApp.Dominio;

public class Chamado
{
    public string Id;
    public string? Titulo;
    public string Descricao;
    public DateTime DatadeAbertura;
    public Equipamento Equipamento;

    public int ObterDiasDecorridos()
    {
        TimeSpan diferencaTempo = DateTime.Now.Subtract(DatadeAbertura);
        return diferencaTempo.Days;
    }
}
