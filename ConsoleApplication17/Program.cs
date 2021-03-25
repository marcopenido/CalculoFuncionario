using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Lista3
{
    class Program
    {
        /* Programa para excluir funcionarios por codigo de matricula,
            Maior salario e aumento de salario em % desejada*/

        //exercicio


        static void Main(string[] args)
        {
            Program fg = new Program();
            Funcionario f = new Funcionario();

            List<Funcionario> l = new List<Funcionario>();
            int numMatri = 0;
            double perAumento = 0;

            l.Add(f);

            string nomeArq = "textotest.txt";

            fg.LeArquivo(l, nomeArq);

            for (int i = 1; i < l.Count; i++)
            {
                Console.Write(l[i].Nome + " ");
                Console.Write(l[i].Idade + " ");
                Console.Write(l[i].Sexo + " ");
                Console.Write(l[i].Salario + " ");
                Console.Write(l[i].Matricula + " ");
                Console.Write("\n");
            }

            Console.Write("\nInforme matricula para excluir um funcionario: ");
            numMatri = int.Parse(Console.ReadLine());

            fg.ExcluiFunc(l, numMatri);

            Console.Write("\nFuncionario com o maior salário: " + fg.MaiorSalario(l).Nome);

            Console.Write("\n\nDigite a porcetagem requerida para aumento: ");
            perAumento = Convert.ToDouble(Console.ReadLine());

            fg.AumentoSalario(l, perAumento);

            Console.ReadKey();
        }


        public void LeArquivo(List<Funcionario> al, string nomeArq)
        {
            try
            {
                using (StreamReader sr = new StreamReader(nomeArq))
                {
                    string[] vetline;
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        vetline = line.Split(';');
                        Funcionario f = new Funcionario(vetline[0], int.Parse(vetline[1]), Convert.ToChar(vetline[2]), double.Parse(vetline[3]), int.Parse(vetline[4]));
                        al.Add(f);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\a\a\a\aError");
                Console.WriteLine(e.Message);
            }
        }


        public void ExcluiFunc(List<Funcionario> l, int numMatri)
        {
            int idPosi = 0;

            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Matricula == numMatri)
                {
                    idPosi = i;
                }
            }

            l.RemoveAt(idPosi);

            Console.Write("\n");
            Console.Write("Funcionario de matricula " + numMatri + " foi excludio com sucesso.\n\n");
            for (int i = 1; i < l.Count; i++)
            {
                Console.Write(l[i].Nome + " ");
                Console.Write(l[i].Idade + " ");
                Console.Write(l[i].Sexo + " ");
                Console.Write(l[i].Salario + " ");
                Console.Write(l[i].Matricula + " ");
                Console.Write("\n");
            }
        }


        public Funcionario MaiorSalario(List<Funcionario> l)
        {
            double maior = 0;
            int idMaior = 0;

            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Salario > maior)
                {
                    maior = l[i].Salario;
                    idMaior = i;
                }
            }

            return l[idMaior];
        }


        public void AumentoSalario(List<Funcionario> l, double perAumento)
        {
            double somaAumento = 0;
            double salTotal = 0;
            double[] armazenaSal = new double[l.Count];

            for (int i = 0; i < l.Count; i++)
            {
                somaAumento = (l[i].Salario * perAumento) / 100;
                salTotal = l[i].Salario + somaAumento;
                armazenaSal[i] = salTotal;
            }


            Console.Write("\n");
            Console.Write("Aumento de " + perAumento + "%" + " no salário dos funcionários.\n\n");
            for (int i = 1; i < l.Count; i++)
            {
                Console.Write(l[i].Nome + " ");
                Console.Write(l[i].Idade + " ");
                Console.Write(l[i].Sexo + " ");
                Console.Write(armazenaSal[i] + " ");
                Console.Write(l[i].Matricula + " ");
                Console.Write("\n");
            }
        }
    }

    class Funcionario
    {
        private string nome;
        private int idade;
        private char sexo;
        private double salario;
        private int matricula;


        public Funcionario()
        {

        }


        public Funcionario(string nome, int idade, char sexo, double salario, int matricula)
        {
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            Salario = salario;
            Matricula = matricula;
        }


        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public int Idade
        {
            get { return idade; }

            set { idade = value; }
        }
        public char Sexo
        {
            get { return sexo; }

            set { sexo = value; }
        }
        public double Salario
        {
            get { return salario; }

            set { salario = value; }
        }
        public int Matricula
        {
            get { return matricula; }

            set { matricula = value; }
        }
    }
}