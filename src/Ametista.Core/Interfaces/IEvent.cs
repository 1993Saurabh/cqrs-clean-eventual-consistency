﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Core.Interfaces
{
    public interface IEvent
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime Date { get; set; }
    }
}
