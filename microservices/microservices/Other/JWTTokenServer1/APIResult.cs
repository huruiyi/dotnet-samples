namespace JWTTokenServer1
{
    public class APIResult<T>
    {
        public int Code { set; get; }

        public T Data { set; get; }

        public string Message { set; get; }
    }
}