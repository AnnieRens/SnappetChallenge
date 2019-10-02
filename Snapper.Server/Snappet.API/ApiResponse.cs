namespace API
{
    public class ApiResponse
    {
        public bool IsSucceed { get; protected set; }

        public string ErrorMessage { get; protected set; }
        
        public static ApiResponse Error(string errorMessage)
        {
            return new ApiResponse
            {
                IsSucceed = false,
                ErrorMessage = errorMessage
            };
        }

        public static ApiResponse Success()
        {
            return new ApiResponse
            {
                IsSucceed = true
            };
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; private set; }

        public static ApiResponse Success(T data)
        {
            return new ApiResponse<T>
            {
                IsSucceed = true,
                Data = data
            };
        }
    }
}