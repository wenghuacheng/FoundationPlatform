using AutoMapper;
using Domain.Core;
using Domain.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;

namespace Application.Core
{
    public abstract class ApplicationService<TEntity, TPrimaryKey> : IApplicationService<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>, new()
    {
        protected readonly IUnitOfWork mUnitOfWork;
        protected readonly IRepository<TEntity, TPrimaryKey> mRepository;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this.mUnitOfWork = unitOfWork;
            this.mRepository = this.mUnitOfWork.Repository<TEntity, TPrimaryKey>();
        }


        #region 基础操作
        public virtual TDto Create<TDto>(TDto model)
        {
            try
            {
                var item = Mapper.Map<TDto, TEntity>(model);
                mRepository.Insert(item, null);
                return Mapper.Map<TEntity, TDto>(item);
            }
            catch (Exception ex)
            {
                return default(TDto);
            }
        }

        /// <summary>
        /// 删除会员类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(TPrimaryKey id)
        {
            try
            {
                mRepository.Delete(new TEntity() { Id = id }, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 更新会员类型
        /// </summary>
        /// <param name="memberType"></param>
        /// <returns></returns>
        public virtual TDto Update<TDto>(TDto model)
        {
            try
            {
                var item = Mapper.Map<TEntity>(model);
                mRepository.Update(item, null);
                return Mapper.Map<TEntity, TDto>(item);
            }
            catch (Exception ex)
            {
                return default(TDto);
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public virtual List<TDto> Get<TDto>()
        {
            try
            {
                var items = mRepository.GetAll().ToList();
                return items.Select(p => Mapper.Map<TDto>(p)).ToList();
            }
            catch (Exception ex)
            {
                return new List<TDto>();
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public virtual TDto Get<TDto>(TPrimaryKey key)
        {
            try
            {
                var item = mRepository.Get(key);
                if (item != null)
                    return Mapper.Map<TDto>(item);
                else
                    return default(TDto);
            }
            catch (Exception ex)
            {
                return default(TDto);
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual List<TDto> Query<TDto>(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            List<TDto> result = new List<TDto>();

            try
            {
                var list = this.mRepository.GetAllPaged(predicate, pageIndex, pageSize, sortingExpression: p => p.Id);
                foreach (var item in list)
                {
                    var member = Mapper.Map<TDto>(item);
                    result.Add(member);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return result;
        }


        #endregion
    }
}
