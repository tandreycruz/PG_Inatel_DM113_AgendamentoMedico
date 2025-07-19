using System;
using System.Runtime.Serialization;

namespace AgendamentoMedico_SoapProducer.Model
{
    [DataContract]
    public class AgendamentoMedico
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Paciente { get; set; } = string.Empty;

        [DataMember]
        public string Medico { get; set; } = string.Empty;

        [DataMember]
        public string Local { get; set; } = string.Empty;

        [DataMember]
        public string Data { get; set; } = string.Empty;

        [DataMember]
        public string Hora { get; set; } = string.Empty;
    }
}