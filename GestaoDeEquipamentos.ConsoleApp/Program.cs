using GestaoDeEquipamentos.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Equipamento[] equipamentos = new Equipamento[100];

        while (true)
        {
            Console.ReadLine();
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

                Console.ReadLine();
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
                    novoEquipamento.nome = Console.ReadLine();

                    if (!String.IsNullOrEmpty(novoEquipamento.nome) && novoEquipamento.nome.Length > 3)
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
                Console.WriteLine($"O equipamento \"{novoEquipamento.nome}\" foi cadastrado com sucesso!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }

            else if (opcaoMenu == "2")
            {

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