namespace Coffee.Services;

public interface ISiteProvider
{
    string GetSiteName();
    string? GetSetting(string key);
}
