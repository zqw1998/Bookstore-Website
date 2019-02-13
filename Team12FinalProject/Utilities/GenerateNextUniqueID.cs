using Team12FinalProject.DAL;
using System;
using System.Linq;


namespace Team12FinalProject.Utilities
{
    public static class GenerateNextUniqueID
    {
        public static Int32 GetNextUniqueID(AppDbContext db)
        {
            Int32 intMaxUniqueID; //the current maximum course number
            Int32 intNextUniqueID; //the course number for the next class

            if (db.Books.Count() == 0) //there are no registrations in the database yet
            {
                intMaxUniqueID = 789300; //registration numbers start at 101
            }
            else
            {
                intMaxUniqueID = db.Books.Max(c => c.UniqueID); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextUniqueID = intMaxUniqueID + 1;

            //return the value
            return intNextUniqueID;
        }

    }
}
