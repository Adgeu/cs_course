namespace CityStorage
{
    /// <summary>
    /// The result of the operation in <see cref="Storage"/>
    /// </summary>
    public class ResultStorageOperation
    {
        /// <summary>
        /// Success of the operation
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// The title of the result message
        /// </summary>
        public string MessageTitle { get; } = "";

        /// <summary>
        /// The message of the operation
        /// </summary>
        public string Message { get; } = "";

        private ResultStorageOperation(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        private ResultStorageOperation(bool isSuccess, string messageTitle, string message) :
            this(isSuccess)
        {
            MessageTitle = messageTitle;
            Message = message;
        }

        public static implicit operator bool(ResultStorageOperation result) =>
            result.IsSuccess;

        /// <summary>
        /// Return success <see cref="ResultStorageOperation"/>
        /// </summary>
        /// <returns>Success result</returns>
        public static ResultStorageOperation SuccessResult() =>
            new ResultStorageOperation(true);

        /// <summary>
        /// Return success <see cref="ResultStorageOperation"/>
        /// </summary>
        /// <param name="messageTitle">The title of the result message</param>
        /// <param name="message">The message of the operation</param>
        /// <returns>Success result</returns>
        public static ResultStorageOperation SuccessResult(string messageTitle, string message) =>
            new ResultStorageOperation(true, messageTitle, message);

        /// <summary>
        /// Return not success <see cref="ResultStorageOperation"/>
        /// </summary>
        /// <returns>Not success result</returns>
        public static ResultStorageOperation NotSuccessResult() =>
            new ResultStorageOperation(false);

        /// <summary>
        /// Return not success <see cref="ResultStorageOperation"/>
        /// </summary>
        /// <param name="messageTitle">The title of the result message</param>
        /// <param name="message">The message of the operation</param>
        /// <returns>Not success result</returns>
        public static ResultStorageOperation NotSuccessResult(string messageTitle, string message) =>
            new ResultStorageOperation(false, messageTitle, message);
    }
}
