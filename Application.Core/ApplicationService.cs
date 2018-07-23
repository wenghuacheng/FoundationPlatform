using AutoMapper;
using Domain.Core;
using Domain.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        public virtual bool Create<TDto>(TDto model)
        {
            try
            {
                var item = Mapper.Map<TDto, TEntity>(model);
                mRepository.Insert(item, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
        public virtual bool Update<TDto>(TDto model)
        {
            try
            {
                var item = Mapper.Map<TEntity>(model);
                mRepository.Update(item, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
                var items = mRepository.GetAll().Select(p => Mapper.Map<TDto>(p));
                return items.ToList();
            }
            catch (Exception)
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
                var item = mRepository.FirstOrDefault(p => p.Id.Equals(key));
                if (item != null)
                    return Mapper.Map<TDto>(item);
                else
                    return default(TDto);
            }
            catch (Exception)
            {
                return default(TDto);
            }
        }
        #endregion
    }
}
