using AutofacServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacServices
{
    public class SubService : ISubService
    {
        public int Sub(int x, int y)
        {
            return x - y;
        }
    }
}
