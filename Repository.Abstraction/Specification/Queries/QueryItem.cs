using System.Text.Json.Serialization;

namespace Repository.Abstraction.Specification.Queries;
/// <summary>
/// 查詢規格
/// </summary>
public class QueryItem
{
    /// <summary>
    /// 查詢欄位
    /// </summary>
    public string FieldName { get; set; }
    /// <summary>
    /// 查詢的值
    /// </summary>
    [JsonPropertyName("value")]
    public string ValueString { get; set; }
    public ValueType ValueType { get; set; }
    /// <summary>
    /// 查詢模式
    /// </summary>
    public QueryMode QueryMode { get; set; }

    public object GetValue()
    {
        switch (ValueType)
        {
            case ValueType.String:
                return ValueString;
                break;
            case ValueType.Boolean:
                return bool.Parse(ValueString);
            case ValueType.Decimal:
                return decimal.Parse(ValueString);
            case ValueType.Int32:
                return int.Parse(ValueString);
            case ValueType.Int64:
                return long.Parse(ValueString);
            case ValueType.Int16:
                return short.Parse(ValueString);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}