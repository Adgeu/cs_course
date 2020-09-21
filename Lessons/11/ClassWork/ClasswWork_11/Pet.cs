using System;

namespace ClasswWork_11
{
    partial class Pet
    {
        public string Kind;
        public string Name;
        public char Sex;
        public DateTimeOffset Date;

        #region Constructors
        public Pet(string kind, string name, char sex, DateTimeOffset date)
        {
            Kind = kind;
            Name = name;
            Sex = sex;
            Date = date;
        }

        public Pet(string kind, string name, char sex, string date)
        {
            Kind = kind;
            Name = name;
            Sex = sex;
            Date = DateTimeOffset.Parse(date);
        }
        #endregion

        public int Age() =>
            (int)((DateTimeOffset.Now - Date).TotalDays / ((365 * 4 + 366) / 5.0));       
        
        #region Update Properties
        public void UpdateProperties(string name, DateTimeOffset date)
        {
            Name = name;
            Date = date;
        }

        public void UpdateProperties(string name, string date)
        {
            Name = name;

            try
            {
                Date = DateTimeOffset.Parse(date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateProperties(string name, char sex)
        {
            Name = name;
            Sex = sex;
        }
        #endregion

    }
}
