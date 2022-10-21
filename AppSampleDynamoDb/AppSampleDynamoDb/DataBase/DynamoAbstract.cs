using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace AppSampleDynamoDb.DataBase
{
  public abstract class DynamoAbstract<T> where T : class, new()
  {

    private readonly IDynamoDBContext context;

    protected DynamoAbstract(IDynamoDBContext context)
    {
      this.context = context;
    }

    protected async Task<List<T>> Scan()
    {
      return await context.ScanAsync<T>(new List<ScanCondition>()).GetRemainingAsync();
    }

    protected async Task<List<T>> QueryByHash(object hashKey)
    {
      return await context.QueryAsync<T>(hashKey).GetRemainingAsync();
    }

    protected async Task Save(T obj)
    {
      await context.SaveAsync<T>(obj);
    }

  }
}
