﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface IArTransportDetails : ICommonService<ArTransportDetail>
    {
        void RemoveRangeofDetails();
        void RemoveRangeofDetailsById(int id);
    }
}