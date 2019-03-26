using CsvHelper;
using CsvHelper.Configuration;
using MyLog.Core.Models.Navigation;

namespace MyLog.Core.Csv.Converters
{
    public class CoordinatesConverter : TypeConverter<Coordinates>
    {
        protected override Coordinates CreateFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return Coordinates.Parse(text);
        }
    }
}
