using BenchCrisis.Core.Models.Generics;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchCrisis.Core.Models.ValueObjects
{
#nullable enable
    public class PersonName : ValueObject
    {
        public string? FirstName { get; }
        public string? LastName { get; }

        private PersonName(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static Result<PersonName> Create(string? firstName = null, string? lastName = null)
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                return Result.Fail("Firstname and Lastname cannot be null");
            if (firstName?.Length > 30)
                return Result.Fail("Firstname should not exceeds 30 characters");
            if (lastName?.Length > 30)
                return Result.Fail("Firstname should not exceeds 30 characters");

            return Result.Ok(new PersonName(firstName, lastName));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            if (FirstName != null)
                yield return FirstName;
            if (LastName != null)
                yield return LastName;
        }
    }
}
