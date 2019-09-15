using Newtonsoft.Json;
using System.Text;

namespace LAP.CORE.RedisHelpers
{
    public class RedisSerialize<T> where T:class
    {
        protected virtual byte[] Serialize(object item)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item));
        }

        protected virtual T Deserialize<T>(string[] serializedObject)
        {
            if (serializedObject == null)
                return default(T);

            string jsonString = "[";
            foreach (var item in serializedObject)
                jsonString += item + ",";
            jsonString += "]";
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
