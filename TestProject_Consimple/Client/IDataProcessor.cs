using System;
using System.Collections.Generic;
using TestProject_Consimple.Models;

namespace TestProject_Consimple.Client
{
    interface IDataProcessor
    {
        List<Tuple<string, string>> CreateTable(BaseModel model); 
    }
}
