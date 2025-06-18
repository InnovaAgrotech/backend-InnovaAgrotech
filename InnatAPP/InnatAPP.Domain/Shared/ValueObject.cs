namespace InnatAPP.Domain.Shared
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object?> GetEqualityComponents();

        public sealed override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) 
                return false;

            var other = (ValueObject)obj;

            var thisValues = GetEqualityComponents();
            var otherValues = other.GetEqualityComponents();

            return thisValues.SequenceEqual(otherValues);
        }

        public bool Equals(ValueObject? other)
        {
            if (other is null)
                return false;

            return Equals((object?)other);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            var components = GetEqualityComponents();
            foreach (var component in components)
            {
                hash.Add(component);
            }
            return hash.ToHashCode();
        }

        public static bool operator ==(ValueObject? left, ValueObject? right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject? left, ValueObject? right)
        {
            return !(left == right);
        }

        public override string ToString()
        { 
            var components = GetEqualityComponents();
            var values = string.Join(", ", components.Select(c => c?.ToString() ?? "null"));
            return $"{GetType().Name} [ {values} ]";
        }
    }
}