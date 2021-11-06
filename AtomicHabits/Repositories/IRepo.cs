using System.Collections.Generic;

namespace AtomicHabits.Repositories
{
  public interface IRepo<T, Y>
  {
    public T Get(Y obj);
    public IEnumerable<T> Get();
    public T Add(T obj);
    public T Update(T obj);
    public void Delete(Y obj);
  }
}