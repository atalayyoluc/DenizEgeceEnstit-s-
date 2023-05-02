using Business.Service.Abstractions;
using Data.UnitOfWork.Abstractions;
using Entity.Dtos.Users;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concretes
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<UserListDtos> GetAllUser()
        {
            //var user = unitOfWork.GetRepository<Post>().GetAll().Include(x => x.Author).Include(x=>x.PostTags).ToList();
            //var userListDtos=new List<UserListDtos>();

            //var postTag = unitOfWork.GetRepository<PostTag>().GetAll().Include(x => x.Tag).Where(x => x.TagId == x.Tag.Id);
            //foreach(var item in user) 
            //{
            //    userListDtos.Add(new UserListDtos
            //    {
            //        InvitedByName=item.Author.Name,
            //        PostTitle=item.Title,    

            //    });
            //}

            //var post = (from pt in unitOfWork.GetRepository<PostTag>().GetAll()
            //            join p in unitOfWork.GetRepository<Post>().GetAll()
            //            on pt.PostId equals p.Id
            //            join t in unitOfWork.GetRepository<Tag>().GetAll()
            //            on pt.TagId equals t.Id
            //            join u in unitOfWork.GetRepository<User>().GetAll()
            //            on p.Author.Id equals u.Id

            //            group pt by new { p.Id, p.Title, u.InvitedBy.Name, t.Names } into g
            //            select new UserListDtos
            //            {
            //                InvitedByName = g.Key.Name,
            //                PostTitle = g.Key.Title,
            //                Tag1 = g.Key.Names,
            //                Tag2 = g.Key.Names,
            //            }
            //          ).ToList();


            //var postt=unitOfWork.GetRepository<PostTag>().GetAll().Include(x=>x.Post).ThenInclude(x=>x.Author).Include(x=>x.Tag).Where(x=>x.Tag.Id==x.Order).ToList();
                
            //var userListDtoss = new List<UserListDtos>();
            //foreach (var item in postt)
            //{
            //    userListDtoss.Add(new UserListDtos
            //    {
            //        InvitedByName = item.Post.Author.Name,
            //        PostTitle = item.Post.Title,
            //        Tag1=item.Tag.Names,
            //        Tag2 = item.Tag.Names,

            //    });
            //}

            var posttt = unitOfWork.GetRepository<Post>().GetAll().Include(x => x.Author).Include(x => x.PostTags).ThenInclude(x =>x.Tag).ToList();
            var userListDtosss = new List<UserListDtos>();
            foreach (var item in posttt)
            {
                userListDtosss.Add(new UserListDtos
                {
                    UserName=item.Author.Name,
                    InvitedByName = item.Author.InvitedBy.Name,   
                    PostTitle = item.Title,
                    Tag1 = item.PostTags.First().Tag.Names,
                    Tag2 = item.PostTags.Last().Tag.Names
                        

                });
            }
            return userListDtosss;
        }
    }
}
