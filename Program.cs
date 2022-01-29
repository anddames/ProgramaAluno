namespace Programa
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();
            //double media;

            while (opcaoUsuario.ToUpper() != "X")
            {

                switch (opcaoUsuario)
                {
                    case "1":
                        // Cadastra Alunos e nota
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        string nota2;
                        string nota;
                        bool isNumericDouble;

                        Console.WriteLine("Informe a 1° nota do aluno:");
                        nota = Console.ReadLine();
                        isNumericDouble = double.TryParse(nota, out double result);
                        if (isNumericDouble)
                        {
                            aluno.Nota = Convert.ToDouble(isNumericDouble);                           
                        }
                        else
                        {
                            Console.WriteLine("ERRO!!! DIGITA UM NUMERO VALIDO");
                        }

                        Console.WriteLine("Informe a 2° nota do aluno:");
                        nota2 = Console.ReadLine();
                        isNumericDouble = double.TryParse(nota2, out double numeric);
                        if (isNumericDouble)
                        {
                            aluno.Nota2 = Convert.ToDouble(isNumericDouble);                           
                        }
                        else
                        {
                            Console.WriteLine("ERRO!!! DIGITA UM NUMERO VALIDO");
                        }

                        double media = Aluno.calcularNota(aluno.Nota, aluno.Nota2);
                        aluno.Media = media;

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        // Mostra a relação do aluno e notas cadastradas 
                        
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Media}");
                            }

                        }
                        break;

                    case "3":
                        // Mostra a media geral dos aluno 
                        Double notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        // aplicando conceito de enum para clasificar o desempenho dos alunos 
                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}

