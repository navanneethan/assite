<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PDF.aspx.cs" MasterPageFile="~/Trainee/TraineeNew.Master" Inherits="AntiClockFitnessCentre.Trainee.PDF" %>

<asp:Content ContentPlaceHolderID="head" ID="Content2" runat="server">
   <%--<script src="../js/jquery-1.11.2.min.js"></script>--%>
<%-- <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />--%>

    <style type="text/css" >
        /*----- Tabs -----*/
        .tab-links, .tab-links:before, .tab-links:after {
  box-sizing: border-box;
  margin:0px;
  padding:0px;
}
.tabs {
    width:100%;
    display:inline-block;
   
    
}
 
    /*----- Tab Links -----*/
    /* Clearfix */
    .tab-links:after {
        display:block;
        clear:both;
        content:'';
    }
 
    .tab-links li {
        margin:0px 1px;
        float:left;
        list-style:none;
    }
 
        .tab-links a {
            padding:5px 15px;
            display:inline-block;
            border-radius:5px 5px 0px 0px;
            background:#cccccc;
            color: #666;
            font-size: 0.975em;
            text-decoration:none;
            transition:all linear 0.15s;
        }
 
        .tab-links a:hover {
            background:#F2622D;
            color:#cccccc;
            text-decoration:none;
        }
 
    li.active a, li.active a:hover {
         background:#F2622D;
            color:#fff;
    }
 
    /*----- Content of Tabs -----*/
    .tab-content {
        padding:15px;
        border-radius:3px;
        box-shadow:-1px 1px 1px rgba(0,0,0,0.15);
        background:#f9f9f9;
         border-top:5px solid #F2622D;
          border-bottom:5px solid #F2622D;
    border-right:5px solid #F2622D;
     border-left:5px solid #F2622D;
    }
 
        .tab {
            display:none;
        }
 
        .tab.active {
            display:block;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.tabs .tab-links a').on('click', function (e) {
                var currentAttrValue = $(this).attr('href');

                // Show/Hide Tabs
                $('.tabs ' + currentAttrValue).show().siblings().hide();

                // Change/remove current tab to active
                $(this).parent('li').addClass('active').siblings().removeClass('active');

                e.preventDefault();
            });
        });

       
        function SaveToDisk(fileURL, fileName) {
            // for non-IE
            if (!window.ActiveXObject) {
                var save = document.createElement('a');
                save.href = fileURL;
                save.target = '_blank';
                save.download = fileName || 'unknown';

                var event = document.createEvent('Event');
                event.initEvent('click', true, true);
                save.dispatchEvent(event);
                (window.URL || window.webkitURL).revokeObjectURL(save.href);
            }

                // for IE
            else if (!!window.ActiveXObject && document.execCommand) {
                var _window = window.open(fileURL, '_blank');
                _window.document.close();
                _window.document.execCommand('SaveAs', true, fileName || fileURL)
                _window.close();
            }
        }

    </script>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="Ptitle">Download PDF</div>
<%--    <h2>Download PDF</h2>--%>
    <br />
    
   <div class="tabs standard">
<ul class="tab-links" id="t" runat="server" >
<li class="active"><a href="#tab1">PDF #1</a></li>
<li><a href="#tab2">PDF #2</a></li>
<li><a href="#tab3">PDF #3</a></li>
</ul>
       <div class="tab-content" id ="tc" runat="server" >
<div id="tab1" class="tab active">
<p>Click to downdload</p>
</div>
</div>


<%--<ul id="myTab" class="nav nav-tabs">
  <li class="active"><a href="#home" data-toggle="tab">Home</a></li>
  <li class=""><a href="#profile" data-toggle="tab">Profile</a></li>
  <li class="dropdown">
    <a href="#" id="myTabDrop1" class="dropdown-toggle" data-toggle="dropdown">Dropdown <b class="caret"></b></a>
    <ul class="dropdown-menu" role="menu" aria-labelledby="myTabDrop1">
      <li><a href="#dropdown1" tabindex="-1" data-toggle="tab">@fat</a></li>
      <li><a href="#dropdown2" tabindex="-1" data-toggle="tab">@mdo</a></li>
    </ul>
  </li>
