﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinBoard.Models.DataTypes
{
    [Serializable]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Tag()
        {
            Id = 0;
            Name = "";
        }
    }
}
