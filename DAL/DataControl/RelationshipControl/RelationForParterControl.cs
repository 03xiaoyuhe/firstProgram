using DAL.DataControl.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataControl.RelationshipControl
{
    public class RelationForParterControl : DataBaseControl, IDataSelect, IDataInsert, IDataDelete, IDataUpdate
    {
        #region 查询功能

        public DataSet Select(string whereString, string gropeBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            throw new NotImplementedException();
        }

        public DataSet Select(List<string> Fields, string whereString, string gropeBy, string orderByField, bool isAscending, int? pageSize, int? pageNumber)
        {
            throw new NotImplementedException();
        }

        public object SelectReturnObject(string whereString)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 插入功能

        public void Insert(SqlTransaction sqlTransaction, object Item)
        {
            throw new NotImplementedException();
        }

        public string InsertReturnID(SqlTransaction sqlTransaction, object Item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 删除功能

        int IDataDelete.DeleteByID(SqlTransaction sqlTransaction, string ID)
        {
            throw new NotImplementedException();
        }

        int IDataDelete.Delete(SqlTransaction sqlTransaction, string Where)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 更新功能

        int IDataUpdate.Update(SqlTransaction sqlTransaction, string ID, object Item)
        {
            throw new NotImplementedException();
        }

        int IDataUpdate.Update(SqlTransaction sqlTransaction, object Item, string Where)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
