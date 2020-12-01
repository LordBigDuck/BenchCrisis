using BenchCrisis.Core.Models.Generics;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BenchCrisis.Core.Models.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string email)
        {
            Value = email;
        }

        public static Result<Email> Create(string email)
        {
            email = (email ?? string.Empty).Trim();

            if (email.Length == 0)
                return Result.Fail<Email>("Email should not be empty");

            if (email.Length > 150)
                return Result.Fail<Email>("Email is too long");

            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                return Result.Fail<Email>("Email is invalid");

            return Result.Ok(new Email(email));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static explicit operator Email(string email)
        {
            return Create(email).Value;
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }
    }
}
