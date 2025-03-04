﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticHub.Domain.Entities
{
    public abstract class Entity<TPrimaryKey>
    {
        public required TPrimaryKey Id { get; set; }
    }
    public abstract class Entity : Entity<int>
    {

    }
}
