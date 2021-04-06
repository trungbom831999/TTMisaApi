using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.DataConnector
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataConnector : ControllerBase
    {
        string _connectionString = "" +
              "Host=47.241.69.179; " +
              "Port=3306;" +
              "User Id= dev; " +
              "Password=12345678;" +
              "Database= MF0_NVManh_CukCuk02";
        IDbConnection _dbConnection;
    }
}
