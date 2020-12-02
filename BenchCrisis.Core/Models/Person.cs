using BenchCrisis.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchCrisis.Core.Models
{
#nullable enable
    public class Person
    {
        public int Id { get; private set; }

        private readonly PersonName _name;
        public virtual PersonName Name => _name;

        private readonly string _email;
        public virtual Email Email => (Email)_email;

        protected Person() { }

        public Person(Email email, PersonName name): this()
        {
            _email = email ?? throw new ArgumentNullException(nameof(email));
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
