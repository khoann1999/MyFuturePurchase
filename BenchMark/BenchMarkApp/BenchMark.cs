using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace MyFurturePurchase.BenchMarkApp
{
    [MinColumn, MaxColumn]
    [MarkdownExporter]
    public class BenchMark
    {
        private readonly RestClient _restClient = new RestClient();
        [Params("3fa85f64-5717-4562-b3fc-2c963f66afa6")]
        public string ids;
        [Params(10,20)]
        public int IterationCount;
        [Benchmark]
        public async Task GetRedis()
        {
                await _restClient.GetItemRedisAsync(ids);
        }
        [Benchmark]
        public async Task Get()
        {
                await _restClient.GetItemAsync(ids);
        }
    }
}