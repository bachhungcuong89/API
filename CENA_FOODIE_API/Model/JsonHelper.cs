using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CENA_FOODIE_API.Model
{
    public class JsonHelper
    {
        public static JToken DeserializeWithLowerCasePropertyNames(string json)
        {
            using (TextReader textReader = new StringReader(json))
            using (JsonReader jsonReader = new LowerCasePropertyNameJsonReader(textReader))
            {
                JsonSerializer ser = new JsonSerializer();
                return ser.Deserialize<JToken>(jsonReader);
            }
        }
        public static JToken ToJson(dynamic obj)
        {
            var x = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            return JsonHelper.DeserializeWithLowerCasePropertyNames(x);
        }
    }
    public class LowerCasePropertyNameJsonReader : JsonTextReader
    {
        public LowerCasePropertyNameJsonReader(TextReader textReader) : base(textReader) { }

        public override object Value
        {
            get
            {
                if (TokenType == JsonToken.PropertyName)
                    return ((string)base.Value).ToLower();
                return base.Value;
            }
        }
    }
}
