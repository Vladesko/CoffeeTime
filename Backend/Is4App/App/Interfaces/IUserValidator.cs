﻿using DomainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IUserValidator
    {
        void Validate(RegistrationViewModel model);
    }
}
