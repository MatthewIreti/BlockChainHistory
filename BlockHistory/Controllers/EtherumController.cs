using BlockHistoryApp.Repository.Database;
using BlockHistoryApp.Service;
using BlockHistoryApp.Service.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockHistory.Controllers
{
    [Route("api/ethereum")]
    [ApiController]
    public class EtherumController : ControllerBase
    {
        private readonly IEtherumService _service;
        public EtherumController(IEtherumService service)
        {
            _service = service;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Response<IReadOnlyList<BlockEntity>>>> Get()
        {
            try
            {
                var response = await _service.GetAll();
                if (response.Status)
                    return Ok(response);
                return BadRequest(Response<IReadOnlyList<BlockEntity>>.Failed(response.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<IReadOnlyList<BlockEntity>>.Failed(ex.Message));
            }
        }

        [HttpDelete("delete-all")]
        public async Task<ActionResult<Response<BlockEntity>>> DeletAll()
        {
            try
            {
                var response = await _service.DeleteAll();
                if (response.Status)
                    return Ok(response);
                return BadRequest(Response<BlockEntity>.Failed(response.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<BlockEntity>.Failed(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<BlockEntity>>> DeleteById(int id)
        {
            try
            {
                var response = await _service.DeleteById(id);
                if (response.Status)
                    return Ok(response);
                return BadRequest(Response<BlockEntity>.Failed(response.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<BlockEntity>.Failed(ex.Message));
            }
        }
    }
}
