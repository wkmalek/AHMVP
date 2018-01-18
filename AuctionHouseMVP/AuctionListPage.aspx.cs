using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using AHWForm.Models;
using AHWForm.Presenter;
using AHWForm.Repos;
using AHWForm.View;

namespace AHWForm
{

    public partial class AuctionListPage : System.Web.UI.Page, IAuctionListView
    {
        public List<AuctionListSingleElemVM> vm { get; set; }
        
        private AuctionsRepository auctionsRepo = new AuctionsRepository(new AuctionContext());
        private BidsRepository bidsRepo = new BidsRepository(new BidContext());
        private CategoryRepository catRepo = new CategoryRepository(new CategoryContext());
        protected void Page_Load(object sender, EventArgs e)
        {
            AuctionListPresenter p = new AuctionListPresenter(new AuctionListModel(auctionsRepo, bidsRepo, catRepo), this);
            p.PopulateAuctionList();
            AuctionList.DataSource = vm;
            AuctionList.DataBind();
        }
        

        //public IQueryable<AuctionModel> AuctionList_GetData()
        //{

        //    ////returns query that contains auctions list based on selected category
        //    //string SelectedCategory = Request.QueryString["category"];

        //    //AuctionContext auctionContext = new AuctionContext();
        //    //IQueryable<AuctionModel> ls;
        //    ////Redirect when v is null
        //    //List<string> allCats = GetCategories(SelectedCategory);
        //    //allCats.Add(SelectedCategory);
        //    //List<string> allCatsN = allCats.ConvertAll<string>(delegate (string x) { return x; });
        //    //ls = auctionContext.Auctions.Where(t => allCatsN.Contains(t.CategoryId));
        //    //return ls;
        //}

        //private List<string> GetCategories(string id)
        //{
        //    //returns list of categories connected to selected parent
        //    CategoryContext ac = new CategoryContext();
        //    CategoryModel cat = ac.Categories.Where(x => x.Id == id).SingleOrDefault();
        //    List<string> allChildrenList = new List<string>();
        //    allChildrenList = FindChildrens(allChildrenList, cat.Id,cat, ac);
        //    return allChildrenList;
        //}


        //private List<string> FindChildrens(List<string> listOfCatId, string parentId, CategoryModel cat, CategoryContext ac)
        //{
        //    //returns list of childrens connected to selected parent
        //    List<CategoryModel> categories = ac.Categories.ToList();
        //    foreach (var item in categories)
        //    {
        //        if (item.ParentCategoryId == parentId)
        //        {
        //            listOfCatId.Add(item.Id);
        //            listOfCatId.AddRange(FindChildrens(listOfCatId, item.Id, cat, ac));
        //        }       
        //    }
        //    return listOfCatId;
        //}

    }
}