using System.Collections.Generic;

namespace sistema.Models
{
    public class Clientes{

        public string id { get; set; }
        public string data  { get; set; }
        public string nome  { get; set; }
        public string telefone  { get; set; }
        public string email  { get; set; }
        public string cep  { get; set; }
        public virtual List<Clientes> clientes { get; set; }


    }
    
}

