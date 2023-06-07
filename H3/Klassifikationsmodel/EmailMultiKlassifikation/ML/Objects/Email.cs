﻿using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMultiKlassifikation.ML.Objects
{
    public class Email
    {
        [LoadColumn(0)]
        public string Subject { get; set; }
        [LoadColumn(1)]
        public string Body { get; set; }
        [LoadColumn(2)]
        public string Sender { get; set; }
        [LoadColumn(3)]
        public string Category { get; set; }
    }
}