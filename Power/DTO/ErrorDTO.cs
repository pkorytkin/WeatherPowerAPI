namespace Power.DTO
{
    public class ErrorDTO
    {
        public string Error { get; }

        public ErrorDTO(string error)
        {
            Error = error;
        }

        public override bool Equals(object? obj)
        {
            return obj is ErrorDTO other &&
                   Error == other.Error;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Error);
        }
    }
}
