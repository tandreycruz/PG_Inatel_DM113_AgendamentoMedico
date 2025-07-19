using AgendamentoMedico_SoapProducer.Model;
using System.ServiceModel;

namespace AgendamentoMedico_SoapProducer.Service
{
    [ServiceContract]
    public interface IAgendamentoMedicoService
    {
        [OperationContract]
        List<AgendamentoMedico> GetAllAgendamentoMedico();

        [OperationContract]
        AgendamentoMedico GetAgendamentoMedico(int id);

        [OperationContract]
        AgendamentoMedico InsertAgendamentoMedico(AgendamentoMedico novoAgendamento);

        [OperationContract]
        AgendamentoMedico UpdateAgendamentoMedico(AgendamentoMedico agendamentoAtualizado);
    }
}
