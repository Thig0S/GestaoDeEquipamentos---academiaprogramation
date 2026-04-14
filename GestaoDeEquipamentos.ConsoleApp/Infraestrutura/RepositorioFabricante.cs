using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioFabricante
{
    public Fabricante?[] Fabricantes = new Fabricante[100];

    internal void Cadastrar(Fabricante novoFabricante)
    {
        novoFabricante.Id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7); // 0-255

        for (int i = 0; i < Fabricantes.Length; i++)
        {
            Fabricante? f = Fabricantes[i];

            if (f == null)
            {
                Fabricantes[i] = novoFabricante;
                break;
            }
        }
    }
    public bool Exlcuir(string idParaSerExluicdo)
    {
        for (int i = 0; i < Fabricantes.Length; i++)
        {
            Fabricante? f = new Fabricante();

            f = Fabricantes[i];

            if (f == null)
                continue;

            if (f.Id == idParaSerExluicdo)
            {
                Fabricantes[i] = null;
                return true;
            }
        }
        return false;
    }

    public Fabricante?[] SelecionarTodos()
    {
        return Fabricantes;
    }

    public Fabricante? SelecionarPorId(string idSelecionado)
    {
        Fabricante? equipamentoSelecionado = null;

        for (int i = 0; i < Fabricantes.Length; i++)
        {
            Fabricante? e = Fabricantes[i];

            if (e == null)
                continue;

            if (e.Id == idSelecionado)
            {
                equipamentoSelecionado = e;
                break;
            }
        }

        return equipamentoSelecionado;
    }

    public bool Editar(Fabricante editarFabricante, string idSelecionado)
    {
        Fabricante? fabricanteSelecionado = SelecionarPorId(idSelecionado);

        if (fabricanteSelecionado == null)
            return false;

        fabricanteSelecionado.Nome = editarFabricante.Nome;
        fabricanteSelecionado.Telefone = editarFabricante.Telefone;
        fabricanteSelecionado.Email = editarFabricante.Email;

        return true;
    }
}
