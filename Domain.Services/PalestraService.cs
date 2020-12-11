using DesignPatternSamples.Domain.Core.Entity;
using DesignPatternSamples.Domain.Core.Interfaces.Repository;
using DesignPatternSamples.Publisher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSamples.Domain.Services
{
    public class PalestraService : GenericServiceCrud<Guid, Palestra>
    {
        private readonly IPublisher _Publisher;

        public PalestraService(
            IRepositoryCrud<Guid, Palestra> repository,
            IPublisher publisher,
            IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _Publisher = publisher;
        }

        public override async Task<Palestra> UpdateAsync(Palestra obj)
        {
            Palestra anterior = await GetAsync(obj.Id);
            Palestra retorno = await base.UpdateAsync(obj);

            if (anterior.GitHub != null && anterior.GitHub != obj.GitHub)
            {
                await _Publisher.PublishDataAsync("GITHUB_ATUALIZADO", retorno);
            }

            return retorno;
        }
    }
}
