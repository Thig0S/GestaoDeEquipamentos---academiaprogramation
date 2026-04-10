using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Equipamento[] equipamentos = new Equipamento[100];

        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar equipamento");
            Console.WriteLine("2 - Editar equipamento");
            Console.WriteLine("3 - Excluir equipamento");
            Console.WriteLine("4 - Visualizar equipamentos");
            Console.WriteLine("S - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            string? opcaoMenu = Console.ReadLine()?.ToUpper();

            if (opcaoMenu == "S")
            {

                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
            {
                System.Console.WriteLine("-------------------------------");
                System.Console.WriteLine("Gestão de Equipamentos!");
                System.Console.WriteLine("-------------------------------");
                System.Console.WriteLine("Cadastrar Equipamento: ");

                Equipamento novoEquipamento = new Equipamento();

                do
                {
                    System.Console.Write("\nDigite o NOME do equipamento: ");
                    novoEquipamento.Nome = Console.ReadLine();

                    if (!String.IsNullOrEmpty(novoEquipamento.Nome) && novoEquipamento.Nome.Length > 3)
                    {
                        break;
                    }
                    System.Console.WriteLine("Nome deve conter no mínimo 3 caracteres!");
                    Console.ReadLine();

                } while (true);

                do
                {
                    System.Console.Write("\nDigite o FABRICANTE do equipamento: ");
                    novoEquipamento.Fabricante = Console.ReadLine();

                    if (!String.IsNullOrEmpty(novoEquipamento.Fabricante) && novoEquipamento.Fabricante.Length > 3)
                    {
                        break;
                    }
                    System.Console.WriteLine("Fabricante deve conter no mínimo 3 caracteres!");
                    Console.ReadLine();

                } while (true);

                System.Console.Write("\nDigite o PREÇO do equipamento: ");
                novoEquipamento.PrecoAquisicao = Convert.ToDecimal(Console.ReadLine());

                System.Console.Write("\nDigite a DATA CADASTRADA do equipamento DD/MM/YYYY: ");
                DateTime dataEquipamento = Convert.ToDateTime(Console.ReadLine());

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
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"O equipamento \"{novoEquipamento.Nome}\" foi cadastrado com sucesso!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }

            else if (opcaoMenu == "2")
            {
                System.Console.WriteLine("-------------------------------");
                System.Console.WriteLine("Gestão de Equipamentos!");
                System.Console.WriteLine("-------------------------------");
                System.Console.WriteLine("Edição de Equipamento: ");

                System.Console.WriteLine(
                    "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}"
                    , "ID", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação");

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

                string? idSelecionado;
                do
                {
                    System.Console.Write("Digite o ID do produto que deseja EDITAR: ");
                    idSelecionado = Console.ReadLine();

                    if (!String.IsNullOrEmpty(idSelecionado) && idSelecionado.Length == 7)
                        break;
                } while (true);

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
                if (equipamentoSelecionado == null)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"O equipamento com o ID NÃO foi encontrado!");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                    continue;
                }
                Equipamento novoEquipamento = new Equipamento();
                do
                {
                    System.Console.Write("\nDigite o NOME do equipamento: ");
                    novoEquipamento.Nome = Console.ReadLine();

                    if (!String.IsNullOrEmpty(novoEquipamento.Nome) && novoEquipamento.Nome.Length > 3)
                    {
                        break;
                    }
                    System.Console.WriteLine("Nome deve conter no mínimo 3 caracteres!");
                    Console.ReadLine();

                } while (true);

                do
                {
                    System.Console.Write("\nDigite o FABRICANTE do equipamento: ");
                    novoEquipamento.Fabricante = Console.ReadLine();

                    if (!String.IsNullOrEmpty(novoEquipamento.Fabricante) && novoEquipamento.Fabricante.Length > 3)
                    {
                        break;
                    }
                    System.Console.WriteLine("Fabricante deve conter no mínimo 3 caracteres!");
                    Console.ReadLine();

                } while (true);

                System.Console.Write("\nDigite o PREÇO do equipamento: ");
                novoEquipamento.PrecoAquisicao = Convert.ToDecimal(Console.ReadLine());

                System.Console.Write("\nDigite a DATA CADASTRADA do equipamento DD/MM/YYYY: ");
                DateTime dataEquipamento = Convert.ToDateTime(Console.ReadLine());

                equipamentoSelecionado.Nome = novoEquipamento.Nome;
                equipamentoSelecionado.Fabricante = novoEquipamento.Fabricante;
                equipamentoSelecionado.PrecoAquisicao = novoEquipamento.PrecoAquisicao;
                equipamentoSelecionado.DataFabricacao = novoEquipamento.DataFabricacao;

                Console.WriteLine("---------------------------------");
                Console.WriteLine($"O equipamento \"{equipamentoSelecionado.Id}\" foi EDITADO com sucesso!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();

            }

            else if (opcaoMenu == "3")
            {

            }

            else if (opcaoMenu == "4")
            {

            }
        }
    }
}