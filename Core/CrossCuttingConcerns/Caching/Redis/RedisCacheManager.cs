namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {


        public void Add(string key, object value, int duration)
        {
            throw new System.NotImplementedException();
        }


        public T Get<T>(string key)
        {
            throw new System.NotImplementedException();
        }


        public object Get(string key)
        {
            throw new System.NotImplementedException();
        }


        public bool IsAdd(string key)
        {
            throw new System.NotImplementedException();
        }


        public void Remove(string key)
        {
            throw new System.NotImplementedException();
        }


        public void RemoveByPattern(string pattern)
        {
            throw new System.NotImplementedException();
        }

    }
}