using System;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaChamado
{
    public RepositorioEquipamento repostitorioEquipamento;
    public RepositorioChamado repositorioChamado;
    public string? ObterEscolhaMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar Chamados");
        Console.WriteLine("2 - Editar Chamados");
        Console.WriteLine("3 - Excluir Chamados");
        Console.WriteLine("4 - Visualizar Chamados");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        System.Console.WriteLine("-------------------------------");
        System.Console.WriteLine("Gestão de Chamados!");
        System.Console.WriteLine("-------------------------------");
        System.Console.WriteLine("Cadastrar Chamados: ");

        System.Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}"
            , "ID", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação");


        Equipamento?[] equipamentos = repostitorioEquipamento.SelecionarTodos();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            System.Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}"
                , e.Id, e.Nome, e.Fabricante, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString()
            );
        }

        System.Console.WriteLine("-------------------------");
        string? idSelecionado;
        do
        {
            System.Console.Write("Digite o ID do equipamento que deseja selecionar: ");
            idSelecionado = Console.ReadLine();

            if (!String.IsNullOrEmpty(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Equipamento? equipamentoSelecionado = repostitorioEquipamento.SelecionarPorId(idSelecionado);

        if (equipamentoSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O equipamento com o ID NÃO foi encontrado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            return;
        }


        Chamado novoChamado = new Chamado();

        do
        {
            System.Console.Write("\nDigite o TITULO do Chamado: ");
            novoChamado.Titulo = Console.ReadLine();

            if (!String.IsNullOrEmpty(novoChamado.Titulo) && novoChamado.Titulo.Length > 3)
            {
                break;
            }
            System.Console.WriteLine("Titulo deve conter no mínimo 3 caracteres!");
            Console.ReadLine();

        } while (true);

        Chamado novoChamdo = new Chamado();

        novoChamado.Equipamento = equipamentoSelecionado;

        System.Console.Write("\nDigite o DESCRIÇÃO do Chamado: ");
        novoChamado.Descricao = Console.ReadLine();

        novoChamado.DatadeAbertura = DateTime.Now;

        repositorioChamado.Cadastrar(novoChamado);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O equipamento \"{novoChamado.Id}\" foi CADASTRADO com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();

    }


    public void Editar()
    {

    }

    public void Excluir()
    {

    }

    public void Visualizar()
    {
        System.Console.WriteLine("-------------------------------");
        System.Console.WriteLine("Gestão de Chamados!");
        System.Console.WriteLine("-------------------------------");
        System.Console.WriteLine("Visualizar os Chamados: ");

        System.Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -22} | {4, -10}"
            , "ID", "Titulo", "Equipamento", "Data de Abertura", "Dias desde a Abertura");


        Chamado?[] chamados = repositorioChamado.SelecionarTodos();

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? e = chamados[i];

            if (e == null)
                continue;

            System.Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -22} | {4, -10}"
                , e.Id, e.Titulo, e.Equipamento.Nome, e.DatadeAbertura.ToShortDateString(), e.ObterDiasDecorridos()
            );
        }
        System.Console.WriteLine("-----------------------");
        System.Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }
}
