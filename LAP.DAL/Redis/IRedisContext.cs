using LAP.ENTITIES;

namespace LAP.DAL.Redis
{
    public interface IRedisContext<T> where T : Entity
    {
        void Clear();

        T Get<T>(string key);

        bool IsSet(string key);

        bool Remove(string key);

        void RemoveByPattern(string pattern);

        string Set(string key, object data, int cacheTime);
    }
}
