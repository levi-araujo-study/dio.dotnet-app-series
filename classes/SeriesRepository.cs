using System;

using System.Collections.Generic;
using DIO.Series.Protocols;

namespace DIO.Series
{

  public class SeriesRepository : IRepository<Serie>
  {
    private List<Serie> listSerie = new List<Serie>();
    public List<Serie> Show()
    {
      return listSerie;
    }
    public Serie GetById(int id)
    {
      return listSerie[id];
    }
    public void Insert(Serie values)
    {
      listSerie.Add(values);
    }
    public void Delete(int id)
    {
      listSerie[id].delete();
    }
    public void Update(int id, Serie values)
    {
      listSerie[id] = values;
    }
    public int NextId()
    {
      return listSerie.Count;
    }

  }
}