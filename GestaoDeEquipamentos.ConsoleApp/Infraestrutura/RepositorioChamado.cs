using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioChamado
{
    public Chamado[] chamados = new Chamado[100];

    public void Cadastrar(Chamado novoEquipamento)
    {
        novoEquipamento.Id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? e = chamados[i];

            if (e == null)
            {
                chamados[i] = novoEquipamento;
                break;
            }
        }
    }

    public bool Editar(string idSelecionado, Chamado novoChamado)
    {
        Chamado? chamdoSelecionado = SelecionarPorId(idSelecionado);

        if (chamdoSelecionado == null)
            return false;

        chamdoSelecionado.Titulo = novoChamado.Titulo;
        chamdoSelecionado.Descricao = novoChamado.Descricao;
        chamdoSelecionado.DatadeAbertura = novoChamado.DatadeAbertura;
        chamdoSelecionado.Equipamento = novoChamado.Equipamento;

        return true;
    }
    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? e = chamados[i];

            if (e == null)
                continue;

            if (e.Id == idSelecionado)
            {
                chamados[i] = null;
                return true;
            }
        }
        return false;
    }
    public Chamado?[] SelecionarTodos()
    {
        return chamados;
    }

    public Chamado SelecionarPorId(string idSelecionado)
    {
        Chamado? chamadoSelecionado = null;

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado e = chamados[i];

            if (e == null)
                continue;

            if (e.Id == idSelecionado)
            {
                chamadoSelecionado = e;
                break;
            }
        }
        return chamadoSelecionado;
    }


}
