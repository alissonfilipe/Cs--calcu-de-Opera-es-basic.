// See https://aka.ms/new-console-template for more information

using System;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;


class Program {
    
    static void Main(String[] args)
    {
        
        string padrao = @"^[0-9+\-*/]+$";
        while (true)
        {
            
            Console.WriteLine("digite uma operação que quer fazer! digite apenas números e operadores");
            Console.WriteLine("                                EXEMPLO                               ");
            Console.WriteLine("______________________________________________________________________");
            Console.WriteLine("DIGITADO         |            SIGNIFICADO            |       RESULTADO");
            Console.WriteLine("_________________|___________________________________|________________");
            Console.WriteLine("2+3              |          dois mais três           |            5   ");
            Console.WriteLine("2*3              |          dois vezes três          |            6   ");
            Console.WriteLine("2/3              |       dois dividido por três      |          0.667" );
            Console.WriteLine("2-3              |          dois menos três          |           -1   \n");
            Console.WriteLine("Digite a operação desejada");
            string digitado = Console.ReadLine();
            bool TaNoPadrao = Regex.IsMatch(digitado, padrao);
            bool PrimeiroElementoNumero = Char.IsDigit(digitado[0]);
            bool PrimeiraExecao = eUmaExecao(digitado, "**");
            bool SegundaExecao = eUmaExecao(digitado, "//");

            if (TaNoPadrao && PrimeiroElementoNumero && PrimeiraExecao && SegundaExecao)
            {
                //oprações aqui, verificar as operações para fazer
                DataTable objetoAuxiliar = new DataTable();
                var resultado = objetoAuxiliar.Compute(digitado, "");
                Console.WriteLine($"OPERAÇÃO: {digitado}");
                Console.WriteLine($"RESULTADO: {resultado}");
                //fim das operações
                Console.WriteLine("Deseja continuar? 1 para sim e 0 para não");
                ConsoleKeyInfo key = Console.ReadKey();
                char resposta = key.KeyChar;
                Console.WriteLine();
                if (resposta == '0')
                {
                    Console.WriteLine("Operação finalizada!");
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
            else
            {
                Console.Clear();
            }



            
        }




        bool eUmaExecao(string variavel, string execao)
        {
            for (int indice = 0; indice < variavel.Length - 1; indice++)
            {
                string verificarExecao = variavel.Substring(indice, 2);
                if (verificarExecao == execao)
                {
                    return false;
                }
            }
            return true;
        }

    }







}


