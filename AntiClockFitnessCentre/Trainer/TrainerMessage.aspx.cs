using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AntiClockFitnessCentreBAL;
using AntiClockFitnessCentreModal;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;

namespace AntiClockFitnessCentre.Trainer
{
    public partial class TrainerMessage : System.Web.UI.Page
    {

        MessageBL _MessageBL = new MessageBL();
        MessageModal _MessageModal = new MessageModal();
        CommentModal _CommentModal = new CommentModal();
        string userID = "";
        int companyID = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                userID = _UserDetails.Rows[0]["UserID"].ToString();
                companyID = Convert.ToInt32(_UserDetails.Rows[0]["CompanyID"].ToString());
            }
            if (!IsPostBack)
            {
                LoadPostFromDB();
            }
        }
        protected void btnButton_Click(object sender, EventArgs e)
        {
            SaveToDB();
        }

        private void SaveToDB()
        {

            string filepath = Server.MapPath("\\Uploads");
            HttpFileCollection uploadedFiles = Request.Files;
            //Span1.Text = string.Empty;
            string imagelist = string.Empty;

            try
            {

                _MessageModal.postFromId = Convert.ToInt32(userID);
                _MessageModal.postContent = txtContent.Text;

                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    HttpPostedFile userPostedFile = uploadedFiles[i];


                    if (userPostedFile.ContentLength > 0)
                    {
                        userPostedFile.SaveAs(filepath + "\\" + Path.GetFileName(userPostedFile.FileName));
                        if (i == (uploadedFiles.Count - 1))
                        {
                            imagelist += Path.GetFileName(userPostedFile.FileName);
                        }
                        else
                        {
                            imagelist += Path.GetFileName(userPostedFile.FileName) + ",";
                        }

                    }

                }

                _MessageModal.postContentImage = imagelist;
                _MessageModal.PostcompanyId = companyID;
                int _Result = _MessageBL.InsertPost(_MessageModal);
                if (_Result == 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                    //lblSucess.Text = "Saved Sucessfully";
                    //IsSuccess(true);
                }
                LoadPostFromDB();
                txtContent.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.ErrorMessage(), false);
                //lblError.Text = ex.Message;
                //IsSuccess(false);
            }

        }

        private void LoadPostFromDB()
        {
            DataTable _PostTBL = _MessageBL.GetPost(companyID);

            dalstPost.DataSource = _PostTBL;
            dalstPost.DataBind();

        }


        public static byte[] ImageToBinary(string imagePath)
        {
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);
            fileStream.Close();
            return buffer;
        }

        protected void LinkCommentLike_Click(object sender, EventArgs e)
        {
            string postid = (sender as LinkButton).CommandArgument;






        }
        protected void lbtnLike_Click(object sender, EventArgs e)
        {
            string postid = (sender as LinkButton).CommandArgument;

            int _PostLikeount = _MessageBL.GetLikeCount(Convert.ToInt32(postid), Convert.ToInt32(userID), false);

            LinkButton _lbtnLike = (LinkButton)sender;

            // _lbtnLike.Text = _PostLikeount + "Likes";

            if (_PostLikeount == 0)
            {
                _lbtnLike.Text = "Like";
            }
            else
            {
                _lbtnLike.Text = _PostLikeount + "Like";
            }

            string s = "Update TBL_POST SET POS_LIKE = 1 where POS_ID =(@x1) INSERT INTO TBL_LIKE (LIK_POST_ID,LIK_BY_USERID) VALUES (@x2,@x3)  ";

        }

        public void dalstPost_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "SubmitComment")
            {
                //string postid = (sender as Button).CommandArgument;
                int postid = Convert.ToInt32(dalstPost.DataKeys[e.Item.ItemIndex]);
                TextBox _Comment = (TextBox)(e.Item.FindControl("txtComment"));

                _CommentModal.commentFromId = Convert.ToInt32(userID);
                _CommentModal.commentContent = _Comment.Text;
                _CommentModal.commentPostId = postid;

                int _Result = _MessageBL.InsertComment(_CommentModal);
                if (_Result == 1)
                {
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "tmp", AntiClockFitnessCenter.SuccessMessage(), false);
                    //lblSucess.Text = "Saved Sucessfully";
                    //IsSuccess(true);

                    Repeater _repComments = (Repeater)(e.Item.FindControl("RepDetails"));

                    DataTable _commentsTBL = _MessageBL.GetComment(postid);

                    _repComments.DataSource = _commentsTBL;
                    _repComments.DataBind();

                    _Comment.Text = string.Empty;

                }

            }


        }

        protected void dalstPost_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            DataListItem item = e.Item;
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hf = e.Item.FindControl("hddStoeimg") as HiddenField;
                // Repeater innerRepeater = (Repeater)e.Item.FindControl("RepImage");


                // innerRepeater.ItemDataBound += innerRepeater_ItemDataBound;

                DataRowView drv = (DataRowView)item.DataItem;
                Session["RepImageList"] = Getdatble(hf.Value);
                System.Web.UI.HtmlControls.HtmlGenericControl _divRowOne = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("DivImages");
                if (hf.Value.Length > 0)
                {
                    _divRowOne.InnerHtml = GetImages(hf.Value).ToString();
                }

                int postid = Convert.ToInt32(dalstPost.DataKeys[e.Item.ItemIndex]);
                int _PostLikeount = _MessageBL.GetLikeCount(Convert.ToInt32(postid), Convert.ToInt32(userID), true);

                LinkButton _lbtnLike = (LinkButton)(e.Item.FindControl("lbtnLike"));

                if (_PostLikeount == 0)
                {
                    _lbtnLike.Text = "Like";
                }
                else
                {
                    _lbtnLike.Text = _PostLikeount + "Like";
                }

                //_lbtnLike.Text = _PostLikeount + "Likes";
                Repeater _repComments = (Repeater)(e.Item.FindControl("RepDetails"));

                DataTable _commentsTBL = _MessageBL.GetComment(postid);

                _repComments.DataSource = _commentsTBL;
                _repComments.DataBind();

            }
        }


        private StringBuilder GetImages(string storevalues)
        {
            StringBuilder _strBuild = new StringBuilder();
            StringBuilder _strRow1 = new StringBuilder();
            StringBuilder _strRow2 = new StringBuilder();

            string[] imglist = storevalues.Split(',');

            //_strBuild.Append(" <div class='container dynamicTile'>");

            for (int i = 0; i < imglist.Count(); i++)
            {

                if (i == 0)
                {
                    //_strBuild.Append("<div class='row '>");
                    //_strBuild.Append("<div class='col-sm-2 col-xs-4'>");
                    _strBuild.Append("<div id='tile1' class='tile'>");
                    _strBuild.Append("<div class='carousel slide' data-ride='carousel'>");
                    _strBuild.Append("<div class='carousel-inner'>");
                    _strBuild.Append(" <div class='item active'>");
                    _strBuild.Append("  <img src='../Uploads/" + imglist[i].ToString() + "' width='200' height='200' class='thumbnail'>");
                    _strBuild.Append("  </div>");
                }
                else
                {
                    _strBuild.Append(" <div class='item'>");
                    _strBuild.Append("  <img src='../Uploads/" + imglist[i].ToString() + "' width='200' height='200' class='thumbnail'>");
                    _strBuild.Append("  </div>");
                }



            }
            //_strBuild.Append("  </div>");
            //_strBuild.Append("  </div>");
            // _strBuild.Append("  </div>");
            _strBuild.Append("  </div>");
            _strBuild.Append("  </div>");
            _strBuild.Append("  </div>");

            return _strBuild;

        }




        private DataTable Getdatble(string storevalues)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Image", Type.GetType("System.String"));

            string[] imglist = storevalues.Split(',');

            foreach (string img in imglist)
            {
                if (!string.IsNullOrEmpty(img))
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "~/" + img.ToString();
                    dt.Rows.Add(dr);
                }
            }


            return dt;
        }



    }
}