﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessObject;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace DataAccess
{
    public class UserDA
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
