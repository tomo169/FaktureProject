namespace FaktureProject.Data.Models.MEF
{
    public interface IObracun
    {
        decimal? Obracunaj(string s, decimal? x);
    }
}