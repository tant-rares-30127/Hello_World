using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace HelloWorldWeb.Models
{
    public class Member
    {
        public Member(string name, int id)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}

