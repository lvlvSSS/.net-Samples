using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientCallWebApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person() { age = 11, name = "nelson" };
            List<Person> liPerosns = new List<Person>();
            liPerosns.Add(new Person() { age = 11, name = "nelson" });
            liPerosns.Add(new Person() { age = 11, name = "nelson" });
            liPerosns.Add(new Person() { age = 11, name = "nelson" });

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(@"http://localhost:2320/");

                //序列化为json字符串。
                //var stringContent = JsonConvert.SerializeObject(liPerosns);
                //HttpContent content = new FormUrlEncodedContent(stringContent);
                //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                //发送键值对数据。
                var temp = new List<KeyValuePair<string, string>>();
                temp.Add(new KeyValuePair<string, string>("", "Here is the test"));
                HttpContent content = new FormUrlEncodedContent(temp);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

                //发送，获取结果。
                var res = client.PostAsync("specialAPI/values/postwithoutparams", content).Result;
                Console.WriteLine(res.Content.ReadAsStringAsync().Result);
                Console.ReadKey();
            }
        }

        public class Person
        {
            public int age;
            public string name;
        }
    }
}
