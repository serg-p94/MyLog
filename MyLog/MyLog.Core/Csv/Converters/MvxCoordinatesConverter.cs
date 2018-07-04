using CsvHelper;
using CsvHelper.Configuration;
using MvvmCross.Plugins.Location;
using MyLog.Core.Helpers;

namespace MyLog.Core.Csv.Converters
{
    public class MvxCoordinatesConverter : TypeConverter<MvxCoordinates>
    {
        protected override MvxCoordinates CreateFromString(string text, IReaderRow row, MemberMapData memberMapData) =>
            MvxCoordinatesHelper.Parse(text);
    }
}
