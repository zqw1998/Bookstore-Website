using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team12FinalProject.DAL;
using Team12FinalProject.Models;

namespace Team12FinalProject.Seeding
{
    public class SeedGenres
    {
        public static void SeedAllGenres(AppDbContext db)
        {
            if (db.Genres.Count() == 13)
            {
                throw new NotSupportedException("The database already contains all 13 genres!");
            }

            Int32 intGenresAdded = 0;
            String GenreName = "Begin"; //helps to keep track of error on repos
            List<Genre> Genres = new List<Genre>();

            try
            {
                Genre g1 = new Genre();
                g1.GenreType = "Adventure";
                Genres.Add(g1);

                Genre g2 = new Genre();
                g2.GenreType = "Contemporary Fiction";
                Genres.Add(g2);

                Genre g3 = new Genre();
                g3.GenreType = "Fantasy";
                Genres.Add(g3);


                Genre g4 = new Genre();
                g4.GenreType = "Historical Fiction";
                Genres.Add(g4);

                Genre g5 = new Genre();
                g5.GenreType = "Horror";
                Genres.Add(g5);


                Genre g6 = new Genre();
                g6.GenreType = "Humor";
                Genres.Add(g6);

                Genre g7 = new Genre();
                g7.GenreType = "Poetry";
                Genres.Add(g7);

                Genre g8 = new Genre();
                g8.GenreType = "Romance";
                Genres.Add(g8);

                Genre g9 = new Genre();
                g9.GenreType = "Science Fiction";
                Genres.Add(g9);

                Genre g10 = new Genre();
                g10.GenreType = "Shakespeare";
                Genres.Add(g10);

                Genre g11 = new Genre();
                g11.GenreType = "Suspense";
                Genres.Add(g11);

                Genre g12 = new Genre();
                g12.GenreType = "Thriller";
                Genres.Add(g12);

                Genre g13 = new Genre();
                g13.GenreType = "Mystery";
                Genres.Add(g13);



                //loop through repos
                foreach (Genre ge in Genres)
                {
                    //set name of repo to help debug
                    GenreName = ge.GenreType;

                    //see if repo exists in database
                    Genre dbGenre = db.Genres.FirstOrDefault(g => g.GenreType == ge.GenreType);

                    if (dbGenre == null) //repository does not exist in database
                    {
                        db.Genres.Add(ge);
                        db.SaveChanges();
                        intGenresAdded += 1;
                    }
                    else
                    {
                        dbGenre.GenreType = ge.GenreType;
                        db.Update(dbGenre);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
                String msg = "Books added:" + intGenresAdded + "; Error on " + GenreName;
                throw new InvalidOperationException(msg);
            }
        }
    }
}


