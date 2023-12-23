namespace VirtualPetCareApi.Interface
{
    public interface ICache
    {
        void Add();
        string Get();
    }

    public class MemoryCache : ICache
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public string Get()
        {
            throw new NotImplementedException();
        }
    }

    public class RedisCache : ICache
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public string Get()
        {
            throw new NotImplementedException();
        }
    }
}
