using FormFeedbackAPI.ConnectionStrings;
using FormFeedbackAPI.Models;

namespace FormFeedbackAPI.Repositories.Data
{
    public class PointRepository : GeneralRepository<Point>
    {
        public PointRepository(ConnectionString connectionString) : base(connectionString)
        {

        }
    }
}
