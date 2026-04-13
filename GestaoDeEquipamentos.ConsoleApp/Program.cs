using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

internal class Program
{
    private static void Main(string[] args)
    {
        RepositorioChamado repositorioChamado = new RepositorioChamado();
        RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();


        TelaEquipamento telaEquipamento = new TelaEquipamento();
        TelaChamado telaChamado = new TelaChamado();

        telaChamado.repositorioChamado = repositorioChamado;
        telaEquipamento.repositorio = repositorioEquipamento;


        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Gerenciar Equipamentos");
            Console.WriteLine("2 - Gerenciar Chamados");
            Console.WriteLine("S - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

            if (opcaoMenuPrincipal == "S")
            {
                Console.Clear();
                break;
            }
            while (true)
            {
                if (opcaoMenuPrincipal == "1")
                {

                    string? opcaoMenu = telaEquipamento.ObterEscolhaMenuPrincipal();

                    if (opcaoMenu == "S")
                    {
                        Console.Clear();
                        break;
                    }

                    if (opcaoMenu == "1")
                        telaEquipamento.Cadastrar();

                    else if (opcaoMenu == "2")
                        telaEquipamento.Editar();

                    else if (opcaoMenu == "3")
                        telaEquipamento.Excluir();

                    else if (opcaoMenu == "4")
                        telaEquipamento.Visualizar();
                }
            }

            while (true)
            {
                if (opcaoMenuPrincipal == "2")
                {

                    string? opcaoMenu = telaChamado.ObterEscolhaMenuPrincipal();

                    if (opcaoMenu == "S")
                    {
                        Console.Clear();
                        break;
                    }

                    if (opcaoMenu == "1")
                        telaChamado.Cadastrar();

                    else if (opcaoMenu == "2")
                        telaChamado.Editar();

                    else if (opcaoMenu == "3")
                        telaChamado.Excluir();

                    else if (opcaoMenu == "4")
                        telaChamado.Visualizar();
                }
            }
        }
    }
}