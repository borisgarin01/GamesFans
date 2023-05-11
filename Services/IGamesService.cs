using Cinema.Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Course.Services
{
    public interface IGamesService
    {
        Game GetGameById(int id);
        Game[] GetAllGames();
        bool UpdateMovie(Game updateGame);
    }
}