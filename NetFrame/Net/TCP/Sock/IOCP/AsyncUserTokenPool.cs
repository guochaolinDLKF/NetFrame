using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetFrame.Net.TCP.Sock.IOCP
{
    /// <summary>
    /// AsyncUserToken对象池（固定缓存设计）
    /// </summary>
    public class AsyncUserTokenPool
    {
        Stack<AsyncUserToken> m_pool;

        // 将对象池初始化为指定的大小
        //
        //“容量”参数是最大数量
        //池可以容纳的AsyncUserToken对象
        public AsyncUserTokenPool(int capacity)
        {
            m_pool = new Stack<AsyncUserToken>(capacity);
        }

        //将一个SocketAsyncEventArg实例添加到池中
        //
        //“item”参数是AsyncUserToken实例
        //添加到池中
        public void Push(AsyncUserToken item)
        {
            if (item == null) { throw new ArgumentNullException("Items added to a SocketAsyncEventArgsPool cannot be null"); }
            lock (m_pool)
            {
                m_pool.Push(item);
            }
        }

        //从池中移除一个AsyncUserToken实例
        //并返回从池中移除的对象
        public AsyncUserToken Pop()
        {
            lock (m_pool)
            {
                return m_pool.Pop();
            }
        }

        //池中AsyncUserToken实例的数量
        public int Count
        {
            get { return m_pool.Count; }
        }
    }
}
