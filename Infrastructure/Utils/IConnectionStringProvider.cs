namespace Infrastructure.Utils;

public interface IConnnectionStringProvider
{
    string Get(string key);
}