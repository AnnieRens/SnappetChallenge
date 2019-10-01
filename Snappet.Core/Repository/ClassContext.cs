using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Snappet.Core.Repository
{
    public class ClassContext
    {
        public List<Student> Students { get; set; } // ICollection?

        public List<Exercise> Exercises { get; set; }

        public List<ExerciseSubmitAnswer> ExerciseSubmitAnswers { get; set; }


        public ClassContext(string datasetPath)
        {
            InitializeDatasets(datasetPath);
        }

        private void InitializeDatasets(string datasetPath)
        {
            var rowJson = File.ReadAllText(datasetPath);
            var rowObjects = JsonConvert.DeserializeObject<List<ClassWorkRowData>>(rowJson);

            Students = rowObjects.Select(x => x.UserId)
                .Distinct()
                .Select(x => new Student {Id = x})
                .ToList();
            
            Exercises = rowObjects.GroupBy(x => x.ExerciseId).Select(e => new Exercise
                {

                })
                .ToList();

            ExerciseSubmitAnswers = rowObjects.Select(x => new ExerciseSubmitAnswer
            {
                Id = x.SubmittedAnswerId,
                ExerciseId = x.ExerciseId,
                UserId = x.UserId,
                SubmitDateTime = new DateTimeOffset(x.SubmitDateTime.Year, x.SubmitDateTime.Month, x.SubmitDateTime.Day, x.SubmitDateTime.Hour, x.SubmitDateTime.Minute, x.SubmitDateTime.Second, x.SubmitDateTime.Millisecond, TimeSpan.Zero),
                Correct = x.Correct,
                Progress = x.Progress
            }).ToList();
        }

        internal class ClassWorkRowData
        {
            public int SubmittedAnswerId { get; set; }
            public DateTimeOffset SubmitDateTime { get; set; }
            public bool Correct { get; set; }
            public int Progress { get; set; }
            public int UserId { get; set; }
            public int ExerciseId { get; set; }
            public string Difficulty { get; set; }
            public string Subject { get; set; }
            public string Domain { get; set; }
            public string LearningObjective { get; set; }
        }
    }
}