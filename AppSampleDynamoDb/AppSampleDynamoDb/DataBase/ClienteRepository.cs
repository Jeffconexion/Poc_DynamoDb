using AppSampleDynamoDb.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSampleDynamoDb.DataBase
{
    public class ClienteRepository : DynamoAbstract<Cliente>
    {
        public ClienteRepository() : base()
        {

        }

        //Se o appsettings funcionar.
        //public ClienteRepository(IDynamoDBContext context) : base(context)
        //{

        //}

        public async Task<List<Cliente>> GetAll() => await Scan();
        public async Task<List<Cliente>> GetById(Guid id) => await this.QueryByHash(id);
        public new async Task Save(Cliente obj) => await this.Save(obj);
    }
}
