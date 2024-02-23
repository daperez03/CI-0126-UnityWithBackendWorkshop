using System;
using System.Collections.Generic;
using UnityWithBackendWorkshop.Domain.Core;

namespace UnityWithBackendWorkshop.Domain.TeamAggregate
{
    public class UserName : ValueObject
    {
        public string Value { get; }
        private UserName(string value)
        {
            Value = value;
        }

        public static UserName Create(string value)
        {
            // We enfonrce invariants.
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("User name cannot be empty or whitespace.", nameof(value));
            }

            if (value.Contains('/'))
            {
                throw new ArgumentNullException("User name cannot contain a /.", nameof(value));
            }
            return new UserName(value);
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}