using System.Collections.Generic;

namespace DIO.Series.Protocols
{
  public interface IRepository<T>
  {
    List<T> Show();
    T GetById(int id);
    void Insert(T entity);
    void Delete(int id);
    void Update(int id, T entity);
    int NextId();
  }
}