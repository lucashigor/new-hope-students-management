using New.Hope.Application;
using New.Hope.Application.Repository;
using New.Hope.Domain;

namespace New.Hope.Infra.Repository
{
    public class StudentsRepository : BaseRepository<Student>, IStudentsRepository
    {
        public StudentsRepository(IContextFactory factoryBase, INotifier notifier) : base(factoryBase, notifier)
        {
        }
    }
}