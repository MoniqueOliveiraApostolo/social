using Social.Domain.Entities;
using Social.Domain.Interfaces;

namespace Social.Service.Services
{
    public class ContatoService : BaseService<Contato>, IContatoService
    {
        public ContatoService(IContatoRepository repository) : base(repository)
        {
        }
    }
}