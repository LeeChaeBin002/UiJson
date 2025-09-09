﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

public class ColorConverter : JsonConverter<Color>
{
    public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue,
                                   bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jObj = JObject.Load(reader);
        return new Color(
            (float)jObj["R"],
            (float)jObj["G"],
            (float)jObj["B"],
            (float)jObj["A"]
        );
    }

    public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("R"); writer.WriteValue(value.r);
        writer.WritePropertyName("G"); writer.WriteValue(value.g);
        writer.WritePropertyName("B"); writer.WriteValue(value.b);
        writer.WritePropertyName("A"); writer.WriteValue(value.a);
        writer.WriteEndObject();
    }
}
