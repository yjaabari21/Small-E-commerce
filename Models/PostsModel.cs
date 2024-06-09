using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.Data;

namespace HelloWorld.Models
{
    public class PostsModel
    {
        public PostsModel()
        {
            TypeModelList = new List<TypeModel>();
            AdressModelList = new List<AdressModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Post {  get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public List<PostsModel> DataList { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public List<TypeModel> TypeModelList { get; set; }

        public List<AdressModel> AdressModelList { get; set; }
    }
}