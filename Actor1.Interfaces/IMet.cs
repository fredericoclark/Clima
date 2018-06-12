using System;
using System.Collections.Generic;
using System.Text;
using Measurements;
using Microsoft.ServiceFabric.Actors;
using System.Threading.Tasks;

namespace Actor1.Interfaces
{
    public interface IMet : IActor
    {
        Task EnviaMedicoes(Medicoes medicoes);
    }
}
