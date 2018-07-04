using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace MyLog.Core.Csv.Converters
{
    public abstract class TypeConverter<T> : ITypeConverter
    {
        public virtual string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData) =>
            value.ToString();

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) =>
            CreateFromString(text, row, memberMapData);

        protected abstract T CreateFromString(string text, IReaderRow row, MemberMapData memberMapData);
    }
}
