using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Contracts.Queries;
using Domain.Entities;
using Domain.Models;
using Domain.Models.Queries.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Queries {

    public class ChargeMachineQuery : IChargeMachineQuery {
        private readonly IApplicationDbContext _applicationDbContext;

        public ChargeMachineQuery(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<GetChargeMachineResponse>> GetAll() {
            return await _applicationDbContext.ChargeMachines.ProjectToType<GetChargeMachineResponse>().ToListAsync();
        }

        public async Task<PaginatedObject<GetChargeMachineResponse>> GetPaginated(int pageNumber, int pageSize) {
            var datas = await _applicationDbContext.ChargeMachines
                .OrderBy(cm => cm.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectToType<GetChargeMachineResponse>()
                .ToListAsync();

            return new PaginatedObject<GetChargeMachineResponse>() {
                PageNumber = pageNumber,
                PageSize = pageSize,
                PageObjects = datas.Count,
                Data = datas
            };
        }

        public async Task<GetChargeMachineResponse> GetById(int id) {
            var entity = await _applicationDbContext.ChargeMachines.FindAsync(id);

            if (entity == null) {
                throw new NotFoundException(nameof(ChargeMachineEntity), id);
            }

            return entity.Adapt<GetChargeMachineResponse>();
        }
    }

}