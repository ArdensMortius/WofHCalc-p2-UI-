// <auto-generated />
//
// To parse this JSON data, add NuGet 'System.Text.Json' then do:
//
//    using WofHCalc_p2_UI_.Models.templates;
//
//    var build = Build.FromJson(jsonString);
#nullable enable
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8603

namespace WofHCalc_p2_UI_.Models.templates
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Globalization;
    using WofHCalc_p2_UI_.Models;

    public class Build
    {
        [JsonPropertyName("buildtime")]
        public double[] Buildtime { get; set; }

        [JsonPropertyName("cost")]
        public Cost[] Cost { get; set; }

        [JsonPropertyName("effect")]
        public double[] Effect { get; set; }

        [JsonPropertyName("efficiency")]
        public double Efficiency { get; set; }

        [JsonPropertyName("group")] //для определения конкурирующих строений
        public int Group { get; set; }

        [JsonPropertyName("maxcount")]
        public int Maxcount { get; set; }

        [JsonPropertyName("next")]
        public int[] Next { get; set; }

        [JsonPropertyName("pay")]
        public double[] Pay { get; set; }

        [JsonPropertyName("race")]
        public Race Race { get; set; }

        [JsonPropertyName("slot")]
        public Slot Slot { get; set; }

        [JsonPropertyName("terrain")]
        public Terrain Terrain { get; set; } //положение города

        //[JsonPropertyName("type")] //для фильтров. Пока пофиг
        //public int Type { get; set; }

        [JsonPropertyName("ungrown")]
        public double[] Ungrown { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("unitstrain")]
        public int[] Unitstrain { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("productres")]
        public Productre[] Productres { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //[JsonPropertyName("wonderradius")]
        //public int? Wonderradius { get; set; }
        public static Build[] FromJson(string json) => JsonSerializer.Deserialize<Build[]>(json, WofHCalc_p2_UI_.Models.templates.Converter.Settings);
    }

    public partial class Productre
    {
        [JsonPropertyName("res")]
        public int Res { get; set; }
    }

    public partial struct Cost
    {
        public double? Double;
        public double[] DoubleArray;

        public static implicit operator Cost(double Double) => new Cost { Double = Double };
        public static implicit operator Cost(double[] DoubleArray) => new Cost { DoubleArray = DoubleArray };
    }
    public static class Serialize
    {
        public static string ToJson(this Build[] self) => JsonSerializer.Serialize(self, WofHCalc_p2_UI_.Models.templates.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
        {
            Converters =
            {
                CostConverter.Singleton,
                new DateOnlyConverter(),
                new TimeOnlyConverter(),
                IsoDateTimeOffsetConverter.Singleton
            },
        };
    }

    internal class CostConverter : JsonConverter<Cost>
    {
        public override bool CanConvert(Type t) => t == typeof(Cost);

        public override Cost Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Number:
                    var doubleValue = reader.GetDouble();
                    return new Cost { Double = doubleValue };
                case JsonTokenType.StartArray:
                    var arrayValue = JsonSerializer.Deserialize<double[]>(ref reader, options);
                    return new Cost { DoubleArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Cost");
        }

        public override void Write(Utf8JsonWriter writer, Cost value, JsonSerializerOptions options)
        {
            if (value.Double != null)
            {
                JsonSerializer.Serialize(writer, value.Double.Value, options);
                return;
            }
            if (value.DoubleArray != null)
            {
                JsonSerializer.Serialize(writer, value.DoubleArray, options);
                return;
            }
            throw new Exception("Cannot marshal type Cost");
        }

        public static readonly CostConverter Singleton = new CostConverter();
    }

    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string serializationFormat;
        public DateOnlyConverter() : this(null) { }

        public DateOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
        }

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private readonly string serializationFormat;

        public TimeOnlyConverter() : this(null) { }

        public TimeOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
        }

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    internal class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override bool CanConvert(Type t) => t == typeof(DateTimeOffset);

        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
        private string? _dateTimeFormat;
        private CultureInfo? _culture;

        public DateTimeStyles DateTimeStyles
        {
            get => _dateTimeStyles;
            set => _dateTimeStyles = value;
        }

        public string? DateTimeFormat
        {
            get => _dateTimeFormat ?? string.Empty;
            set => _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
        }

        public CultureInfo Culture
        {
            get => _culture ?? CultureInfo.CurrentCulture;
            set => _culture = value;
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            string text;


            if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
            {
                value = value.ToUniversalTime();
            }

            text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

            writer.WriteStringValue(text);
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? dateText = reader.GetString();

            if (string.IsNullOrEmpty(dateText) == false)
            {
                if (!string.IsNullOrEmpty(_dateTimeFormat))
                {
                    return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                }
                else
                {
                    return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
                }
            }
            else
            {
                return default(DateTimeOffset);
            }
        }


        public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
    }
}
#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8603
