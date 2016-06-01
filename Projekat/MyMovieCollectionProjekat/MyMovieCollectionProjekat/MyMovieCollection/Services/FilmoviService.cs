using MyMovieCollectionProjekat.MyMovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Popups;

namespace MyMovieCollectionProjekat.MyMovieCollection.Services
{
    class FilmoviService
    {
        private List<Film> filmovi;

        public List<Film> Filmovi
        {
            get
            {
                return filmovi;
            }

            set
            {
                filmovi = value;
            }
        }

        public async Task getFilmovi(string s)
        {
            Filmovi = new List<Film>();
            HttpClient httpClient = new HttpClient();
            string uriString = "http://www.omdbapi.com/?s=" + s + "&r = json";
            string response = await httpClient.GetStringAsync(new Uri(uriString));

            JsonObject value = JsonValue.Parse(response).GetObject();

            IJsonValue jsonValue1;
            int brojFilmova = 0;
            if (value.TryGetValue("totalResults", out jsonValue1))
            {
                brojFilmova = Int32.Parse(jsonValue1.GetString());
            }
            int brojDesetina;
            if (brojFilmova % 10 == 0) brojDesetina = brojFilmova / 10;
            else brojDesetina = brojFilmova / 10 + 1;

            JsonArray jsonFilmovi = new JsonArray();

            for (int i = 1; i <= brojDesetina; i++)
            {
                uriString = "http://www.omdbapi.com/?s=" + s + "&r = json" + "&page=" + i.ToString();
                response = await httpClient.GetStringAsync(new Uri(uriString));
                value = JsonValue.Parse(response).GetObject();
                JsonArray temp = value.GetNamedArray("Search");

                foreach (JsonValue j in temp)
                {
                    jsonFilmovi.Add(j);
                }
            }


            int a = jsonFilmovi.Count;
            var dialog1 = new MessageDialog(a.ToString());
            await dialog1.ShowAsync();

            for (uint i = 0; i < jsonFilmovi.Count; i++)
            {
                Film f = new Film();
                String str = "";
                IJsonValue jsonValue;
                if (jsonFilmovi.GetObjectAt(i).TryGetValue("imdbID", out jsonValue))
                {
                    str = jsonValue.GetString();
                }

                uriString = "http://www.omdbapi.com/?i=" + str + "&r = json";
                response = await httpClient.GetStringAsync(new Uri(uriString));
                value = JsonValue.Parse(response).GetObject();

                if (value.TryGetValue("Title", out jsonValue))
                {
                    f.Naziv = jsonValue.GetString();
                }
                if (jsonFilmovi.GetObjectAt(i).TryGetValue("Year", out jsonValue))
                {
                    a = Int32.Parse(jsonValue.GetString());
                    f.god = new DateTime(a, 1, 1);
                }
                if (value.TryGetValue("Plot", out jsonValue)) ;
                {
                    f.Opis = jsonValue.GetString();
                }
                if (value.TryGetValue("imdbRating", out jsonValue)) ;
                {
                    try
                    {
                        f.ProsjecnaOcjena = double.Parse(jsonValue.GetString());
                    }
                    catch (Exception)
                    {
                        f.ProsjecnaOcjena = 0d;
                    }
                }
                // DODATI LINK ZA SLIKU, TREBA IZMIJENITI KLASU FILM


                Filmovi.Add(f);

                dialog1 = new MessageDialog(f.Naziv + "   " + f.god.Year.ToString() + "   " + "   " + f.Opis + "     " + f.ProsjecnaOcjena.ToString());
                await dialog1.ShowAsync();
            }
        }
    }
}
