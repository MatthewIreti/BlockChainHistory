﻿using BlockHistoryApp.Repository;
using BlockHistoryApp.Repository.Database;
using BlockHistoryApp.Service.Common;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockHistoryApp.Service
{
    public interface IEtherumService
    {
        Task<Response<BlockEntity>> DeleteAll();
        Task<Response<BlockEntity>> DeleteById(int id);
        Task<Response<IEnumerable<BlockEntity>>> GetAll();
    }

    public class EtherumService : IEtherumService
    {
        private IEtherumRepository _repository;
        public EtherumService(IEtherumRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<IEnumerable<BlockEntity>>> GetAll()
        {
            var response = Response<IEnumerable<BlockEntity>>.Failed();
            try
            {
                GetBlockByNumber();
                var data =  _repository.GetAll().OrderByDescending(x=>x.Id);
                response = Response<IEnumerable<BlockEntity>>.Success(data);
            }
            catch (Exception ex)
            {
                response = Response<IEnumerable<BlockEntity>>.Failed(ex.Message);
            }
            return await Task.FromResult(response);
        }
        public async Task<Response<BlockEntity>> DeleteAll()
        {
            var response = Response<BlockEntity>.Failed();
            try
            {
                 _repository.DeleteAll();
                response = Response<BlockEntity>.Success(null);
            }
            catch (Exception ex)
            {
                response = Response<BlockEntity>.Failed(ex.Message);
            }
            return await Task.FromResult(response);
        }
        public async Task<Response<BlockEntity>> DeleteById(int id)
        {
            var response = Response<BlockEntity>.Failed();
            try
            {
                _repository.Delete(id);
                response = Response<BlockEntity>.Success(null);
            }
            catch (Exception ex)
            {
                response = Response<BlockEntity>.Failed(ex.Message);
            }
            return await Task.FromResult(response);
        }

        private async Task<LatestBlock> GetLatestBlockAsync()
        {
            var payload = new EtherumPayload
            {
                Id = 1,
                Jsonrpc = "2.0",
                Method = "eth_blockNumber",
                Params = new object[] { }
            };
            var response = await EtherumPayload.baseUrl.AllowAnyHttpStatus().PostJsonAsync(payload);
            if (response.StatusCode == 200)
            {
                return await response.GetJsonAsync<LatestBlock>();
            }
            return null;
        }


        private async void GetBlockByNumber()
        {
            var block = await GetLatestBlockAsync();
            if (block != null)
            {
                var payload = new EtherumPayload
                {
                    Id = 1,
                    Jsonrpc = "2.0",
                    Method = "eth_getBlockByNumber",
                    Params = new object[] { block.Result, false}
                };
                var response = await EtherumPayload.baseUrl.AllowAnyHttpStatus().PostJsonAsync(payload);
                if (response.StatusCode == 200)
                {
                    var data =  await response.GetJsonAsync<InfuraResponse>();
                    if(data.Result != null)
                    {
                        _repository.Create(data.Result);

                    }
                }
            }
        }

    }
}
