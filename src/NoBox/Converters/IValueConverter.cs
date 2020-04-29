namespace Pankraty.NoBox.Converters
{
    internal interface IValueConverter<in Tin, out T> where Tin: struct
    {
        T GetValue(Tin value);
    }
}