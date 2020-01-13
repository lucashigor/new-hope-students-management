
using Microsoft.EntityFrameworkCore;

namespace New.Hope.Infra.Repository
{
    public interface IContextFactory
    {
        DbContext GetContext();
    }
}