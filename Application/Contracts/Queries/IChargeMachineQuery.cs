using Domain.Models;
using Domain.Models.Queries.Response;

namespace Application.Contracts.Queries {

    public interface IChargeMachineQuery {
        Task<IEnumerable<GetChargeMachineResponse>> GetAll();
        Task<PaginatedObject<GetChargeMachineResponse>> GetPaginated(int pageNumber, int pageSize);
        Task<GetChargeMachineResponse> GetById(int id);
    }

}