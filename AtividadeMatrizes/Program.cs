// See https://aka.ms/new-console-template for more information
Console.WriteLine("2025105388 - Bianca Michoski Cabral");
Console.WriteLine("2025106086 - Gabriel Marczal dos Santos");
Console.WriteLine("2025105756 - José Antonio Guides");
Console.WriteLine("2025106239 - Thais Carvalheiro\n");

int mesConvert = 0;
int anoConvert = 0;
string[,] calendario = new string[7, 7];

string[] mesArray = {"Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

for(int i = 0; i < 1; i++)
{
    Console.WriteLine("Bem-vindo ao calendário!\n");

    Console.WriteLine("Digite o mês (0 a 11): ");
    string mes = Console.ReadLine();
    bool validarMes = int.TryParse(mes, out mesConvert);
    if(!validarMes){
        Console.WriteLine("Entrada inválida. Tente novamente.");
        i--;
        continue;
    }
    if (mesConvert < 0 || mesConvert > 12){
        Console.WriteLine("Mês inválido. Tente novamente.");
        i--;
    }
    Console.WriteLine("Digite o ano: ");
    string ano = Console.ReadLine();
    bool validarAno = int.TryParse(ano, out anoConvert);
    if (anoConvert < 1){
        Console.WriteLine("Ano inválido. Tente novamente.");
        i--;
        continue;
    }
    Console.WriteLine($"{mesArray[mesConvert]} de "+ anoConvert);
    if (validarAno && validarMes){
       criarCalendario(calendario, mesConvert, anoConvert);
        imprimirCalendario(calendario);
    }
}


static void criarCalendario(string[,] calendario, int mesConvert, int anoConvert)
{
    string[] diasDaSemana = { "D", "S", "T", "Q", "Q", "S", "S" };
    for (int i = 0; i < 7; i++)
    {
        calendario[0, i] = diasDaSemana[i];
    }

    DateTime primeiroDiaDoMes = new DateTime(anoConvert, mesConvert+1, 1);
    int primeiroDiaSemana = (int)primeiroDiaDoMes.DayOfWeek; 
    int totalMes = DateTime.DaysInMonth(anoConvert, mesConvert+1);

    int dia = 1;
    int linha = 1;
    int coluna = primeiroDiaSemana;

    while (dia <= totalMes)
    {
        calendario[linha, coluna] = dia.ToString();
        dia++;
        coluna++;

        if (coluna == 7)
        {
            coluna = 0;
            linha++;
        }
    }

    for (int i = 1; i < calendario.GetLength(0); i++)
    {
        for (int j = 0; j < calendario.GetLength(1); j++)
        {
            if (calendario[i, j] == null)
            {
                calendario[i, j] = " ";
            }
        }
    }
}
static void imprimirCalendario(string[,] tabuleiro)
{
     for (int i = 0; i < tabuleiro.GetLength(0); i++)
    {
        for (int j = 0; j < tabuleiro.GetLength(1); j++)
        {
            Console.Write($"{tabuleiro[i, j],2} ");
            if (j < 6) Console.Write("| ");
        }
        Console.WriteLine();
        if (i == 0 || i < 6)
        {
            Console.WriteLine("---------------------------------");
        }
    }
}
        