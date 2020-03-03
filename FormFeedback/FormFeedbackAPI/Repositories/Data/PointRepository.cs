using FormFeedbackAPI.ConnectionStrings;
using FormFeedbackAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Repositories.Data
{
    public class PointRepository : GeneralRepository<Point>
    {
        public PointRepository(ConnectionString connectionString):base(connectionString)
        {

        }
    }
}
