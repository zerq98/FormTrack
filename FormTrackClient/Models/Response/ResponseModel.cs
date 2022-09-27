﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTrackClient.Models.Response
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public int Code { get; set; }
        public string ErrorMessage { get; set; }
    }
}
