using System;
using System.Collections.Generic;
using UnityWithBackendWorkshop.Domain.Core;

namespace UnityWithBackendWorkshop.Domain.TeamAggregate
{
    public class TeamName : ValueObject
    {
        public string Value { get; }

        private TeamName(string value)
        {
            Value = value;
        }

        public static TeamName Create(string value)
        {
            // We enfonrce invariants.
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("User name cannot be empty or whitespace.", nameof(value));
            }

            if (value.Contains('@'))
            {
                throw new ArgumentNullException("User name cannot contain a @.", nameof(value));
            }
            return new TeamName(value);
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}