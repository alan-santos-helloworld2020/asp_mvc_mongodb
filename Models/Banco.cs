using System;
using System.Collections.Generic;
using MongoDB.Driver;
using sistema.Models;
using System.Linq;

namespace sistema.Models
{
    public class Banco
    {


        MongoClient client = new MongoClient("mongodb://127.0.0.1:27017/");
        public string salvar(Clientes cl)
        {

            var db = client.GetDatabase("onload");
            var table = db.GetCollection<Clientes>("clientes");
            cl.id = Guid.NewGuid().ToString();
            table.InsertOne(cl);
            return "Salvo com Sucesso";

        }
        public List<Clientes> listar()
        {

            var db = client.GetDatabase("onload");
            var table = db.GetCollection<Clientes>("clientes");
            var clientes = table.Find(FilterDefinition<Clientes>.Empty).ToList();
            return clientes;

        }

        public Clientes listarId(string id)
        {

            var db = client.GetDatabase("onload");
            var table = db.GetCollection<Clientes>("clientes");
            var cliente = table.Find<Clientes>(c => c.id == id).FirstOrDefault();
            return cliente;

        }
        public void deletar(string id)
        {
            var db = client.GetDatabase("onload");
            var table = db.GetCollection<Clientes>("clientes");
            var clientes = table.DeleteOne(c => c.id == id);
        }


         public void alterar(string id, Clientes cl)
         {
            var db = client.GetDatabase("onload");
            var table = db.GetCollection<Clientes>("clientes");
            var clientes = table.ReplaceOne(c => c.id == id,cl);

         }
           

    }


}