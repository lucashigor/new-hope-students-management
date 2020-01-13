using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using New.Hope.Domain;
using New.Hope.Application.Repository;

namespace New.Hope.Application
{
    public class StudentsQueries : IStudentsQueries
    {
        private readonly IStudentsRepository _repository;

        public StudentsQueries(IStudentsRepository repository)
        {
            _repository = repository;
        }
        public Student GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}