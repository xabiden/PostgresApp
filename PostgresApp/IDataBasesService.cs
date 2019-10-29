using System.Data;

namespace PostgresApp
{
    interface IDataBasesService
    {
        DataTable Select(params EUSersColumnNames[] column);
    }
    enum EUSersColumnNames
    {
        domainName,
        email,
        telegramId
    }
}
