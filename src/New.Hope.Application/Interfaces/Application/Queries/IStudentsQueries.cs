using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using New.Hope.Domain;

namespace New.Hope.Application
{
    public interface IStudentsQueries
    {
        Student GetById(int id);
    }
}