</ul>
 
<div id="myTabContent" class="tab-content">
  <div class="tab-pane fade active in" id="home">
    <p>Raw denim you probably haven't heard of them jean shorts Austin. Nesciunt tofu stumptown aliqua, retro synth master cleanse. Mustache cliche tempor, williamsburg carles vegan helvetica. Reprehenderit butcher retro keffiyeh dreamcatcher synth. Cosby sweater eu banh mi, qui irure terry richardson ex squid. Aliquip placeat salvia cillum iphone. Seitan aliquip quis cardigan american apparel, butcher voluptate nisi qui.</p>
  </div>
  <div class="tab-pane fade" id="profile">
    <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid. Exercitation +1 labore velit, blog sartorial PBR leggings next level wes anderson artisan four loko farm-to-table craft beer twee. Qui photo booth letterpress, commodo enim craft beer mlkshk aliquip jean shorts ullamco ad vinyl cillum PBR. Homo nostrud organic, assumenda labore aesthetic magna delectus mollit. Keytar helvetica VHS salvia yr, vero magna velit sapiente labore stumptown. Vegan fanny pack odio cillum wes anderson 8-bit, sustainable jean shorts beard ut DIY ethical culpa terry richardson biodiesel. Art party scenester stumptown, tumblr butcher vero sint qui sapiente accusamus tattooed echo park.</p>
  </div>
  <div class="tab-pane fade" id="dropdown1">
    <p>Etsy mixtape wayfarers, ethical wes anderson tofu before they sold out mcsweeney's organic lomo retro fanny pack lo-fi farm-to-table readymade. Messenger bag gentrify pitchfork tattooed craft beer, iphone skateboard locavore carles etsy salvia banksy hoodie helvetica. DIY synth PBR banksy irony. Leggings gentrify squid 8-bit cred pitchfork. Williamsburg banh mi whatever gluten-free, carles pitchfork biodiesel fixie etsy retro mlkshk vice blog. Scenester cred you probably haven't heard of them, vinyl craft beer blog stumptown. Pitchfork sustainable tofu synth chambray yr.</p>
  </div>
  <div class="tab-pane fade" id="dropdown2">
    <p>Trust fund seitan letterpress, keytar raw denim keffiyeh etsy art party before they sold out master cleanse gluten-free squid scenester freegan cosby sweater. Fanny pack portland seitan DIY, art party locavore wolf cliche high life echo park Austin. Cred vinyl keffiyeh DIY salvia PBR, banh mi before they sold out farm-to-table VHS viral locavore cosby sweater. Lomo wolf viral, mustache readymade thundercats keffiyeh craft beer marfa ethical. Wolf salvia freegan, sartorial keffiyeh echo park vegan.</p>
  </div>
</div>--%>
       <br />
        <script src="../js/bootstrap-modal-carousel.min.js"></script>
    <script type='text/javascript'>

        //$('[id^="Carousel"]').carousel();
        $(document).ready(function () {
            $('[data-toggle="modal"]').tooltip();
            function centerModal() {
                $(this).css('display', 'block');
               
                var id = $(this).attr('id');
               
                var len = id.length;
                var idnum = id.substr(5, len);
               
               // alert(idnum);
                $('#Carousel' + idnum).css('display', 'block');
                var $dialog = $(this).find(".modal-dialog");
                var modelheight = $dialog.height() ;
                $('#Carousel' + idnum).css('height', modelheight);
                //var $dialog = $(this).find(".modal-dialog");
                //var offset = ($(window).height() - $dialog.height()) / 2;
                //// Center modal vertically in window
                //$dialog.css("margin-top", 5);
            }


            $('.modal').on('show.bs.modal', centerModal);
            $(window).on("resize", function () {
                $('.modal:visible').each(centerModal);
            });

            $('.modal').on('hidden.bs.modal', function (e) {
                var id = $(this).attr('id');
                var len = id.length;
                var idnum = id.substr(5, len);
                $('#Carousel' + idnum).css('display', 'none');
            })

        });

    </script>

</asp:Content>
