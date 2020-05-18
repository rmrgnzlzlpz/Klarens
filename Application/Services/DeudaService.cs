using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class DeudaService : BaseService<Deuda>
    {
        public DeudaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.DeudaRepository)
        {
        }

        public IResponse<Deuda> Add(DeudaRequest request)
        {
            return base.Add(request.ToEntity());
        }
        /*
        public IResponse<Deuda> Abonar(PagoRequest pago)
        {
            var persona = _unitOfWork.PersonaRepository.FindFirstOrDefault(x => x.Documento.Numero == pago.NumeroDocumento);
            if (persona == null) return new Response<Deuda>( mensaje: $"La persona con identificación {pago.NumeroDocumento} no existe" );

            persona.Abonar(pago.Valor);
        }
        */
    }
}