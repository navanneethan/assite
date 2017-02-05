<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CopDefault.aspx.cs" Inherits="AntiClockFitnessCentre.CopDefault" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->  
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->  
<!--[if !IE]><!--> <html lang="en"> <!--<![endif]-->  

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Anticlockfitness</title>
    <!-- Meta -->
    <meta charset="UTF-8">
    
<link href="css/normalize.css" rel="stylesheet" />
  <link rel='stylesheet prefetch' href='https://s3-us-west-2.amazonaws.com/s.cdpn.io/6035/grid.css'>
<link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Montserrat'>
<link rel='stylesheet prefetch' href='https://s3-us-west-2.amazonaws.com/s.cdpn.io/6035/icomoon-scrtpxls.css'>

<link href="css/style.css" rel="stylesheet" />
    <script src="js/prefixfree.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
  <div class="grid_4">
    <section class="box widget locations">
      <div class="avatar">
        <%--<img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/6035/scrtpxls_location.png"  />--%>
          <img src="ProfileImage/nomale.png" height="175" width="175" />
      </div>
      <div class="details">        
             <ul>
                 <li><h2>Name</h2></li>
                 <li> <p>Alexy Masilamani</p></li>
             </ul>
        
           <h2>Age</h2><p>32</p>
           <h2>Gender</h2><p>Female</p>
       
        <%--<a href="#" class="btn btn-primary btn-block btn-large">view on maps</a>--%>
      </div>
    </section>
    <section class="box widget calendar">
      <header class="header">
        <h2>Saturday</h2>
        <p><span class="icon-arrow-left"></span>January<span class="icon-arrow-right"></span></p>
      </header>
      <article class="days">
        <ul>
          <li class="previous">30</li>
          <li class="previous">31</li>
          <li>1</li>
          <li>2</li>
          <li>3</li>
          <li>4</li>
          <li>5</li>
          <li>6</li>
          <li>7</li>
          <li>8</li>
          <li>9</li>
          <li>10</li>
          <li>11</li>
          <li>12</li>
          <li>13</li>
          <li>14</li>
          <li>15</li>
          <li>16</li>
          <li>17</li>
          <li>18</li>
          <li>19</li>
          <li>20</li>
          <li>21</li>
          <li>22</li>
          <li>23</li>
          <li>24</li>
          <li>25</li>
          <li>26</li>
          <li>27</li>
          <li>28</li>
          <li>29</li>
          <li>30</li>
          <li>31</li>
          <li class="next">1</li>
          <li class="next">2</li>
        </ul>
      </article>
    </section>
  </div>
  <div class="grid_8">
    <nav class="box nav">
      <ul>
        <li>
          <a href="#">
            <span class="icon-home"></span><br />
            <span class="title">Home</span>
          </a>
        </li>
        <li>
          <a href="">
            <span class="icon-images"></span><br />
            <span class="title">Gallery</span>
          </a>
        </li>
        <li>
          <a href="">
            <span class="icon-bubble"></span><br />
            <span class="title">Message</span>            
          </a>
        </li>
        <li>
          <a href="">
            <span class="icon-music"></span><br />
            <span class="title">Music</span> 
          </a>
        </li>
        <li>
          <a href="">
            <span class="icon-search"></span><br />
            <span class="title">Search</span>
          </a>
        </li>
        <li>
          <a href="">
            <span class="icon-cog"></span><br />
            <span class="title">Settings</span>
          </a>
        </li>
        <li>
          <a href="">
            <span class="icon-location"></span><br />
            <span class="title">Location</span>
          </a>
        </li>
      </ul>
    </nav>
    <div class="inner_container">
      <div class="col_1of3">
        <section class="box widget video">
          <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/6035/scrtpxls_video.png" alt="" />
        </section>
        <section class="box widget weather">
          <header class="header">
            <div class="temp">10&#176; <span class="icon-brightness-half"></span></div>
            <span class="icon-partlycloudy"></span>
          </header>
          <article>
            <h2>Saturday 16 January</h2>
          </article>
        </section>
      </div>
      <div class="col_2of3">
        <article class="box post">
          <div class="image">
            <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/6035/scrtpxls_post.png" />
          </div>
          <div class="details">
            <h2>Amsterdan</h2>
            <p>Amsterdam is the capital city of and the most populous within the Kingdom of the Netherlands. Amsterdam's name derives from Amstelredamme. Amsterdam is located in the western... Netherlands</p>
          </div>
        </article>
      </div>
      <div class="col_2of3">
        <section class="box widget audio">
          <div class="image">
            <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/6035/scrtpxls_audio.png" />
          </div>
          <div class="details">
            <h2 class="album">Geef mij maar Amsterdam</h2>
            <p class="artist">Johnny Jordaan</p>
            <div class="player">
              <div class="bar">
                <div class="progress" data-time="1:45"></div>
              </div>
              <div class="actions">
                <a href="#" class="btn"><span class="icon-arrow-left"></span></a>
                <a href="#" class="btn btn-primary"><span class="icon-pause"></span></a>
                <a href="#" class="btn"><span class="icon-arrow-right"></span></a>
              </div>
            </div>
          </div>
        </section>  
      </div>
      <div class="col_1of3">
        <section class="box widget find">
          <input type="text" name="find" placeholder="Find your city place" />
          <label for="favorite" class="checkbox">
            <input type="checkbox" id="favorite" name="favorite" />
            Add to favorites
          </label>
          <a href="#" class="btn btn-primary btn-large btn-block">Search</a>
        </section>
      </div>
    </div>
  </div>
</div>
  
    </form>
</body>
</html>
