using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioEquipamento
{
    public Equipamento[] equipamentos = new Equipamento[100];

    public void Cadastrar(Equipamento novoEquipamento)
    {
        novoEquipamento.Id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
            {
                equipamentos[i] = novoEquipamento;
                break;
            }
        }
    }

    public Equipamento SelecionarPorId(string idSelecionado)
    {
        Equipamento? equipamentoSelecionado = null;

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

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
    public bool Editar(string idSelecionado, Equipamento novoEquipamento)
    {
        Equipamento? equipamentoSelecionado = SelecionarPorId(idSelecionado);

        if (equipamentoSelecionado == null)
            return false;

        equipamentoSelecionado.Nome = novoEquipamento.Nome;
        equipamentoSelecionado.Fabricante = novoEquipamento.Fabricante;
        equipamentoSelecionado.PrecoAquisicao = novoEquipamento.PrecoAquisicao;
        equipamentoSelecionado.DataFabricacao = novoEquipamento.DataFabricacao;

        return true;
    }
    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            if (e.Id == idSelecionado)
            {
                equipamentos[i] = null;
                return true;
            }
        }
        return false;
    }
    public Equipamento[]? SelecionarTodos()
    {
        return equipamentos;
    }
}
