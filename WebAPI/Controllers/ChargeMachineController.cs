using Application.Contracts.Commands;
using Application.Contracts.Queries;
using Domain.Models;
using Domain.Models.Commands;
using Domain.Models.Queries.Response;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers {

    public class ChargeMachineController : ApiController {
        private readonly IChargeMachineCommand _chargeMachineCommand;
        private readonly IChargeMachineQuery _chargeMachineQuery;

        public ChargeMachineController(IChargeMachineCommand chargeMachineCommand, IChargeMachineQuery chargeMachineQuery) {
            _chargeMachineCommand = chargeMachineCommand;
            _chargeMachineQuery = chargeMachineQuery;
        }

        [HttpGet]
        public async Task<IEnumerable<GetChargeMachineResponse>> GetAll() {
            return await _chargeMachineQuery.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<GetChargeMachineResponse> GetById(int id) {
            return await _chargeMachineQuery.GetById(id);
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<PaginatedObject<GetChargeMachineResponse>> GetPaginated(int pageNumber, int pageSize) {
            return await _chargeMachineQuery.GetPaginated(pageNumber, pageSize);
        }

        [HttpPost]
        public async Task<int> Post(CreateChargeMachineRequest createChargeMachineRequest) {
            return await _chargeMachineCommand.Create(createChargeMachineRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateChargeMachineRequest updateChargeMachineRequest) {
            await _chargeMachineCommand.Update(id, updateChargeMachineRequest);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<UpdateChargeMachineRequest> jsonPatchDocument) {
            await _chargeMachineCommand.Patch(id, jsonPatchDocument);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _chargeMachineCommand.Delete(id);
            return Ok();
        }
    }

}