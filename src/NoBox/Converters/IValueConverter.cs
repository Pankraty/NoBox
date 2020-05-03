namespace Pankraty.NoBox.Converters
{
    internal interface IValueConverter<Tin, T>
    {
        T GetValue(Tin value);
    }
}