﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Services.Interface
{
    internal interface IBlobService
    {
        Task<string> Insert(string blobId, HttpResponseMessage responseMessage);
    }
}
