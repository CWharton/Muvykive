﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muvykive.Model
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
