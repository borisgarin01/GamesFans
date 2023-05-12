using Cinema.Course.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Course.Services
{
    public class JsonGamesService : IGamesService
    {
        private HttpContext Context { get; set; }
        string jsonFilePath = "Files/Games.json";
        string pathToJson;
        public JsonGamesService(HttpContext context)
        {
            Context = context;
            pathToJson = Context.Server.MapPath(jsonFilePath);
        }

        public GameListModel[] GetAllGames()
        {
            var fullModel = GetDataFromFile();
            return fullModel.Games;
        }

        public GameListModel GetGameById(int id)
        {
            var fullModel = GetDataFromFile();
            var ids = fullModel.Games.Select(x => x.Name);
            return fullModel.Games.FirstOrDefault(game => game.Id == id);
        }

        public bool UpdateMovie(GameListModel updateGame)
        {
            var fullModel=GetDataFromFile();
            var movieToUpdate = fullModel.Games.First(movie => movie.Id == updateGame.Id);
            if(movieToUpdate == null)
            {
                return false;
            }

            movieToUpdate.Name= updateGame.Name;
            movieToUpdate.Description = updateGame.Description;
            movieToUpdate.Genres = updateGame.Genres;
            movieToUpdate.ImageUrl = updateGame.ImageUrl;
            movieToUpdate.MinAge = updateGame.MinAge;
            movieToUpdate.Name = updateGame.Name;
            movieToUpdate.CriticsRating = updateGame.CriticsRating;
            movieToUpdate.GamersRating = updateGame.GamersRating;
            movieToUpdate.Platforms = updateGame.Platforms;
            SaveDataToFile(fullModel);
            return true;
        }

        private void SaveDataToFile(JsonGamesModel fullModel)
        {
            var serializedModel = JsonConvert.SerializeObject(fullModel);
            System.IO.File.WriteAllText(serializedModel, serializedModel);
        }

        private JsonGamesModel GetDataFromFile()
        {
            if (!System.IO.File.Exists(pathToJson))
                return null;
            var jsonModel = System.IO.File.ReadAllText(pathToJson);
            var deserializedModel = JsonConvert.DeserializeObject<JsonGamesModel>(jsonModel);
            return deserializedModel;
        }
    }
}