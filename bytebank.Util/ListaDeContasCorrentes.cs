using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util;

internal class ListaDeContasCorrentes
{
    private ContaCorrente[] _itens = null;
    private int _correntes = 0;

    public ListaDeContasCorrentes(int tamanho = 5)
    {
        _itens = new ContaCorrente[tamanho];
    }
    public void AdicionarConta(ContaCorrente contaCorrente)
    {
        VerificarCapacidade(_correntes + 1);
        _itens[_correntes] = contaCorrente;
        _correntes++;
    }
    private void VerificarCapacidade(int tamanhoNecessario)
    {
        if (_itens.Length >= tamanhoNecessario) { return; }
        Console.WriteLine("Aumentando a capacidade da lista");
        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];
        for (int i = 0; i < novoArray.Length; i++)
        {
            novoArray[i] = _itens[i];
        }
        _itens = novoArray;
    }
    public void Remover(ContaCorrente contaCorrente)
    {
        int indiceItem = -1;
        for (int i = 0; i < _correntes; i++)
        {
            ContaCorrente conta = _itens[i];
            if (conta == contaCorrente)
            {
                indiceItem = i;
                break;
            }
        }
        for (int i = indiceItem; i < _correntes - 1; i++)
        {
            _itens[i] = _itens[i + 1];
        }
        _correntes--;
        _itens[_correntes] = null;
    }
    public void ExibeLista()
    {
        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[i] != null)
            {
                var conta = _itens[i];
                Console.WriteLine($" Indice[{i}] = " +
                    $"Conta:{conta.Conta} - " +
                    $"N° da Agência: {conta.Numero_agencia}");
            }
        }
    }
    public ContaCorrente RecuperarItem(int indice)
    {
        if (indice < 0 || indice >= _correntes)
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }
        return _itens[indice];
    }
    public int Tamanho => _correntes;
    public ContaCorrente this[int i]
    {
        get
        {
            return RecuperarItem(i);
        }
    }
}
