using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;


namespace ExemploExplorando.Models
{
    public class Curso
    {
        public string Nome { get; set; }
        public List<Pessoa> Alunos { get; set; }

        public void AdicionarAluno(Pessoa aluno)
        {
            Alunos.Add(aluno);
        }

        public bool RemoverAluno(Pessoa aluno)
        {
            return Alunos.Remove(aluno);
        }

        public void ListarAlunos()
        {     
            Console.WriteLine($"Alunos matriculados no curso de {Nome}:");
                        
            for (int count = 0; count < Alunos.Count; count++)
            {
                string texto = $"{count + 1} - {Alunos[count].NomeCompleto}";
                Console.WriteLine(texto);
            }
        }
        public int ObterQuantidadeDeAlunosMatriculados() => Alunos.Count;
    }
}