using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace YYC.Autofac.Services
{
    public class ValuesServiceV2 : IValuesService
    {
        private readonly ILogger<ValuesServiceV2> _logger;

        public ValuesServiceV2(ILogger<ValuesServiceV2> logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> FindAll()
        {
            _logger.LogDebug("{method} called", nameof(FindAll));

            return new[] { "v2", "value1", "value2" };
        }

        public string Find(int id)
        {
            _logger.LogDebug("{method} called with {id}", nameof(Find), id);

            return $"v2-value{id}";
        }
    }
}
