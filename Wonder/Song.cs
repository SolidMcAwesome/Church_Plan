using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonder
{
    internal class Song
    {
        private string libraryPath;
        private XLWorkbook libraryWorkbook;
        public Dictionary<string, List<string>> SongLibrary;
        public Dictionary<string, List<string>> Playlists;

        public Song()
        {
            libraryPath = AppDomain.CurrentDomain.BaseDirectory + "Music Library";

            libraryWorkbook = new XLWorkbook(libraryPath + "\\Library.xlsx");

            SongLibrary = new Dictionary<string, List<string>>();
            Playlists = new Dictionary<string, List<string>>();

            SetUpLibrary();
            SetUpPlaylists();
        }

        private void SetUpLibrary()
        {
            foreach (var songfile in libraryWorkbook.Worksheets)
            {
                if (songfile.ToString() != "Template" && songfile.ToString() != "Playlists")
                {
                    Console.WriteLine(songfile);
                    string songTitle = "";

                    List<string> songLyrics = new List<string>();
                    foreach (var column in songfile.ColumnsUsed())
                    {
                        if (column.ColumnLetter() == "A")
                        {
                            foreach (var row in column.CellsUsed())
                            {
                                if (row.Address.RowNumber == 2)
                                { songTitle = row.Value.ToString(); }
                            }
                        }
                        if (column.ColumnLetter() == "E" || column.ColumnLetter() == "F" || column.ColumnLetter() == "G")
                        {
                            foreach (var row in column.CellsUsed())
                            {
                                if (row.Address.RowNumber != 1)
                                { songLyrics.Add(row.Value.ToString()); }
                            }
                        }
                    }

                    SongLibrary[songTitle] = songLyrics;
                }
            }
        }

        private void SetUpPlaylists()
        {
            IXLWorksheet playlistCatelog = libraryWorkbook.Worksheet("Playlists");
            string title = "";
            List<string> songs;
            foreach (var playlist in playlistCatelog.RowsUsed())
            {

                if(playlist.RowNumber() != 1)
                {
                    songs = new List<string>();
                    foreach(var song in  playlist.CellsUsed())
                    {
                        if(song.Address.ColumnLetter == "A")
                        {
                            title = song.Value.ToString();
                        }
                        else
                        {
                            songs.Add(song.Value.ToString());   
                        }
                    }
                    Playlists[title] = songs;
                }
            }
        }
    }
}
