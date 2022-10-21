using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using AppSampleDynamoDb.Model;

namespace AppSampleDynamoDb.DataBase
{
  public class ClienteRepository : DynamoAbstract<Cliente>
  {
    public ClienteRepository(IDynamoDBContext context) : base(context)
    {

    }

    public async Task<List<Cliente>> GetAll() => await Scan();
    public async Task<List<Cliente>> GetById(Guid id) => await this.QueryByHash(id);
    public new async Task Save(Cliente obj) => await this.Save(obj);
  }
}
