using System.Collections.Generic;
using System.Linq;
using AgendamentoMedico_SoapProducer.Model;

namespace AgendamentoMedico_SoapProducer.Service
{
    public class AgendamentoMedicoService : IAgendamentoMedicoService
    {
        private static readonly Dictionary<int, AgendamentoMedico> _agendamentos = new();
        private static int _proximoId = 1;

        public List<AgendamentoMedico> GetAllAgendamentoMedico() =>
            _agendamentos.Values.ToList();

        public AgendamentoMedico GetAgendamentoMedico(int id) =>
            _agendamentos.TryGetValue(id, out var agendamento) ? agendamento : null;

        public AgendamentoMedico InsertAgendamentoMedico(AgendamentoMedico novoAgendamento)
        {
            if (string.IsNullOrWhiteSpace(novoAgendamento.Paciente) ||
                string.IsNullOrWhiteSpace(novoAgendamento.Medico) ||
                string.IsNullOrWhiteSpace(novoAgendamento.Local) ||
                string.IsNullOrWhiteSpace(novoAgendamento.Data) ||
                string.IsNullOrWhiteSpace(novoAgendamento.Hora))
            {
                return null;
            }

            novoAgendamento.Id = _proximoId++;
            _agendamentos[novoAgendamento.Id] = novoAgendamento;
            return novoAgendamento;
        }

        public AgendamentoMedico UpdateAgendamentoMedico(AgendamentoMedico agendamentoAtualizado)
        {
            if (!_agendamentos.ContainsKey(agendamentoAtualizado.Id))
                return null;

            _agendamentos[agendamentoAtualizado.Id] = agendamentoAtualizado;
            return agendamentoAtualizado;
        }
    }
}