using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Snappet.Core.Repository
{
    public class ClassStatisticRepository : IClassStatisticRepository
    {
        private List<ClassWorkRowData> _classStatisticDataset;

        public ClassStatisticRepository(string datasetPath)
        {
            InitializeDatasetMock(datasetPath);
        }

        public IEnumerable<ClassWorkRowData> GetClassWorkStatistic()
        {
            return _classStatisticDataset;
        }

        private void InitializeDatasetMock(string datasetPath)
        {
            var rowJson = File.ReadAllText(datasetPath);
            var rowObjects = JsonConvert.DeserializeObject<List<ClassWorkRowData>>(rowJson);

            _classStatisticDataset = rowObjects;
        }
    }
}
