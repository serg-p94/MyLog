namespace MyLog.Core.Csv
{
    public interface ICsvParser
    {
        TModel ParseComplex<TModel>(string complexData);
    }
}
