namespace Snappet.Core.AppService
{
    public class UserProgress
    {
        public int Id { get; set; }

        public double Progress { get; set; }

        public UserProgress(int id, double progress)
        {
            Id = id;
            Progress = progress;
        }
    }
}