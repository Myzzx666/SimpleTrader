using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        private readonly FinancialModelingPrepHttpClient _client;

        public MajorIndexService(FinancialModelingPrepHttpClient client)
        {
            _client = client;
        }

        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            //并发Http请求
            string uri = "majors-indexes/" + GetUriSuffix(indexType);
            //await Task.Delay(3000);
            //MajorIndex majorIndex = await _client.GetAsync<MajorIndex>(uri);
            //majorIndex.Type = indexType;
            MajorIndex majorIndex = new MajorIndex();
            try
            {
                majorIndex = await _client.GetAsync<MajorIndex>(uri); //获取一个新的MajorIndex数据对象实例
                majorIndex.Type = indexType;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return majorIndex;
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            switch(indexType)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default:
                    throw new Exception("MajorIndexType does not have a suffix defined.");
            }
        }
    }
}