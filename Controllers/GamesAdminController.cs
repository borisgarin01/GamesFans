using Cinema.Course.Models;
using Cinema.Course.Services;
using Newtonsoft.Json;
using System.IO;
using System.Web.Mvc;

namespace Cinema.Course.Controllers
{
    public class GamesAdminController : Controller
    {
        private readonly IGamesService _gamesService;
        string jsonFilePath = "Files\\Games.json";
        public GamesAdminController()
        {
            _gamesService = new JsonGamesService(System.Web.HttpContext.Current);
        }

        public ActionResult GetGamesList()
        {
            var games = _gamesService.GetAllGames();
            return View("~/Views/GamesAdmin/GamesList.cshtml", games);
        }
        public ActionResult SaveGames()
        {
            string pathToJson = HttpContext.Server.MapPath(jsonFilePath);

            var games = new GameListModel[]
            {
                new GameListModel
                {
                    Id=1,
                    Name="The Last Of Us",
                    Description="Компьютерная игра в жанре action-adventure с элементами survival horror и стелс-экшена, разработанная студией Naughty Dog и изданная Sony Computer Entertainment. Игра была выпущена в 2013 году эксклюзивно для консоли PlayStation 3. В 2014 году была выпущена обновлённая версия игры для PlayStation 4 - The Last of Us Remastered. Ремейк оригинальной игры, получивший название The Last of Us Part I, вышел 2 сентября 2022 года для PlayStation 5, а 28 марта 2023 года - для Windows.",
                    Genres=new[]{Genre.ActionAdventure, Genre.SurvivalHorror, Genre.ThirdPerson},
                    Platforms = new[] {Platform.PS3, Platform.PS4, Platform.PS5, Platform.PC, Platform.SteamDeck},
                    MinAge=18,
                    ReleaseDate=new System.DateTime(2013,6,14),
                    CriticsRating=9.4f,
                    GamersRating=9.1f,
                    ImageUrl="https://avatars.mds.yandex.net/i?id=d056e7a92d90bf395536330471fc44b979205a1b-8492261-images-thumbs&n=13"
                },
                new GameListModel
                {
                    Id=2,
                    Name="God of War",
                    Description="Игра God of War для PS4 — это перезапуск легендарной брутальной франшизы от Sony Santa Monica, который расскажет совершенно новую эмоциональную историю о путешествии Кратоса и даст игрокам переосмысленный геймплей с видом от третьего лица. Вы станете свидетелями убедительной драмы, которая разворачивается, когда бессмертные полубоги принимают решения о своей перемене.\r\n\r\nКратос решил измениться раз и навсегда, разорвать порочный круг бессмысленного насилия, который увековечил его падшую семью Олимпа. Теперь все былое в прошлом — злополучный контракт с Аресом, убийство его семьи и безумная ярость спровоцированная местью, которая в конечном итоге закончилась эпическим разрушением Олимпа. Теперь у Кратоса есть маленький сын за которого он несет ответственно и он обязан усмирить того монстра, который в нем живет и вырывается благодаря его ярости…",
                    Genres=new[]{Genre.ActionAdventure, Genre.ThirdPerson },
                    Platforms = new[] { Platform.PS4, Platform.PS5, Platform.PC, Platform.SteamDeck},
                    MinAge=18,
                    ReleaseDate=new System.DateTime(2022,11,9),
                    CriticsRating=9.3f,
                    GamersRating=9.0f,
                    ImageUrl="https://avatars.mds.yandex.net/i?id=10b84cbbf53a3171ad91719c8bc5fcf5cf7269d8-9104160-images-thumbs&n=13"
                },
            };

            var jsonModel = new Models.JsonGamesModel
            {
                Games = games
            };

            string json = JsonConvert.SerializeObject(jsonModel);
            System.IO.File.WriteAllText(pathToJson, json);
            return Content(json);
        }
        
        public ActionResult GetAllGames()
        {
            string pathToJson = HttpContext.Server.MapPath(jsonFilePath);

            if (System.IO.File.Exists(pathToJson))
            {
                var jsonModel = System.IO.File.ReadAllText(pathToJson);
                var deserializedModel = JsonConvert.DeserializeObject<JsonGamesModel>(jsonModel);
                return Content(jsonModel, "application/json");
            }
            return Content("File don't exist", "application/json");
        }
    }
}