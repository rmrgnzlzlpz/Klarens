using Application.Base;
using Application.Models;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class DeudaService : Service<Deuda>
    {
        public DeudaService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.DeudaRepository)
        {
        }

        public Response<Deuda> Add(DeudaRequest request)
        {
            Deuda entity = request.ToEntity();
            base.Add(entity);
            if (entity.Id == 0)
            {
                return new DeudaResponse("Deuda no registrada");
            }
            return new DeudaResponse("Deuda registrada", entity);
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