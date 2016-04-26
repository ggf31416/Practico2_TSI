using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Shared.Entities
{
    [DataContract,
        KnownType(typeof(FullTimeEmployee)),
        KnownType(typeof(PartTimeEmployee))]
    public abstract class Employee
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }

        public override string ToString(){
            return Name;
        }
    }
}
