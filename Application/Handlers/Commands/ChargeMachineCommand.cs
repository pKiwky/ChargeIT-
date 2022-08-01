using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Contracts.Commands;
using Domain.Entities;
using Domain.Models.Commands;
using Mapster;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Handlers.Commands {

    public class ChargeMachineCommand : IChargeMachineCommand {
        private readonly IApplicationDbContext _applicationDbContext;

        public ChargeMachineCommand(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Create(CreateChargeMachineRequest createChargeMachineRequest) {
            var entity = createChargeMachineRequest.Adapt<ChargeMachineEntity>();
            _applicationDbContext.ChargeMachines.Add(entity);
            await _applicationDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(int id) {
            var entity = await _applicationDbContext.ChargeMachines.FindAsync(id);

            if (entity == null) {
                throw new NotFoundException(nameof(ChargeMachineEntity), id);
            }

            _applicationDbContext.ChargeMachines.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateChargeMachineRequest updateChargeMachineRequest) {
            var entity = await _applicationDbContext.ChargeMachines.FindAsync(id);

            if (entity == null) {
                throw new NotFoundException(nameof(ChargeMachineEntity), id);
            }

            entity.Number = updateChargeMachineRequest.Number;
            entity.Longitude = updateChargeMachineRequest.Longitude;
            entity.Latitude = updateChargeMachineRequest.Latitude;
            entity.City = updateChargeMachineRequest.City;
            entity.Street = updateChargeMachineRequest.Street;

            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Patch(int id, JsonPatchDocument<UpdateChargeMachineRequest> jsonPatchDocument) {
            var entity = await _applicationDbContext.ChargeMachines.FindAsync(id);

            if (entity != null) {
                var entityMapped = entity.Adapt<UpdateChargeMachineRequest>();
                jsonPatchDocument.ApplyTo(entityMapped);

                entityMapped.Adapt(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
        }
    }

}