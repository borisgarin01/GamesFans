using Cinema.Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Course.Services
{
    public interface IGamesService
    {
        GameListModel GetGameById(int id);
        GameListModel[] GetAllGames();
        bool UpdateMovie(GameListModel updateGame);
    }
}