using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AppSampleDynamoDb.Model
{
    [DynamoDBTable("ClienteTable")]
    public class Cliente
    {
        [DynamoDBHashKey]
        public Guid IdCliente { get; set; }

        [DynamoDBRangeKey]
        public string Range { get; set; } = "BR";

        [DynamoDBProperty]
        public string Nome { get; set; }

        [DynamoDBProperty]
        public string CPF { get; set; }

        [DynamoDBProperty]
        public DateTime DataNascimento { get; set; }

        [DynamoDBProperty(AttributeName = "Telefones", Converter = typeof(TelefoneConverter))]
        public List<Telefone> Telefones { get; set; }
    }

    public class Telefone
    {
        public string DDD { get; set; }
        public string Numero { get; set; }
    }

    public class TelefoneConverter : IPropertyConverter
    {
        public object FromEntry(DynamoDBEntry entry)
        {
            return JsonConvert.DeserializeObject<List<Telefone>>(entry.AsString());
        }

        public DynamoDBEntry ToEntry(object value)
        {
            return new Primitive
            {
                Value = JsonConvert.SerializeObject(value)
            };
        }
    }

}
