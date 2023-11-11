using DTOs.RideRealtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.RideRealTime
{
    public interface IUserMapHub
    {
        Task Testing(MapLocationDTO location);
    }
}
