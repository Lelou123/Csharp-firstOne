using System;

namespace _4_Aplicacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            string opcaoUsuario = ObterOpcaoUsuario();
            var indiceAluno = 0;
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        System.Console.WriteLine("Informe o nome do aluno");
                        Aluno aluno = new Aluno ();
                        aluno.Nome = Console.ReadLine();


                        System.Console.WriteLine("Informe a nota do aluno");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else 
                        {
                            throw new ArgumentException("A nota deve ser em decimal!");
                        }
                        
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    
                    case "2":
                        
                        foreach(var a in alunos )
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {   
                                System.Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota} ");    
                            }
                        }   
                        
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for(int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal+= alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        
                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral < 2)
                        {   
                            conceitoGeral = Conceito.E;
                        }

                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        System.Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO {conceitoGeral} ");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            Console.WriteLine("Informe a opcao desejada: ");
            System.Console.WriteLine("1- Inserir novo aluno");
            System.Console.WriteLine("2- Listar alunos");
            System.Console.WriteLine("3- Calcular média geral");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
