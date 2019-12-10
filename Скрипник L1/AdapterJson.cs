using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab1
{
    public class AdapterJson: IAdapterJson
    {
        public string ConvertToJson(List<User> userList)
        {
            return JsonConvert.SerializeObject(userList);
        }

        public List<User> ConvertFromJson(string strJson)
        {
            return JsonConvert.DeserializeObject<List<User>>(strJson);
        }


    }
}
