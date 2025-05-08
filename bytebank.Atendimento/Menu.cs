using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento;

internal class Menu
{
    public static void Run()
    {
        Cliente teste1 = new Cliente()
        {
            Nome = "Fernando",
            Cpf = "076.404.415-01"
        };
        Cliente teste2 = new Cliente()
        {
            Nome = "Ana Luiza",
            Cpf = "098.998.975-58"
        };
        List<ContaCorrente> _listaDeContas = new()
{
    new ContaCorrente(97) {Saldo=100, Titular = teste1},
    new ContaCorrente(95) {Saldo=200, Titular = teste2}
};
        try
        {
            void CentralAtendimento()
            {
                string menu = @"1- Cadastrar conta
2- Listar contas
3- Remover contas
4- Ordenar contas
5- Pesquisar contas
6- Sair do sistema
";
                int opcao = 0;
                while (opcao != 6)
                {
                    Console.WriteLine(menu);
                    Console.Write("Digite a sua opção: ");
                    try
                    {
                        opcao = int.Parse(Console.ReadLine()!);
                    }
                    catch (Exception exception)
                    {
                        throw new ByteBankException(exception.Message);
                    }
                    if (opcao == 1)
                    {
                        MetodosMenu.CadastrarConta(_listaDeContas);
                    }
                    else if (opcao == 2)
                    {
                        MetodosMenu.ListarContas(_listaDeContas);
                    }
                    else if (opcao == 3)
                    {
                        MetodosMenu.RemoverConta(_listaDeContas);
                    }
                    else if (opcao == 4)
                    {
                        MetodosMenu.Ordenar(_listaDeContas);
                    }
                    else if (opcao == 5)
                    {
                        MetodosMenu.Buscar(_listaDeContas);
                    }
                    else if (opcao == 6)
                    {
                        MetodosMenu.Sair();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção invalida.");
                        return;
                    }
                }
            }
            CentralAtendimento();
        }
        catch (ByteBankException ex)
        {
            Console.WriteLine($"{ex.Message}");
            throw;
        }
    }
}
