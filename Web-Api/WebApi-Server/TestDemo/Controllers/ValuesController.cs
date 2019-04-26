using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }


        // POST api/values
        [HttpPost]
        [Route("specialAPI/values/postwithoutparams")]
        public string Post([FromBody]string value /*[FromBody]Person person*/)//在一个api的参数中，FromBody只能出现一次！切记！！！
        {
            /*
             * Request.Content.ReadAsStreamAsync().Result.Seek(0, System.IO.SeekOrigin.Begin);
             * 解释如下：
             * 当你的Action参数存在[FromBody]等读取内容的方法时，会被[FromBody]“吃掉”。
             * 说得有些生动，其实原因是读取完毕后，指向内容的指针会指向最后的结束符，再次读取的时候就读不到了，
             * 因此解决方法有两种：
               1、不需要[FromBody]，直接在代码里用上述代码读取原始内容。
               2、保留[FromBody]，重新调整内容指针，再进行读取。
             */
            //var person1 = Request.Content.ReadAsAsync<Person>().Result;
            Request.Content.ReadAsStreamAsync().Result.Seek(0, System.IO.SeekOrigin.Begin);
            var re = Request.Content.ReadAsStringAsync().Result;
            return re ?? "none";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class Person
    {
        public int age;
        public string name;
    }
}
