﻿using HX.Rider.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Common
{
    public interface ISugarDbContext
    {
        SqlSugarClient GetDbContext(string optionName = SqlSugarOptions.DbName);
    }
}
