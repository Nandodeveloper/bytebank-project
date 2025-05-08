using System.Threading.Channels;
using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento;

internal class MetodosMenu
{
    public static void CadastrarConta(List<ContaCorrente> contas)
    {
        Console.Clear();
        Console.WriteLine("CADASTRO DE CONTA\n");
        Cliente cliente = new Cliente();
        Console.Write("Digite seu nome: ");
        cliente.Nome = Console.ReadLine()!;
        Console.Write("Digite seu CPF: ");
        cliente.Cpf = Console.ReadLine()!;
        Console.Write("Digite sua profissão: ");
        cliente.Profissao = Console.ReadLine()!;
        Console.WriteLine("Cliente cadastrado!");
        Thread.Sleep(1000);
        Console.Clear();

        Console.WriteLine("Cadastro de conta\n");
        Console.Write("Digite o número da agência: ");
        int agencia = int.Parse(Console.ReadLine()!);
        ContaCorrente conta = new ContaCorrente(agencia)
        {
            Titular = cliente
        };
        Console.WriteLine($"Numero da conta [NOVA] : {conta.Conta}");
        Console.Write("Digite o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine()!);
        contas.Add(conta);
        Console.WriteLine("\nConta cadastrada com sucesso!");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\nDigite uma tecla para voltar ao menu: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
    }
    public static void ListarContas(List<ContaCorrente> contasCorrentes)
    {
        Console.Clear();
        Console.WriteLine("LISTA DE CONTAS\n");
        if (contasCorrentes.Count <= 0)
        {
            Console.WriteLine("Nenhuma conta foi cadastrada.");
            Console.ReadKey();
            return;
        }
        foreach (ContaCorrente contaCorrente in contasCorrentes)
        {
            Console.WriteLine(contaCorrente);
            Console.WriteLine();
            Console.ReadKey();
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\nDigite uma tecla para voltar ao menu: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
    }
    public static void RemoverConta(List<ContaCorrente> contaCorrentes)
    {
        Console.Clear();
        Console.WriteLine("REMOVER CONTAS\n");
        Console.Write("Digite o número da conta que deseja remover: ");
        var numeroConta = Console.ReadLine()!;
        ContaCorrente conta = null;
        foreach (ContaCorrente contaEncontrada in contaCorrentes)
        {
            if (contaEncontrada.Conta.Equals(numeroConta))
            {
                conta = contaEncontrada;
            }
        }
        if (conta != null)
        {
            contaCorrentes.Remove(conta);
            Console.WriteLine("\nConta removida com sucesso!");
        }
        else
        {
            Console.WriteLine("\nConta para remoção não encontrada");
        }
        BotaoSair();
    }
    public static void Ordenar(List<ContaCorrente> contaCorrentes)
    {
        Console.Clear();
        Console.WriteLine("ORDENAR CONTAS\n");
        var contaOrdenada = contaCorrentes.OrderBy(conta => conta.Numero_agencia).Distinct().ToArray();
        foreach (var conta in contaOrdenada)
        {
            Console.WriteLine(conta);
            Console.ReadKey();
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\nDigite uma tecla para voltar ao menu: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
    }
    public static void Buscar(List<ContaCorrente> contaCorrentes)
    {
        Console.Clear();
        Console.WriteLine("BUSCAR CONTA\n");
        Console.WriteLine("1- Pesquisar por número da conta");
        Console.WriteLine("2- Pesquisar por cpf do titular");
        Console.WriteLine("3- Pesquisar por agência");
        Console.Write("\nDigite a sua opção: ");
        int opcao = int.Parse(Console.ReadLine()!);
        if (opcao == 1)
        {
            Console.Write("Digite o número da conta que deseja buscar: ");
            string numeroConta = Console.ReadLine()!;
            var contaPesquisa = contaCorrentes.Where(conta => conta.Conta.Equals(numeroConta)).FirstOrDefault();
            if (contaPesquisa == null)
            {
                Console.WriteLine("\nConta não encontrada.");
            }
            Console.WriteLine(contaPesquisa);
            BotaoSair();
        }
        else if (opcao == 2)
        {
            Console.Write("Digite o CPF da conta que deseja buscar: ");
            string cpf = Console.ReadLine()!;
            var contaPesquisa = contaCorrentes.Where(conta => conta.Titular.Cpf.Equals(cpf)).FirstOrDefault();
            if (contaPesquisa == null)
            {
                Console.WriteLine("\nConta não encontrada.");
            }
            Console.WriteLine(contaPesquisa);
            BotaoSair();
        }
        else if (opcao == 3)
        {
            Console.Write("Digite a agência das contas que deseja buscar: ");
            int agencia = int.Parse(Console.ReadLine()!);
            var contaPesquisa = contaCorrentes.Where(conta => conta.Numero_agencia.Equals(agencia)).Distinct().ToList();
            if (contaPesquisa.Count <= 0)
            {
                Console.WriteLine("\nConta não encontrada.");
            }
            foreach (var conta in contaPesquisa)
            {
                Console.WriteLine(conta);
                Console.ReadKey();
            }
            BotaoSair();
        }
        else
        {
            Console.WriteLine("\nOpção inválida");
            BotaoSair();
        }
    }
    public static void Sair()
    {
        Console.WriteLine();
        Console.Write("Saindo");
        Thread.Sleep(800);
        Console.Write(".");
        Thread.Sleep(800);
        Console.Write(".");
        Thread.Sleep(800);
        Console.Write(".");
        Thread.Sleep(800);
    }
    public static void BotaoSair()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\nDigite uma tecla para voltar ao menu: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
    }
}
