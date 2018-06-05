using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ZeroFormatter;

namespace PqSave
{
    public static class Json
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new List<JsonConverter>
            {
                new LazyDictionaryConverter1(),
                new LazyDictionaryConverter2(),
                new LazyDictionaryConverter3(),
                new LazyDictionaryConverter4()
            }
        };

        public static string Serialize(SaveManager save)
        {
            return JsonConvert.SerializeObject(save, Formatting.Indented, Settings);
        }

        public static SaveManager DeSerialize(string save)
        {
            return JsonConvert.DeserializeObject<SaveManager>(save, Settings);
        }
    }

    public class LazyDictionaryConverter1 : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dict = ((ILazyDictionary<int, CharacterStorage.ManageData>)value).ToDictionary(x => x.Key, x => x.Value);
            serializer.Serialize(writer, dict);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<Dictionary<int, CharacterStorage.ManageData>>(reader).AsLazyDictionary();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ILazyDictionary<int, CharacterStorage.ManageData>);
        }
    }

    public class LazyDictionaryConverter2 : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dict = ((ILazyDictionary<int, DungeonHighScore>)value).ToDictionary(x => x.Key, x => x.Value);
            serializer.Serialize(writer, dict);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<Dictionary<int, DungeonHighScore>>(reader).AsLazyDictionary();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ILazyDictionary<int, DungeonHighScore>);
        }
    }

    public class LazyDictionaryConverter3 : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dict = ((ILazyDictionary<int, SaveCharacterData>)value).ToDictionary(x => x.Key, x => x.Value);
            serializer.Serialize(writer, dict);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<Dictionary<int, SaveCharacterData>>(reader).AsLazyDictionary();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ILazyDictionary<int, SaveCharacterData>);
        }
    }

    public class LazyDictionaryConverter4 : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dict = ((ILazyDictionary<int, StoneData>)value).ToDictionary(x => x.Key, x => x.Value);
            serializer.Serialize(writer, dict);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<Dictionary<int, StoneData>>(reader).AsLazyDictionary();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ILazyDictionary<int, StoneData>);
        }
    }
}
