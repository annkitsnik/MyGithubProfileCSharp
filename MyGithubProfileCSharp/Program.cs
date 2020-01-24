using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyGithubProfileCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string userCategoryUrl = "https://api.github.com/users/annkitsnik?client_id=1e0d3e5f2b887ccf6dc1&client_secret=/73f96c08dec58e662fb1f7e943fdd7746f07bfba";

            HttpWebRequest request = (HttpWebRequest)FtpWebRequest.Create(userCategoryUrl);
            request.Method = "GET";

            request.UserAgent = "Foo"; //tuvastab kasutaja masinat
            request.Accept = "*/*"; //avab pordi

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                UserData userData = JsonConvert.DeserializeObject<UserData>(response);
                Console.WriteLine($"Login: {userData.login}");
                Console.WriteLine($"Public repos: {userData.public_repos}");
                Console.WriteLine($"Followers: {userData.followers}");
                Console.WriteLine($"URL: {userData.repos_url}");


            }

        }
    }
}
