namespace CrossCloudAPI;

public class URLFormatter
{
    public string Format(string url)
    {
        return string.Format("https://{0}.com/", url);
    }
}