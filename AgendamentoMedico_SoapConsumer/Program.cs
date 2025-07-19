using System;
using System.Threading.Tasks;
using ServiceReference;

class Program
{
    static async Task Main()
    {
        var client = new AgendamentoMedicoServiceClient();

        while (true)
        {
            Console.WriteLine("\n\n===== AGENDAMENTO MÉDICO =====");
            Console.WriteLine("1 - Listar agendamentos");
            Console.WriteLine("2 - Consultar por ID");
            Console.WriteLine("3 - Criar novo agendamento");
            Console.WriteLine("4 - Atualizar agendamento");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("==============================\n");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var todos = await client.GetAllAgendamentoMedicoAsync();
                    foreach (var ag in todos)
                        Console.WriteLine($"\n{ag.Id} - {ag.Paciente} com {ag.Medico} às {ag.Hora} no {ag.Local} ({ag.Data})");
                    break;

                case "2":
                    Console.Write("\nID: ");
                    int idConsulta = int.Parse(Console.ReadLine());
                    var agendamento = await client.GetAgendamentoMedicoAsync(idConsulta);
                    if (agendamento != null)
                        Console.WriteLine($"Paciente: {agendamento.Paciente}, Médico: {agendamento.Medico}, Local: {agendamento.Local}, Data: {agendamento.Data}, Hora: {agendamento.Hora}");
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nAgendamento não encontrado.");
                        Console.ResetColor();
                    }
                    break;

                case "3":
                    var novo = CriarAgendamentoViaConsole();
                    var novoAgendamento = await client.InsertAgendamentoMedicoAsync(novo);
                    if (novoAgendamento != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nAgendamento criado com ID: {novoAgendamento.Id}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nTodos os campos devem ser preenchidos.");
                        Console.ResetColor();
                    }
                    break;

                case "4":
                    Console.Write("\nID a atualizar: ");
                    int idAtualizar = int.Parse(Console.ReadLine());
                    var atualizado = CriarAgendamentoViaConsole();
                    atualizado.Id = idAtualizar;
                    var agendamentoAtualizado = await client.UpdateAgendamentoMedicoAsync(atualizado);
                    if (agendamentoAtualizado != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nAtualização realizada.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nAgendamento não encontrado.");
                        Console.ResetColor();
                    }
                    break;

                case "0":
                    Console.WriteLine("Encerrando...");
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção inválida.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static AgendamentoMedico CriarAgendamentoViaConsole()
    {
        Console.Write("\nPaciente: ");
        string paciente = Console.ReadLine();

        Console.Write("Médico: ");
        string medico = Console.ReadLine();

        Console.Write("Local: ");
        string local = Console.ReadLine();

        Console.Write("Data (dd/mm/yyyy): ");
        string data = Console.ReadLine();

        Console.Write("Hora (hh:mm): ");
        string hora = Console.ReadLine();

        return new AgendamentoMedico
        {
            Paciente = paciente,
            Medico = medico,
            Local = local,
            Data = data,
            Hora = hora
        };
    }
}