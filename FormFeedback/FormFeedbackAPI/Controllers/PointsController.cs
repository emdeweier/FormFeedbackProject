using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormFeedbackAPI.Bases;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories;
using FormFeedbackAPI.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : BasesController<Point, PointRepository>
    {
        public PointsController(PointRepository pointRepository): base(pointRepository)
        {

        }
    }
}