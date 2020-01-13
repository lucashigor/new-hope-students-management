using System;
using System.Threading.Tasks;
using New.Hope.Application.Interfaces.Application.Commands;
using New.Hope.Application.Repository;
using New.Hope.Domain;

namespace New.Hope.Application.Commands
{
    public class StudentsCommands : IStudentsCommands
    {
        private readonly IStudentsRepository _repository;

        public StudentsCommands(IStudentsRepository repository)
        {
            _repository = repository;
        }

        public Student CreateStudent(Student entity)
        {
            return _repository.Create(entity);
        }
    }
}
