﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluentbot.Contracts.Messages.Lifetime.Service
{
    public record ServiceCrashed
    {
        public string Message { get; init; }
    }
}
