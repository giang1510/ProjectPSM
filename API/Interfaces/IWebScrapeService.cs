using System;

namespace API.Interfaces;

public interface IWebScrapeService
{
    Task<string> GetHtmlStringAsync(string url);
}
