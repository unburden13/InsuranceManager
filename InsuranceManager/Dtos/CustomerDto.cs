﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceManager.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}