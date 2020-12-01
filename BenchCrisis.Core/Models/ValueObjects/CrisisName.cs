using BenchCrisis.Core.Models.Generics;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchCrisis.Core.Models.ValueObjects
{
    public class CrisisName : ValueObject
    {
        public string Value { get; set; }

        private CrisisName(string value)
        {
            Value = value;
        }

        public static Result<CrisisName> Create(string crisisName)
        {
            if (string.IsNullOrWhiteSpace(crisisName))
                return Result.Fail<CrisisName>("Crisis name cannot be empty or null");
            if (crisisName.Length > 75)
                return Result.Fail<CrisisName>("Crisis name cannot be longeur than 75 characters");

            return Result.Ok(new CrisisName(crisisName));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static explicit operator CrisisName(string crisisName)
        {
            return Create(crisisName).Value;
        }

        public static implicit operator string(CrisisName crisisName)
        {
            return crisisName.Value;
        }
    }
}
