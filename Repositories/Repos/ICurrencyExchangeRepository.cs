namespace AHWForm.Repos
{
    public interface ICurrencyExchangeRepository
    {
        decimal? GetValueInAnotherCurrency(decimal value, string currency, string currency2);
    }
}