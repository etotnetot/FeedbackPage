﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.DAL.Services
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = this._configuration["ConnectionString:MyConnectionString"];
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
