using Microsoft.Extensions.Configuration;

namespace Coffee.Services;

public class SiteProvider : ISiteProvider
{
    private readonly IConfiguration _configuration;

    public SiteProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetSiteName()
    {
        return _configuration["Site:Name"] ?? "MySite";
    }

    public string? GetSetting(string key)
    {
        return _configuration[key];
    }
}
