using System;
using System.Collections.Generic;
using System.Linq;

namespace AtividadeAcademia
{
    class Program
    {
        static List<string> name = new List<string>();
        static List<string> muscGp = new List<string>();
        static List<double> load = new List<double>();
        static List<int> rep = new List<int>();

        static void Main(string[] args)
        {
            string opcao = "";

            while (opcao != "0")
            {
                Console.WriteLine("--- MENU ACADEMIA ---");
                Console.WriteLine("1 - Adicionar exercício");
                Console.WriteLine("2 - Listar exercícios");
                Console.WriteLine("3 - Buscar exercício por nome");
                Console.WriteLine("4 - Filtrar por grupo muscular");
                Console.WriteLine("5 - Calcular carga total do treino");
                Console.WriteLine("6 - Exibir exercício mais pesado");
                Console.WriteLine("7 - Remover exercício");
                Console.WriteLine("0 - Sair");
                Console.Write("\nEscolha: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": Cadastrar(); break;
                    case "2": Listar(); break;
                    case "3": Buscar(); break;
                    case "4": Filtrar(); break;
                    case "5": SomaCarga(); break;
                    case "6": MaisPesado(); break;
                    case "7": Deletar(); break;
                    case "0": Console.WriteLine("Saindo..."); break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
                
                if (opcao != "0")
                {
                    Console.WriteLine("\n[Pressione Enter]");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        static void Cadastrar()
        {
            Console.Write("Nome do exercício: ");
            string n = Console.ReadLine();
            while (string.IsNullOrEmpty(n))
            {
                Console.Write("Nome obrigatório. Digite novamente: ");
                n = Console.ReadLine();
            }

            Console.Write("Grupo muscular: ");
            string g = Console.ReadLine();

            double l;
            while (true)
            {
                Console.Write("Carga (kg): ");
                if (double.TryParse(Console.ReadLine(), out l) && l >= 0) break;
                Console.WriteLine("Valor inválido.");
            }

            int r;
            while (true)
            {
                Console.Write("Repetições: ");
                if (int.TryParse(Console.ReadLine(), out r) && r >= 1) break;
                Console.WriteLine("Valor inválido.");
            }

            name.Add(n);
            muscGp.Add(g);
            load.Add(l);
            rep.Add(r);
            Console.WriteLine("Cadastrado com sucesso!");
        }

        static void Listar()
        {
            if (name.Count == 0)
            {
                Console.WriteLine("Lista vazia.");
                return;
            }

            for (int i = 0; i < name.Count; i++)
            {
                Console.WriteLine($"{name[i]} - {muscGp[i]} - {load[i]}kg - {rep[i]} reps");
            }
        }

        static void Buscar()
        {
            Console.Write("Nome para busca: ");
            string busca = Console.ReadLine();
            
            int idx = name.FindIndex(x => x.Equals(busca, StringComparison.OrdinalIgnoreCase));

            if (idx != -1)
                Console.WriteLine($"Achado: {name[idx]} | Grupo: {muscGp[idx]} | Carga: {load[idx]}kg | Reps: {rep[idx]}");
            else
                Console.WriteLine("Exercício não encontrado.");
        }

        static void Filtrar()
        {
            Console.Write("Grupo muscular: ");
            string grupo = Console.ReadLine();

            var encontrados = name.Where((n, i) => muscGp[i].Equals(grupo, StringComparison.OrdinalIgnoreCase)).ToList();

            if (encontrados.Any())
            {
                Console.WriteLine($"Exercícios de {grupo}:");
                foreach (var item in encontrados) Console.WriteLine("- " + item);
            }
            else Console.WriteLine("Nada encontrado para esse grupo.");
        }

        static void SomaCarga()
        {
            double total = load.Sum();
            Console.WriteLine($"Carga total: {total} kg");
        }

        static void MaisPesado()
        {
            if (load.Count == 0) return;

            double maior = load.Max();
            int idx = load.IndexOf(maior);

            Console.WriteLine($"Mais pesado: {name[idx]} com {maior}kg");
        }

        static void Deletar()
        {
            Console.Write("Nome para remover: ");
            string busca = Console.ReadLine();

            int idx = name.FindIndex(x => x.Equals(busca, StringComparison.OrdinalIgnoreCase));

            if (idx != -1)
            {
                name.RemoveAt(idx);
                muscGp.RemoveAt(idx);
                load.RemoveAt(idx);
                rep.RemoveAt(idx);
                Console.WriteLine("Removido.");
            }
            else Console.WriteLine("Não encontrado.");
        }
    }
}