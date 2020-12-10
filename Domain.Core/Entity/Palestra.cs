using System;

namespace DesignPatternSamples.Domain.Core.Entity
{
    public class Palestra : BaseEntity<Guid>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public TimeSpan Duracao { get => DataTermino.Subtract(DataInicio); }
        public string Instrutor { get; set; }
        public string GitHub { get; set; }
    }
}