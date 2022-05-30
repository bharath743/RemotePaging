using Newtonsoft.Json;

namespace RemotePaging.Models
{
    public class DataInfo
    {
        [JsonProperty("@odata.context")]
        public string? OdataContext { get; set; }

        [JsonProperty("@odata.count")]
        public int OdataCount { get; set; }
        public List<Info3>? value { get; set; }
    }

    public class Info3
    {
        public int Id { get; set; }
        public string? IndicatorCode { get; set; }
        public string? SpatialDimType { get; set; }
        public string? SpatialDim { get; set; }
        public string? TimeDimType { get; set; }
        public int? TimeDim { get; set; }
        public string? Dim1Type { get; set; }
        public string? Dim1 { get; set; }
        public object? Dim2Type { get; set; }
        public object? Dim2 { get; set; }
        public object? Dim3Type { get; set; }
        public object? Dim3 { get; set; }
        public object? DataSourceDimType { get; set; }
        public object? DataSourceDim { get; set; }
        public string? Value { get; set; }
        public double? NumericValue { get; set; }
        public object? Low { get; set; }
        public object? High { get; set; }
        public object? Comments { get; set; }
        public DateTime Date { get; set; }
        public string? TimeDimensionValue { get; set; }
        public DateTime TimeDimensionBegin { get; set; }
        public DateTime TimeDimensionEnd { get; set; }
    }
}
