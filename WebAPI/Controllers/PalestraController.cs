using DesignPatternSamples.Domain.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using System;


namespace DesignPatternSamples.WebAPI.Controllers
{
    [ApiController]
    public class PalestraController : GenericControllerCrud<Guid, Palestra, Palestra>
    {
        public PalestraController(IServiceProvider serviceProvider) : base(serviceProvider) { }
    }
}
