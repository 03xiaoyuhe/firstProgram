using System;
using System.Collections.Generic;

namespace Models.PageDataSor.ForMyTable
{

    #region 错误集
    /// <summary>
    /// 复选框缓存对象ID已存在错误
    /// </summary>
    public class CacheForChoosedBoxIsExistException : Exception
    {
        /// <summary>
        /// 复选框缓存对象ID已存在错误
        /// </summary>
        /// <param name="Erro">错误信息</param>
        public CacheForChoosedBoxIsExistException(string Erro) : base(Erro) { }
    }

    /// <summary>
    /// 复选框缓存对象ID不存在错误
    /// </summary>
    public class CacheForChoosedBoxNotExistException : Exception
    {
        /// <summary>
        /// 复选框缓存对象ID不存在错误
        /// </summary>
        /// <param name="Erro">错误信息</param>
        public CacheForChoosedBoxNotExistException(string Erro) : base(Erro) { }
    }

    #endregion


    /// <summary>
    /// 表格批量选择功能数据类实现
    /// </summary>
    public class ChoosedDataIDContain
    {
        /// <summary>
        /// 用于存放所有已注册的缓存ID
        /// </summary>
        static HashSet<string> IDContains
        {
            get
            {
                return CacheGenericity<HashSet<string>>.Data["MyTableIDContains"];
            }
            set
            {
                CacheGenericity<HashSet<string>>.Data["MyTableIDContains"] = value;
            }
        }

        /// <summary>
        /// 用于存放该缓存对象的ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 用于存放该对象所有已选数据项的ID
        /// </summary>
        public HashSet<string> ChoosedIDs
        {
            get
            {
                if (IDContains.Contains(ID)) return CacheGenericity<HashSet<string>>.Data[$"{ID}-ChoosedID"];
                else throw new Exception($"{ID}--该数据ID未绑定");
            }
            set
            {
                if (IDContains.Contains(ID)) CacheGenericity<HashSet<string>>.Data[$"{ID}-ChoosedID"] = value;
                else throw new Exception($"{ID}--该数据ID未绑定");
            }
        }

        /// <summary>
        /// 将指定ID注册到ID列表中
        /// </summary>
        /// <param name="ID">需要注册的ID</param>
        /// <exception cref="CacheForChoosedBoxIsExistException">如果对于ID已存在会抛出异常</exception>
        public static void Creat(string ID)
        {
            if (!IDContains.Contains(ID))
            {
                IDContains.Add(ID);
                CacheGenericity<HashSet<string>>.Data[$"{ID}-ChoosedID"] = new HashSet<string>();
            }
            else
            {
                throw new CacheForChoosedBoxIsExistException($"{ID}--该ID已创建");
            }
        }

        /// <summary>
        /// 用于清除指定ID的内容
        /// </summary>
        /// <param name="ID">需要清除的ID</param>
        /// <exception cref="CacheForChoosedBoxNotExistException">若ID不存在会抛出异常</exception>
        public static void Clear(string ID)
        {
            if (IDContains.Contains(ID))
            {
                CacheGenericity<HashSet<string>>.Data[$"{ID}-ChoosedID"] = new HashSet<string>();
            }
            else
            {
                throw new CacheForChoosedBoxNotExistException($"{ID}--该ID不存在");
            }
        }

        /// <summary>
        /// 删除对应的ID及其内容
        /// </summary>
        /// <param name="ID">数据的ID</param>
        /// <exception cref="CacheForChoosedBoxNotExistException">如果ID不存在会抛出异常</exception>
        public static void Delete(string ID)
        {
            if (!IDContains.Contains(ID))
            {
                IDContains.Remove(ID);
                CacheGenericity<HashSet<string>>.Data[$"{ID}-ChoosedID"] = null;
            }
            else
            {
                throw new CacheForChoosedBoxNotExistException($"{ID}--该ID不存在");
            }
        }

        public static bool Contian(string ID)
        {
            return IDContains.Contains(ID);
        }

        /// <summary>
        /// 向缓存中添加信息
        /// </summary>
        /// <param name="DataID"></param>
        public void Add(string DataID)
        {
            ChoosedIDs.Add(DataID);
        }

        /// <summary>
        /// 移除缓存中指定内容
        /// </summary>
        /// <param name="DataID"></param>
        public void Remove(string DataID)
        {
            ChoosedIDs.Remove(DataID);
        }

        /// <summary>
        /// 将缓存中的内容清楚
        /// </summary>
        public void Clear()
        {
            ChoosedIDs.Clear();
        }

        /// <summary>
        /// 判断缓存中是否包含内容
        /// </summary>
        /// <param name="DataID"></param>
        /// <returns></returns>
        public bool Contains(string DataID)
        {
            return ChoosedIDs.Contains(DataID);
        }
    }
}
