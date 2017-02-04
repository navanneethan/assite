using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AntiClockFitnessCentreBAL;
using AntiClockFitnessCentreModal;
using System.Data;
using System.Text;
using System.Reflection;
using System.IO;

namespace AntiClockFitnessCentre.Trainee
{
    public partial class PDF : System.Web.UI.Page
    {
        FileUploadsBL _fileuploadBL = new FileUploadsBL();
        FileUploadsModel _fileuploadModel = new FileUploadsModel();
        UserBL _UserBL = new UserBL();
        StringBuilder _buildTabli = new StringBuilder();
        StringBuilder _buildTabContentFirst = new StringBuilder();
        StringBuilder _buildTabli2 = new StringBuilder();
        StringBuilder _buildTabContentSecond = new StringBuilder();
        StringBuilder _StringSlider = new StringBuilder();
        StringBuilder _StringModel = new StringBuilder();

        string userID = "";
        int companyID = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                if (!IsPostBack)
                {

                    DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                    userID = _UserDetails.Rows[0]["UserID"].ToString();
                    companyID = Convert.ToInt32(_UserDetails.Rows[0]["CompanyID"].ToString());
                    LoadTransactionTypeNew();
                }
                //LoadTransactionType();
                
            }
        }

        private DataTable LoadFiles(DataTable source, int typId, int userId)
        {

            if (source.Rows.Count > 0)
            {
                var userTransaction = from p in source.AsEnumerable()
                                      where p.Field<bool>("Status") == true && p.Field<int>("UserId") == userId && p.Field<int>("TransactionType") == typId
                                      select new { FileLocation = p.Field<string>("TrasactionLocation"), TransId = p.Field<int>("TransationId") };
                return LINQToDataTable(userTransaction);
            }

            return null;
        }

        //private void LoadTransactionType()
        //{
        //    DataTable _fileuploadTBL = _fileuploadBL.GetTransactionType();
        //    DataTable _fileuploadTransTBL = _fileuploadBL.GetTransactions(0, Convert.ToInt32(userID), companyID);
        //    DataTable _userTransactionTBL = null;


        //    //var resultJoint = from p in __fileuploadTBL.AsEnumerable()
        //    //                  join s in userTransaction.AsEnumerable() on p.Field<int>("TRAN_TYPE_ID") equals s.TranscationTypeId into t
        //    //                  from rt in t.DefaultIfEmpty()
        //    //                  orderby p.Field<int>("TRAN_TYPE_ID")
        //    //                  select new
        //    //                  {
        //    //                      TranscationTypeId = p.Field<int>("TRAN_TRANSACTION_TYPE_ID"),
        //    //                      TranscationTypeId = p.Field<int>("TRAN_TRANSACTION_TYPE_ID"),
        //    //                      FileLocation,

        //    //                  }


        //    //DataTable _userTransactionTBL = LINQToDataTable(userTransaction);

        //    if (_fileuploadTBL != null && _fileuploadTBL.Rows.Count > 0)
        //    {

        //        for (int i = 0; i < _fileuploadTBL.Rows.Count; i++)
        //        {
        //            if (_fileuploadTransTBL != null && _fileuploadTransTBL.Rows.Count > 0)
        //            {
        //                _userTransactionTBL = LoadFiles(_fileuploadTransTBL, Convert.ToInt32(_fileuploadTBL.Rows[i][0].ToString()), Convert.ToInt32(userID));
        //            }
        //            if (i < 4)
        //            {
        //                if (i == 0)
        //                {
        //                    _buildTabli.Append("<li class='active'><a href='#");
        //                    _buildTabContentFirst.Append("<div id='" + _fileuploadTBL.Rows[i][1].ToString().Replace(" ", string.Empty) + "' class='tab active'>");
        //                }
        //                else
        //                {
        //                    _buildTabli.Append("<li><a href='#");
        //                    _buildTabContentFirst.Append("<div id='" + _fileuploadTBL.Rows[i][1].ToString().Replace(" ", string.Empty) + "' class='tab' >");
        //                }
        //                _buildTabli.Append(_fileuploadTBL.Rows[i][1].ToString().Replace(" ", string.Empty) + "'>");
        //                _buildTabli.Append(_fileuploadTBL.Rows[i][1].ToString().Substring(0, 5));
        //                _buildTabli.Append("</a></li>");

        //                if (_userTransactionTBL != null && _userTransactionTBL.Rows.Count > 0)
        //                {
        //                    for (int ii = 0; ii < _userTransactionTBL.Rows.Count; ii++)
        //                    {

        //                        // _buildTabContentFirst.Append(" <p>Click <input type='button' value='Download' onClick='SaveToDisk('" + _userTransactionTBL.Rows[ii][0].ToString() + "')' > ");
        //                        //_buildTabContentFirst.Append(" <p>Click <asp:LinkButton ID='lnkDownload' runat='server' Text='here' CommandArgument='" + _fileuploadTransTBL.Rows[ii][0].ToString() + "' OnClick='lnkDownload_Click'> here </asp:LinkButton>");
        //                        _buildTabContentFirst.Append(" <p>Click <a href='" + _userTransactionTBL.Rows[ii][0].ToString() + "' download >here</a> ");
        //                        _buildTabContentFirst.Append(" to download your " + _fileuploadTBL.Rows[i][1].ToString() + " </p>");

        //                    }

        //                    _buildTabContentFirst.Append("</div>");

        //                }
        //                else
        //                {
        //                    _buildTabContentFirst.Append(" <p>No Content Uploaded </p></div>");
        //                }



        //            }
        //            else
        //            {
        //                if (i == 4)
        //                {
        //                    _buildTabli2.Append("<li class='active'><a href='#");
        //                    _buildTabContentSecond.Append("<div id='" + _fileuploadTBL.Rows[i][1].ToString().Replace(" ", string.Empty) + "' class='tab active'>");
        //                }
        //                else
        //                {
        //                    _buildTabli2.Append("<li><a href='#");
        //                    _buildTabContentSecond.Append("<div id='" + _fileuploadTBL.Rows[i][1].ToString().Replace(" ", string.Empty) + "' class='tab' >");
        //                }
        //                _buildTabli2.Append(_fileuploadTBL.Rows[i][1].ToString().Replace(" ", string.Empty) + "'>");
        //                _buildTabli2.Append(_fileuploadTBL.Rows[i][1].ToString().Substring(0, 5));
        //                _buildTabli2.Append("</a></li>");


        //                if (_userTransactionTBL != null && _userTransactionTBL.Rows.Count > 0)
        //                {
        //                    for (int ii = 0; ii < _userTransactionTBL.Rows.Count; ii++)
        //                    {
        //                        _buildTabContentSecond.Append(" <p>Click <a href='' id='link' download='" + _userTransactionTBL.Rows[ii][0].ToString() + "' >here</a> ");
        //                        // _buildTabContentSecond.Append(" <p>Click <input type='button' value='Download' onClick='download('file.ext')' > ");
        //                        //_buildTabContentSecond.Append(" <p>Click <asp:LinkButton ID='lnkDownload' runat='server' Text='here' CommandArgument='" +_fileuploadTransTBL.Rows[ii][0].ToString() +"' OnClick='lnkDownload_Click'></asp:LinkButton>");
        //                        _buildTabContentSecond.Append(" to download your " + _fileuploadTBL.Rows[i][1].ToString() + " </p>");

        //                    }

        //                    _buildTabContentSecond.Append("</div>");

        //                }
        //                else
        //                {
        //                    _buildTabContentSecond.Append(" <p>No Content Uploaded </p></div>");
        //                }

        //            }
        //        }

        //        t.InnerHtml = _buildTabli.ToString();
        //        // t2.InnerHtml = _buildTabli2.ToString();
        //        tc.InnerHtml = _buildTabContentFirst.ToString();
        //        // ts.InnerHtml = _buildTabContentSecond.ToString();
        //    }


        //}

        private void LoadTransactionTypeNew()
        {
            DataTable _fileuploadTBL = _fileuploadBL.GetTransactionType();
            DataTable _fileuploadTransTBL = _fileuploadBL.GetTransactions(0, Convert.ToInt32(userID), companyID);
            DataTable _userTransactionTBL = null;
            if (_fileuploadTBL != null && _fileuploadTBL.Rows.Count > 0)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl _Divcarouselslidecarouselfit = new System.Web.UI.HtmlControls.HtmlGenericControl("div");//carousel main
                System.Web.UI.HtmlControls.HtmlGenericControl _DivModel = new System.Web.UI.HtmlControls.HtmlGenericControl("div");//carousel main
                for (int i = 0; i < _fileuploadTBL.Rows.Count; i++)
                {
                    if (_fileuploadTransTBL != null && _fileuploadTransTBL.Rows.Count > 0)
                    {
                        _userTransactionTBL = LoadFiles(_fileuploadTransTBL, Convert.ToInt32(_fileuploadTBL.Rows[i][0].ToString()), Convert.ToInt32(userID));
                    }

                    if (i == 0)
                    {
                        _buildTabli.Append("<li title ='" + _fileuploadTBL.Rows[i][1].ToString() + "' class='active'><a href='#");
                        _buildTabContentFirst.Append("<div id='" + _fileuploadTBL.Rows[i][1].ToString().Replace(" ", string.Empty) + "' class='tab active'>");
                    }
                    else
                    {
                        _buildTabli.Append("<li title ='" + _fileuploadTBL.Rows[i][1].ToString() + "'><a href='#");
                        _buildTabContentFirst.Append("<div id='" + _fileuploadTBL.Rows[i][1].ToString().Replace(" ", string.Empty) + "' class='tab' >");
                    }
                    _buildTabli.Append(_fileuploadTBL.Rows[i][1].ToString().Replace(" ", string.Empty) + "'>");

                    // if (_fileuploadTBL.Rows[i][1].ToString().Length > )
                    //int index = _fileuploadTBL.Rows[i][1].ToString().IndexOf(' ');
                    _buildTabli.Append(_fileuploadTBL.Rows[i][1].ToString().Substring(0, 5) + "...");
                    _buildTabli.Append("</a></li>");

                    if (_userTransactionTBL != null && _userTransactionTBL.Rows.Count > 0)
                    {

                        for (int ii = 0; ii < _userTransactionTBL.Rows.Count; ii++)
                        {
                            _StringSlider = new StringBuilder();
                            _StringModel = new StringBuilder();


                            if (_userTransactionTBL.Rows[ii][0].ToString().Contains(".mp4"))
                            {
                                _StringModel.Append("\n  <div id='Model" + _userTransactionTBL.Rows[ii][1].ToString() + "' class='modal fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>");
                                _StringModel.Append("\n<div class='modal-dialog' style='width:90%;height:90%;'>");
                                _StringModel.Append("\n <div class='modal-content' style='height:90%;'>");
                                _StringModel.Append("\n<div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button></div>");
                                _StringModel.Append("\n<div class='modal-body' style='height:90%;'>");
                                _StringModel.Append("\n<video width='540px' height='inherit' id='demo1' controls>");
                                _StringModel.Append("\n<source src=\"../Uploads/" + _userTransactionTBL.Rows[ii][0].ToString() + "\" type='video/mp4'>");
                                _StringModel.Append("\n Your browser does not support the video tag.");
                                _StringModel.Append("\n </video>");
                                _StringModel.Append("\n </div>");
                               // _StringModel.Append("\n<div class='modal-footer'><button type='button' class='btn btn-default' data-dismiss='modal'>Close</button></div>");
                                _StringModel.Append("\n</div>\n</div>\n</div>");

                                _buildTabContentFirst.Append("<a data-toggle='modal' title='Click Here to view Files'  data-target='#Model" + _userTransactionTBL.Rows[ii][1].ToString() + "'  ><img src=\"../images/videoplayer.png\" class='img-thumbnail' alt='Cinque Terre' width='100' height='100'></a>");



                                _buildTabContentFirst.Append(_StringModel.ToString());
                            }
                            else
                            {
                                _StringModel.Append("\n  <div id='Model" + _userTransactionTBL.Rows[ii][1].ToString() + "' class='modal fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>");
                                _StringModel.Append("\n<div class='modal-dialog' style='width:90%;height:100%;'>");
                                _StringModel.Append("\n <div class='modal-content' style='height:91%;'>");
                                _StringModel.Append("\n<div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button></div>");
                                _StringModel.Append("\n<div class='modal-body' style='height:90%;'>");
                                //_StringModel.Append("\n<iframe src=\"../Uploads/" + imglist[0].ToString() + "\" style=\"height:100%;width:100%;\" class=\"img-responsive\">");
                                _StringModel.Append("\n </div>");
                                //_StringModel.Append("\n<div class='modal-footer'><button type='button' class='btn btn-default' data-dismiss='modal'>Close</button></div>");
                                _StringModel.Append("\n</div>\n</div>\n</div>");

                                _StringSlider.Append("\n<div id=\"Carousel" + _userTransactionTBL.Rows[ii][1].ToString() + "\" class=\"carousel slide carousel-fit\" data-ride=\"carousel\" data-interval=\"60000\" style=\"display: none;height:100%;\">");

                                // _StringSlider.Append("\n<div id=\"Carousel" + _userTransactionTBL.Rows[ii][1].ToString() + "\" class=\"carousel slide\" data-ride=\"carousel\" data-interval=\"60000\" >");
                                _StringSlider.Append("\n<div class=\"carousel-inner\"  style='height:100%;'>");

                                string FirstImage = string.Empty;

                               string[] imglist = _userTransactionTBL.Rows[ii][0].ToString().Split(',');

                                for (int iv = 0; iv < imglist.Count(); iv++)
                                {
                                    if (iv == 0)
                                    {
                                        FirstImage = imglist[iv].ToString();
                                        _StringSlider.Append("\n<div class=\"item active\" style='height:100%;'>");
                                        string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"100%\" height=\"100%\" >";
                                        embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
                                        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                                        embed += "</object>";

                                        _StringSlider.Append(string.Format(embed, ResolveUrl("~/Uploads/" + imglist[iv].ToString())));
                                        //_StringSlider.Append("\n<img src=\"../ConvertedImage/" + imglist[iv].ToString() + "\"  class=\"img-responsive\">");
                                        _StringSlider.Append("\n</div>");


                                    }
                                    else
                                    {

                                        _StringSlider.Append("\n<div class=\"item\">");
                                        _StringSlider.Append("\n<img src=\"../ConvertedImage/" + imglist[iv].ToString() + "\"  class=\"img-responsive\">");
                                        _StringSlider.Append("\n</div>");
                                    }
                                }



                                _StringSlider.Append("\n</div>");
                                //_StringSlider.Append("\n <a class=\"left carousel-control\" role=\"button\" href=\"#Carousel" + _userTransactionTBL.Rows[ii][1].ToString() + "\" data-slide=\"prev\"><span class=\"glyphicon glyphicon-chevron-left\"></span></a>");
                               // _StringSlider.Append("\n<a class=\"right carousel-control\" role=\"button\" href=\"#Carousel" + _userTransactionTBL.Rows[ii][1].ToString() + "\" data-slide=\"next\"><span class=\"glyphicon glyphicon-chevron-right\"></span></a>");
                                _StringSlider.Append("\n</div>");

                                // _buildTabContentFirst.Append(" <p>Click <input type='button' value='Download' onClick='SaveToDisk('" + _userTransactionTBL.Rows[ii][0].ToString() + "')' > ");
                                //_buildTabContentFirst.Append(" <p>Click <asp:LinkButton ID='lnkDownload' runat='server' Text='here' CommandArgument='" + _fileuploadTransTBL.Rows[ii][0].ToString() + "' OnClick='lnkDownload_Click'> here </asp:LinkButton>");
                                //_buildTabContentFirst.Append(" <p>Click <a href='#' id=" + _userTransactionTBL.Rows[ii][1].ToString() + "  data-toggle='modal' data-target='#Model" + _userTransactionTBL.Rows[ii][1].ToString() + "' data-local='#Carousel" + _userTransactionTBL.Rows[ii][1].ToString() + "'  >here</a> ");
                                // _buildTabContentFirst.Append(" <p>Click <button type='button' class='btn' data-toggle='modal' data-target='#Model" + _userTransactionTBL.Rows[ii][1].ToString() + "' data-local='#Carousel" + _userTransactionTBL.Rows[ii][1].ToString() + "'  >here</button> ");
                                //_buildTabContentFirst.Append(" to download your " + _fileuploadTBL.Rows[i][1].ToString() + " </p>");

                               _buildTabContentFirst.Append("<a data-toggle='modal' title='Click Here to view Files'  data-target='#Model" + _userTransactionTBL.Rows[ii][1].ToString() + 
                                   "' data-local='#Carousel" + _userTransactionTBL.Rows[ii][1].ToString() + "' > Click Here to view report </a>");


                                //tc.Controls.Add(_Divcarouselslidecarouselfit);
                                //tc.Controls.Add(_DivModel);
                                _buildTabContentFirst.Append(_StringModel.ToString());
                                _buildTabContentFirst.Append(_StringSlider.ToString());
                            }



                        }



                        _buildTabContentFirst.Append("</div>");

                    }
                    else
                    {
                        _buildTabContentFirst.Append(" <p>No Content Uploaded </p></div>");
                    }
                }
                t.InnerHtml = _buildTabli.ToString();
                //t2.InnerHtml = _buildTabli2.ToString();
                tc.InnerHtml = _buildTabContentFirst.ToString();

                //ts.InnerHtml = _buildTabContentSecond.ToString();
            }

        }

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others           will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }


        private void CreateSlider()
        {



            ////tc.Controls.Add();
            System.Web.UI.HtmlControls.HtmlGenericControl _Divcarouselslidecarouselfit = new System.Web.UI.HtmlControls.HtmlGenericControl("div");//carousel main
            _Divcarouselslidecarouselfit.ID = "Carousel" + 1;
            _Divcarouselslidecarouselfit.Attributes.Add("class", "carousel slide carousel-fit");
            _Divcarouselslidecarouselfit.Attributes.Add("data-ride", "carousel");
            _Divcarouselslidecarouselfit.Attributes.Add("data-interval", "60000");
            _Divcarouselslidecarouselfit.Style.Add("display", "none");

            System.Web.UI.HtmlControls.HtmlGenericControl _Divcarouselinner = new System.Web.UI.HtmlControls.HtmlGenericControl("div");////carousel  inner
            _Divcarouselslidecarouselfit.Attributes.Add("class", "carousel-inner");
            _Divcarouselslidecarouselfit.Controls.Add(_Divcarouselinner);

            System.Web.UI.HtmlControls.HtmlGenericControl _Divcarouseimage = new System.Web.UI.HtmlControls.HtmlGenericControl("div");////carousel image div
            _Divcarouselslidecarouselfit.Attributes.Add("class", "item active");
            _Divcarouselinner.Controls.Add(_Divcarouseimage);

            System.Web.UI.HtmlControls.HtmlImage _imgcarouselinner = new System.Web.UI.HtmlControls.HtmlImage();//carousel image
            _imgcarouselinner.Src = "";
            _imgcarouselinner.Attributes.Add("class", "img-responsive");
            _Divcarouseimage.Controls.Add(_imgcarouselinner);

            System.Web.UI.HtmlControls.HtmlAnchor _linkcarouselinnerleft = new System.Web.UI.HtmlControls.HtmlAnchor();//carousel left arrow
            _linkcarouselinnerleft.Attributes.Add("class", "left carousel-control");
            _linkcarouselinnerleft.HRef = "";
            _linkcarouselinnerleft.Attributes.Add("data-slide", "prev");
            _Divcarouselinner.Controls.Add(_linkcarouselinnerleft);
            System.Web.UI.HtmlControls.HtmlGenericControl _Spancarouselinnerleft = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
            _Spancarouselinnerleft.Attributes.Add("class", "glyphicon glyphicon-chevron-left");
            _linkcarouselinnerleft.Controls.Add(_Spancarouselinnerleft);

            System.Web.UI.HtmlControls.HtmlAnchor _linkcarouselinnerright = new System.Web.UI.HtmlControls.HtmlAnchor();//carousel right arrow
            _linkcarouselinnerright.Attributes.Add("class", "right carousel-control");
            _linkcarouselinnerright.HRef = "";
            _linkcarouselinnerright.Attributes.Add("data-slide", "next");
            _Divcarouselinner.Controls.Add(_linkcarouselinnerright);
            System.Web.UI.HtmlControls.HtmlGenericControl _Spancarouselinnerright = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
            _Spancarouselinnerright.Attributes.Add("class", "glyphicon glyphicon-chevron-right");
            _linkcarouselinnerleft.Controls.Add(_Spancarouselinnerright);




        }
        private void CreateModel(string id)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl _DivModel = new System.Web.UI.HtmlControls.HtmlGenericControl("div");//carousel main
            _DivModel.Attributes.Add("class", "modal fade");
            _DivModel.Attributes.Add("tabindex", "-1");
            _DivModel.Attributes.Add("role", "dialog");
            _DivModel.Attributes.Add("aria-labelledby", "myModalLabel");
            _DivModel.Attributes.Add("aria-hidden", "true");
            _DivModel.ID = "Model" + id;

            System.Web.UI.HtmlControls.HtmlGenericControl _DivModelDialog = new System.Web.UI.HtmlControls.HtmlGenericControl("div");//carousel main
            _DivModelDialog.Attributes.Add("class", "modal-dialog");
            _DivModelDialog.Attributes.Add("style", "width:90%;height:90%");
            _DivModel.Controls.Add(_DivModelDialog);

            System.Web.UI.HtmlControls.HtmlGenericControl _DivModelContent = new System.Web.UI.HtmlControls.HtmlGenericControl("div");//carousel main
            _DivModelContent.Attributes.Add("class", "modal-content");
            _DivModelContent.Attributes.Add("style", "height:90%");
            _DivModelDialog.Controls.Add(_DivModelContent);

            System.Web.UI.HtmlControls.HtmlGenericControl _DivModelHeader = new System.Web.UI.HtmlControls.HtmlGenericControl("div");//carousel main
            _DivModelHeader.Attributes.Add("class", "modal-header");
            _DivModelContent.Controls.Add(_DivModelHeader);

            System.Web.UI.HtmlControls.HtmlButton _btnModelHeader = new System.Web.UI.HtmlControls.HtmlButton();
            _btnModelHeader.Attributes.Add("class", "close");
            _btnModelHeader.Attributes.Add("data-dismiss", "modal");
            _btnModelHeader.Attributes.Add("aria-hidden", "true");
            _btnModelHeader.InnerHtml = "&times;";
            _DivModelHeader.Controls.Add(_btnModelHeader);

            System.Web.UI.HtmlControls.HtmlGenericControl _DivModelBody = new System.Web.UI.HtmlControls.HtmlGenericControl("div");//carousel main
            _DivModelBody.Attributes.Add("class", "modal-body");
            _DivModelBody.Attributes.Add("style", "height:90%");
            _DivModelContent.Controls.Add(_DivModelBody);

            System.Web.UI.HtmlControls.HtmlGenericControl _DivModelFooter = new System.Web.UI.HtmlControls.HtmlGenericControl("div");//carousel main
            _DivModelFooter.Attributes.Add("class", "modal-footer");
            _DivModelContent.Controls.Add(_DivModelFooter);

            System.Web.UI.HtmlControls.HtmlButton _btnModelfooter = new System.Web.UI.HtmlControls.HtmlButton();
            _btnModelfooter.Attributes.Add("class", "btn btn-default");
            _btnModelfooter.Attributes.Add("data-dismiss", "modal");
            _btnModelfooter.Attributes.Add("aria-hidden", "true");
            _btnModelfooter.InnerHtml = "&times;";
            _DivModelFooter.Controls.Add(_btnModelfooter);
        }

    }


}