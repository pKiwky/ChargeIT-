using Domain.Models.Commands;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Contracts.Commands {

    public interface IChargeMachineCommand {
        Task<int> Create(CreateChargeMachineRequest createChargeMachineRequest);
        Task Delete(int id);
        Task Update(int id, UpdateChargeMachineRequest updateChargeMachineRequest);
        Task Patch(int id, JsonPatchDocument<UpdateChargeMachineRequest> jsonPatchDocument);
    }

}