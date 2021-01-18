using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoslerQuickCode
{
    class Books
    {
        public enum Genre
        {
            HistoricalFiction,
            Fantasy,
            Biographical,
            Classical,
            Politics,
            Religious,
            Horror,
            ScienceFiction,
            Romance,
            Nonfiction,
            Historical
        }

        #region FIELDS

        private string _title;
        private string _author;
        private int _pages;
        private int _releaseYear;
        private Genre _genreType;

        #endregion

        #region PROPERTIES

        public Genre GenreType
        {
            get { return _genreType; }
            set { _genreType = value; }
        }
        public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }
        public int Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion
    }
}
