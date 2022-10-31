using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSampleDynamoDb.DataBase
{
    public abstract class DynamoAbstract<T> where T : class, new()
    {
        // ~~> se o appsettings funcionar.
        //private readonly IDynamoDBContext context;

        //protected DynamoAbstract(IDynamoDBContext context)
        //{
        //  this.context = context;
        //}

        private readonly IDynamoDBContext context;
        private Amazon.DynamoDBv2.AmazonDynamoDBClient client { get; set; }

        protected DynamoAbstract()
        {
            client = new Amazon.DynamoDBv2.AmazonDynamoDBClient(awsAccessKeyId: "",
                                                                awsSecretAccessKey: "",
                                                                Amazon.RegionEndpoint.USEast2);
            context = new DynamoDBContext(client);
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
