using System.Collections;

namespace DataLayer.Repository
{
    public class RepositoryEnumertor<T> : IEnumerator<T> where T : notnull
    {
        public RepositoryEnumertor(IRepository<T> repository)
        {
            m_list = repository.GetAll();
        }

        public T Current => m_list[m_index];
        object IEnumerator.Current => Current;
        public void Dispose() { }
        public bool MoveNext() => ++m_index < m_list.Count;
        public void Reset() => m_index = 0;

        List<T> m_list;
        private int m_index = -1;
    }
}
