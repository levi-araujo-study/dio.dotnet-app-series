using System;
namespace DIO.Series
{
  public class Serie : EntityBase
  {
    private Gender Gender { get; set; }
    private string Title { get; set; }
    private string Description { get; set; }
    private int Year { get; set; }

    private bool isExcluding { get; set; }

    public Serie(int id, Gender gender, string title, string description, int year)
    {
      this.Id = id;
      this.Gender = gender;
      this.Title = title;
      this.Description = description;
      this.Year = year;
      this.isExcluding = false;
    }

    public override string ToString()
    {
      string result = "";
      result += "Gender: " + this.Gender + Environment.NewLine;
      result += "Title: " + this.Title + Environment.NewLine;
      result += "Description: " + this.Description + Environment.NewLine;
      result += "Year: " + this.Year + Environment.NewLine;
      return result;
    }
    public string returnTitle() { return this.Title; }
    public int returnID() { return this.Id; }
    public void delete() { this.isExcluding = true; }
    public bool returnExcluded() { return this.isExcluding; }
  }

}