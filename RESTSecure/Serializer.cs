using Newtonsoft.Json;

namespace RESTSecure
{
    class Serializer<T>
    {
        public Serializer() { }

        public string Serialize(T obj)
        {
            string serializedString = JsonConvert.SerializeObject(obj);
            return serializedString;
        }


        public T Deserialize(string serializedData)
        {
            T deserializedObj = JsonConvert.DeserializeObject<T>(serializedData);
            return deserializedObj;
        }
    }
}
