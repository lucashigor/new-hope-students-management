using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using New.Hope.Domain;

namespace New.Hope.Application.Interfaces.ExternalServices
{
    public interface IIbgeExternalService
    {
        Task<List<Region>> RegionsAsync();
    }
}
