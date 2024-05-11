namespace specs_product_offer.Grpc
{
    public record GrpcResponse<T>(T? Data, string? Error, long? TransactionId = null)
    {
        private bool Failed { get => Data is null || Error is not null; }

        /// <summary>
        /// Throw an InvalidOperationException if Response is failed.
        /// </summary>
        /// <param name="message">message for exception.</param>
        /// <exception cref="InvalidOperationException">Thrown if response is failed.</exception>
        public void ThrowIfFailed(string message)
        {
            if (Failed)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
