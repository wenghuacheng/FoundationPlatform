using WordRecoder.Domain.Entities;
using WordRecoder.Domain.IRepositories;
using Domain.Core.IRepository;
using Repository.Dapper;

namespace WordRecoder.Infrastructure.Repository
{
    public class RootRepository : DapperRepositoryBase<Root, int>, IRootRepository
    {
        public RootRepository(IDbConnectionProvider connectionProvider)
        {
        }

        //public int AddRoot(Root root)
        //{
        //    string sql = root.GetInsertSql();
        //    sql += "select last_insert_id()";

        //    return this.Connection.Query<int>(sql, GetDbModel(root)).FirstOrDefault();
        //}

        //public List<Root> QueryRoot(int id, string name)
        //{
        //    List<Root> result = new List<Root>();

        //    string sql = "select * from root where 1=1";
        //    if (id > 0) sql += " and Id=@id";
        //    if (!string.IsNullOrWhiteSpace(name)) sql += " and Name like @name";

        //    return this.Connection.Query<Root>(sql, new { id = id, name = "%" + name + "%" }).ToList();
        //}

        //public void UpdateRoot(Root root)
        //{
        //    this.Connection.Execute(root.GetUpdateSql(), GetDbModel(root));
        //}

        //private object GetDbModel(Root root)
        //{
        //    //return root;
        //    return new { Name = root.Name, Derivative = string.Join(",", root.DerivativeList), Type = root.Type, Mean = root.Mean, ChineseMean = root.ChineseMean, Remark = root.Remark, Id = root.Id };
        //}
    }
}
