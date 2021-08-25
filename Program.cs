using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            String opcaoUsuario = ObterOpcaoUsuario(); 
            Int16 indiceAluno = 0;
            Aluno[] alunos = new Aluno[5];

            while (opcaoUsuario.ToUpper() != "4")
            {

                switch (opcaoUsuario)
                {
                    case "1":

                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        //Realiza tratativa de erro no Parse e atribui à variável nota
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");

                            }
                        }


                        break;

                    case "3":

                        decimal notaTotal = 0;
                        decimal mediaGeral = 0;
                        var numeroAlunos = 0;

                        
                        for(int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                numeroAlunos++;
                            }

                        }

                        mediaGeral = notaTotal / numeroAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if ( mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else 
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"A média geral é: {mediaGeral} - Conceito: {conceitoGeral}.");


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
            Console.WriteLine("4- Sair");
            Console.WriteLine();

            String opcaoUsuario = Console.ReadLine();

            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
