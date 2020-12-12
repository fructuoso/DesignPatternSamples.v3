using System;
using DesignPatternSamples.Domain.Core.Entity;

namespace DesignPatternSamples.WebAPI.Controllers
{
    public class PalestraController : GenericControllerCrud<Guid, Palestra, Palestra>
    {
        public PalestraController(IServiceProvider serviceProvider) : base(serviceProvider) { }
    }
}