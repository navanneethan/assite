<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullCalendar.aspx.cs" Inherits="AntiClockFitnessCentre.FullCalendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <%--<script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>--%>
    <%--<script src="Scripts/jquery.min.js" type="text/javascript"></script>--%>
    <script src="js/jquery-1.11.2.min.js"></script>
    <script src="Scripts/moment.min.js" type="text/javascript"></script>
    <script src="Scripts/fullcalendar.min.js" type="text/javascript"></script>
    <link href="Styles/fullcalendar.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="Styles/Site.css" rel="stylesheet" type="text/css" />--%>
    
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var usrID = '<%=Session["UsrID"]%>';
            
            $.ajax({
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({ userID: usrID }),
                url: "FullCalendar.aspx/GetEventsDetails",
                dataType: "json",
                success: function (data) {
                    $('div[id*=fullcal]').fullCalendar({
                        header: {
                            left: '',
                            center: 'prev title next',
                            right: ''
                        },
                        editable: true,
                        disableResizing:true,
                        events: $.map(data.d, function (item, i) {
                            
                            var event = new Object();
                            event.id = item.Id;
                            event.start = new Date(item.StartDate);
                            event.end = new Date(item.EndDate);
                            event.title = item.Subject;
                            event.location = item.Location;
                            event.attendents = item.Attendents;
                            return event;
                        }), 
                        eventClick: function (event, jsEvent, view) {
                           
                            $('#modalTitle').html(event.title);
                            var str = "";
                            str += "Workout : " + event.title + "<br/>";
                            str += "Location : " + event.location + "<br/>";
                            str += "Trainer : " + event.attendents + "<br/>";
                            var startdate = new Date(event.start);
                            var enddate = new Date(event.end);
                            str += "Start : " + startdate.getDate() + "-" + months[startdate.getMonth()] + "-" + startdate.getFullYear() + "<br/>";
                            str += "End : " + enddate.getDate() + "-" + months[enddate.getMonth()] + "-" + enddate.getFullYear() + "<br/>";
                            $('#modalBody').html(str);
                           
                            $('#fullCalModal').modal();
                        },
                        loading: function (bool) {
                            if (bool) $('#loading').show();
                            else $('#loading').hide();
                        }
                    });
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    debugger;
                }
            });
            $('#loading').hide();
            $('div[id*=fullcal]').show();
        });
        var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
        function GetImage(type) {
            if (type == 0) {
                return "<br/><img src = 'Styles/Images/attendance.png' style='width:24px;height:24px'/><br/>"
            }
            else if (type == 1) {
                return "<br/><img src = 'Styles/Images/not_available.png' style='width:24px;height:24px'/><br/>"
            }
            else
                return "<br/><img src = 'Styles/Images/not_available.png' style='width:24px;height:24px'/><br/>"
        }

    </script>
    <div id="loading">
        <img src="Styles/images/loading_wh.gif" />
    </div>
    <div id="fullcal">
    </div>
        <div id="fullCalModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span> <span class="sr-only">close</span></button>
                <h4 id="modalTitle" class="modal-title"></h4>
            </div>
            <div id="modalBody" class="modal-body"></div>
            
        </div>
    </div>
</div>
    </form>
</body>
</html>
