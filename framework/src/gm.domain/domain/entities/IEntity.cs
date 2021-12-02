using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gm.iot.domain.entities
{
    public interface IEntity
    {
        /// <summary>
        /// Returns an array of ordered keys for this entity.
        /// 返回实体有序的键数组
        /// </summary>
        /// <returns></returns>
        object[] GetKeys();
    }

    /// <summary>
    /// Defines an entity with a single primary key with "Id" property.
    /// 定义包含主键Id的实体
    /// </summary>
    public interface IEntity<TKey> : IEntity
    {
        /// <summary>
        /// Unique identifier.
        /// 唯一标识
        /// </summary>
        TKey Id { get; }
    }
}
