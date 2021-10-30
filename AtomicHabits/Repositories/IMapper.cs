using System.Collections.Generic;

namespace AtomicHabits.Repositories
{
  public interface IMapper<V, M>
  {
    public V ModelToViewModel(M obj);
    public List<V> ModelToViewModel(List<M> obj);
    public M ViewModelToModel(V obj);
    public List<M> ViewModelToModel(List<V> obj);
  }
}