using System;
using System.Threading.Tasks;
using New.Hope.Domain;

namespace New.Hope.Application.Interfaces.Application.Commands
{
    public interface IStudentsCommands
    {
        Student CreateStudent(Student entity);
    }
}
