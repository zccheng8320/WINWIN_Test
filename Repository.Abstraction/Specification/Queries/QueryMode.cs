namespace Repository.Abstraction.Specification.Queries;

public enum QueryMode
{

    /// <summary>
    /// 精準查詢
    /// </summary>
    Equal = 0,
    /// <summary>
    /// 模糊查詢
    /// </summary>
    Contain = 1,
    /// <summary>
    /// 開始
    /// </summary>
    StartWith = 2,
    /// <summary>
    /// 結束
    /// </summary>
    EndWith = 3,

}