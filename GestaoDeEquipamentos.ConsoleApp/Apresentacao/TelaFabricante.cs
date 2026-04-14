using System;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante;
    public string? ObterEscolhaMenuPrincipal()
    {
        //Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricante");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar Fabricante");
        Console.WriteLine("2 - Editar Fabricante");
        Console.WriteLine("3 - Excluir Fabricante");
        Console.WriteLine("4 - Visualizar Fabricante");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }
    public void Cadastrar()
    {


        Fabricante novoFabricante = new Fabricante();
        do
        {
            System.Console.WriteLine("Digite o nome do FABRICANTE: ");
            novoFabricante.Nome = Console.ReadLine();

            if (!String.IsNullOrEmpty(novoFabricante.Nome) && novoFabricante.Nome.Length >= 3)
            {
                break;
            }
        } while (true);

        do
        {
            System.Console.WriteLine("Digite o email do FABRICANTE: ");
            novoFabricante.Email = Console.ReadLine();

            if (!String.IsNullOrEmpty(novoFabricante.Email) && novoFabricante.Email.Length >= 3)
            {
                break;
            }
        } while (true);

        System.Console.WriteLine("Digite o telefone do FABRICANTE: ");
        novoFabricante.Telefone = Console.ReadLine();

        repositorioFabricante.Cadastrar(novoFabricante);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novoFabricante.Id}\" foi cadastrado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void VisualizarListaDeFabricantes(bool deveExibirCabecalho)
    {
        Fabricante[] ListadeFabricantes = VisualizarTodos();

        if (deveExibirCabecalho)
            MostrarCabecalho("Visualizar Fabricantes");

        Console.WriteLine(
           "{0, -7} | {1, -15} | {2, -15} | {3, -22}    ",
           "Id", "Nome", "Email", "Telefone"
       );

        for (int i = 0; i < ListadeFabricantes.Length; i++)
        {
            Fabricante? e = ListadeFabricantes[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -22}",
                e.Id, e.Nome, e.Email, e.Telefone
            );
        }
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }
    public Fabricante?[] VisualizarTodos() //pega o repositorio da classe repositorioFabricantes
    {
        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();
        return fabricantes;
    }
    public void MostrarCabecalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricnates");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
    }
}
