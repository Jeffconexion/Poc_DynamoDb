using System;
using Amazon.DynamoDBv2.DataModel;

namespace AppSampleDynamoDb.Model
{
  [DynamoDBTable("ClienteTable")]
  public class Cliente
  {
    [DynamoDBHashKey]
    public Guid IdCliente { get; set; }

    [DynamoDBProperty]
    public string Nome { get; set; }

    [DynamoDBProperty]
    public string CPF { get; set; }

    [DynamoDBProperty]
    public DateTime DataNascimento { get; set; }
  }
}
