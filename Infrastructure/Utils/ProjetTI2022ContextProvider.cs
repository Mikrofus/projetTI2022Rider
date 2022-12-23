using Infrastructure.Ef;

namespace Infrastructure.Utils;

public class ProjetTI2022ContextProvider
{
    private readonly IConnectionStringProvider _connectionStringProvider;

    public ProjetTI2022ContextProvider(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    public ProjetTI2022Context NewContext()
    {
        return new ProjetTI2022Context(_connectionStringProvider);
    }
}