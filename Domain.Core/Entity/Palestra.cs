using System;

namespace DesignPatternSamples.Domain.Core.Entity
{
    public class Palestra : BaseEntity<Guid>
    {
        public string Titulo { get; set; }
        public string Palestrante { get; set; }
        public string GitHub { get; set; }
    }
}