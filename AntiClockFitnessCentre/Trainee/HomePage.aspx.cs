using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AntiClockFitnessCentreBAL;
using AntiClockFitnessCentreModal;
using System.Text;
using System.IO;

namespace AntiClockFitnessCentre.Trainee
{
    public partial class HomePage : System.Web.UI.Page
    {
        CommonBL _CommonBL = new CommonBL();
        TrainingVideoBL _TrainingVideoBL = new TrainingVideoBL();
        TrainingVideoModel _TrainingVideoModel = new TrainingVideoModel();
        string userID = "";
        int companyID = 1, videocount = 0;
        StringBuilder _buildTabContentFirst = new StringBuilder();
        StringBuilder _StringModel = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] != null)
            {
                if (!IsPostBack)
                {
                    DataTable _UserDetails = Session[AntiClockFitnessCenter.LOGIN_USER_DETAILS] as DataTable;
                    userID = _UserDetails.Rows[0]["UserID"].ToString();
                    companyID = Convert.ToInt32(_UserDetails.Rows[0]["CompanyID"].ToString());

                    DataTable _FileuploadTBL = _TrainingVideoBL.GetTransactions(0, Convert.ToInt32(userID), companyID);
                    if (_FileuploadTBL.Rows.Count > 0)
                    {
                        for (int i = 0; i < _FileuploadTBL.Rows.Count; i++)
                        {
                            _StringModel = new StringBuilder();
                            string fileName =Path.GetFileNameWithoutExtension(_FileuploadTBL.Rows[i]["TrasactionLocation"].ToString());
                            _StringModel.Append("\n<div id='Model" + _FileuploadTBL.Rows[i]["TransationId"].ToString() + "' class='modal fade' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>");
                            _StringModel.Append("\n<div class='modal-dialog' style='width:90%;height:90%;'>");
                            _StringModel.Append("\n <div class='modal-content' style='height:90%;'>");
                            _StringModel.Append("\n<div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button></div>");
                            _StringModel.Append("\n<div class='modal-body' style='height:90%;'>");
                            _StringModel.Append("\n<video width='540px' height='inherit' id='demo" + fileName + "' controls controlsList='nodownload'>");
                            _StringModel.Append("\n<source src=\"../Uploads/" + _FileuploadTBL.Rows[i]["TrasactionLocation"].ToString() + "\" type='video/mp4'>");
                            _StringModel.Append("\n Your browser does not support the video tag.");
                            _StringModel.Append("\n </video>");
                            _StringModel.Append("\n </div>");
                            // _StringModel.Append("\n<div class='modal-footer'><button type='button' class='btn btn-default' data-dismiss='modal'>Close</button></div>");
                            _StringModel.Append("\n</div>\n</div>\n</div>");
                            if (videocount == 0)
                            {
                                _buildTabContentFirst.Append("<div class='row'>");
                            }

                            
                            _buildTabContentFirst.Append("<div class='col-md-4'><a data-toggle='modal' title='Click Here to view Files'  data-target='#Model" +
                                _FileuploadTBL.Rows[i]["TransationId"].ToString() + "'  >");
                            _buildTabContentFirst.Append("\n<video class='img-fluid img-thumbnail' id='demo" + fileName + "'>");
                            _buildTabContentFirst.Append("\n<source src=\"../Uploads/" + _FileuploadTBL.Rows[i]["TrasactionLocation"].ToString() + "\" type='video/mp4'>");
                            _buildTabContentFirst.Append("\n Your browser does not support the video tag.");
                            _buildTabContentFirst.Append("\n </video>");
                            //<img src=\"../Uploads/thumb_" + fileName + ".jpg\" class='img-fluid img-thumbnail' alt='Play video'>
                            _buildTabContentFirst.Append("</a></div>");
                            _buildTabContentFirst.Append(_StringModel.ToString());
                            if (videocount == 2)
                            {
                                _buildTabContentFirst.Append("\n </div>");
                            }
                            videocount++;
                            if (videocount == 3)
                                videocount = 0;
                        }
                    }
                    else
                    {
                        _buildTabContentFirst.Append("<div class='image'><img src='../images/page-001.jpg' style='width: 100%;' alt='' />");
                        _buildTabContentFirst.Append("</div><div class='details'><h2>Today's Video</h2><p>Tips and tricks to stay healthy </p></div>");
                    }
                    //_buildTabContentFirst.Append("</div>");
                    myVideo.InnerHtml = _buildTabContentFirst.ToString();

                }
            }
        }

    }
}