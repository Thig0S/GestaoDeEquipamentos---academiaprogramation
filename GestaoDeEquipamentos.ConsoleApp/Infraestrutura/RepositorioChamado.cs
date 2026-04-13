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

    public Chamado?[] SelecionarTodos()
    {
        return chamados;
    }
}
