﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AntiClockFitnessCentre.Default" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->  
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->  
<!--[if !IE]><!--> <html lang="en"> <!--<![endif]-->  

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>AtSaiPavi</title>
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <!--Favicon -->
	<link rel="icon" type="image/png" href="images/favicon.ico" />
		
	<!-- CSS Files -->
		
	<link rel="stylesheet" href="css/reset.css" />
	<link rel="stylesheet" href="css/animate.min.css" />
	<link rel="stylesheet" href="css/bootstrap.min.css" />
	<link rel="stylesheet" href="css/styleindex.css" />
	<link rel="stylesheet" href="css/font-awesome.css" />
	<link rel="stylesheet" href="css/owl.carousel.css" />
	<link rel="stylesheet" href="css/responsive.css" />
	<link rel="stylesheet" href="css/player/YTPlayer.css" />
	<link href="css/pro-bars.css" rel="stylesheet" />
	

	<!-- End CSS Files -->
</head>
<body>
    <form id="form1" runat="server">
    <!-- Navigation -->
	<section id="navigation" class="dark-nav">
		<!-- Navigation Inner -->
		<div class="nav-inner">
			<!-- Site Logo -->
			<div class="site-logo">
				<a href="#" id="logo-text" class="scroll logo">AtSaiPavi Physio & Fitness
				</a>
			</div><!-- End Site Logo -->
			<a class="mini-nav-button gray2"><i class="fa fa-bars"></i></a>
			<!-- Navigation Menu -->
		    <div class="nav-menu">
				<ul class="nav uppercase">
					<li><a href="#home" class="scroll">Home</a></li>       
					<li><a href="#about" class="scroll">About us</a></li>
					<!-- <li><a href="#features" class="scroll">Team</a></li>  -->    
					<li><a href="#clients" class="scroll">Courses</a></li>					
					<li><a href="#contact" class="scroll">Contact</a></li>
					<li><a href="Login.aspx" class="scroll">Login/SignUp</a></li>
				</ul>
		  </div><!-- End Navigation Menu -->
		</div><!-- End Navigation Inner -->
	</section><!-- End Navigation Section -->


	<!-- Home Section -->
	<section id="home" class="relative"> 	
		<div id="slides">
			<div class="slides-container relative">
				<!-- Slider Images -->
				<div class="image2"></div>
                <div class="image1"></div>
				<div class="image3"></div>
                <div class="image4"></div>
				 <!-- End Slider Images -->	 
			</div>
			<!-- Slider Controls -->
			<nav class="slides-navigation">
			  <a href="#" class="next"></a>
			  <a href="#" class="prev"></a>
			</nav>
		</div><!-- End Home Slides -->
		<div class="v2 absolute">
			<!-- Auto Typocraphic Texts -->
			<div class="typographic">
            	<!-- Your Logo -->
				<div class="logo">
					<%--<img src="images/logo-footer.png" width="200" alt="Logo" />--%>
				</div>
				<h2 class=" condensed uppercase no-padding no-margin bold gray1">Introducing</h2>
				<h2 class=" condensed uppercase no-padding no-margin bold colored">Fitness Passion</h2>
				<a href="#about" class="scroll"><i class="arrow-down fa fa-3x fa-angle-double-down"></i></a>
			</div><!--End Auto Typocraphic Texts -->
		</div><!-- End V2 area -->
	</section><!-- End Home Section -->

    
	<!-- Fun Acts -->
	<section id="fun-acts" class="container">

		<div class="inner fun-acts">
        <div class="about-margin"></div>
        <a class="about-icon">
			<i class="fa fa-life-ring"></i>
		</a>
        <br />        

			<!-- Header -->
			<h1 class="header light gray1 animated" data-animation="fadeInLeft" data-animation-delay="400">
			 Winners Train,<span class="colored" data-animation="fadeInRight">Losers Complain</span></h1>
			<!-- Description -->
			<p class="h-desc"><span class="colored">Sweat is Fat Crying</span> Think of this while you're sweating it out and you won't be able to fight the laughter!.</p>

		</div><!-- End Fun Acts Inner -->

	</section><!-- End Fun Acts Section -->
    
    <!-- About -->
	<section id="about" class="container waypoint">
		<div class="inner">        
        
			<!-- Header -->
			<h1 class="header light gray3 fancy"><span class="colored">Know </span>about us</h1>
			<br><br><br>
			<!-- Description -->
			<!--<p class="h-desc gray4">lorem Ipsum is<span class="colored bold"> lorem Ipsum</span> of passages of Lorem Ipsum available, but the majority have suffered alteration.<br /><br /></p> 
			<hr>  -->     
        
			<!-- Boxes -->
			<div class="boxes">

								
				<div class="col-xs-12 col-md-6 col-sm-12 about-box animated" data-animation="fadeIn" data-animation-delay="700">
				<p class="lead lead-text">WHAT WE DO AND WHO WE ARE?</p><hr>
				 <p class="h-desc gray4"><span class="colored bold">AtSaiPavi </span> provide world class health and fitness services at your working area, living apartments and gym premises.
							Our motto is to rejuvenate without growing old and fat to giving you the best fitness advice and training  without making you feel board seeking for fitness professionals.
							<span class="colored bold">AtSaiPavi </span> helps you to connect with well experienced fitness professionals and to keep your body fit and healthy without stepping in to fitness studios.
							we play core role in your daily activities to break down your calories and build up the wealthy health.
							<span class="colored bold">AtSaiPavi </span> a clock that takes you younger sec by sec care you minute by minutes protects you hour by hour feel fresh to receive our service at an earlier stage to run your body clock extend our service.</p>
					
				</div>
				
				<!--<div class="col-xs-3 col-sm-6 col-md-3 about-box animated" data-animation="fadeIn" data-animation-delay="100">
				<p class="lead">Cardio</p>
				<p class="light about-text">by Coach Johnson</p>
				<hr><br>
					<a class="about-icon">
						<i class="fa fa-child"></i>
					</a>					
				</div>
				
				<div class="col-xs-3 col-sm-6 col-md-3 about-box animated" data-animation="fadeIn" data-animation-delay="100">
				<p class="lead">Core</p>
				<p class="light about-text">by Coach Johnson</p>
				<hr><br>
					<a class="about-icon">
						<i class="fa fa-bed"></i>
					</a>
					<br><br>
					
				</div>
				-->
				<div class="col-xs-3 col-sm-6 col-md-3 about-box animated" data-animation="fadeIn" data-animation-delay="100">
				<p class="lead">Cycling</p>
				<p class="light about-text">by Coach Johnson</p>
				<hr><br>
					<a class="about-icon">
						<i class="fa fa-bicycle"></i>
					</a>
					<br><br>
					
				</div>

				
				<div class="col-xs-3 col-sm-6 col-md-3 about-box animated" data-animation="fadeIn" data-animation-delay="300">
				<p class="lead">Trekking</p>
				<p class="light about-text">by Coach Bala</p>
				<hr><br>
					<a class="about-icon">
						<i class="fa fa-tree"></i>
					</a>
					<br><br>
					
				</div>
				
			</div><!-- End Boxes -->
		</div><!-- End About Inner -->
	</section><!-- End About Section -->

	<!-- Features -->
	<!-- <section id="features" class="container">

		<div class="inner">

			<!-- Header -->
			<!-- <h1 class="header light gray1">Features of <span class="colored fancy">Fitness!</span></h1>

			<!-- Description -->
			<!-- <p class="h-desc white bold">lorem Ipsum is<span class="colored bold"> lorem Ipsum</span> lorem Ipsum is simply dummy text of the printing and typesetting industry loremipsum. lorem Ipsum is simply dummy text of the printing and typesetting industry loremipsum is simple.</p>

			<div class="features-boxes">

				<!-- Box 1 -->
				<!-- <div class="col-xs-4 f-box animated" data-animation="fadeIn" data-animation-delay="0">
					<!-- Icon -->
					<!-- <a class="f-icon">
						<i class="fa fa-eye"></i>
					</a>
					<!-- Header -->
					<!-- <p class="feature-head">Retina Ready</p>
					<!-- Text -->
					<!-- <p class="feature-text ">lorem Ipsum is lorem Ipsum of passages of Lorem Ipsum available, but the majority have suffered alteration.</p>
				</div>


				<!-- Box 2 -->
				<!-- <div class="col-xs-4 f-box animated" data-animation="fadeIn" data-animation-delay="100">
					<!-- Icon -->
					<!-- <a class="f-icon">
						<i class="fa fa-tablet"></i>
					</a>
					<!-- Header -->
					<!-- <p class="feature-head">Responsive Framework</p>
					<!-- Text -->
					<!-- <p class="feature-text ">lorem Ipsum is lorem Ipsum of passages of Lorem Ipsum available, but the majority have suffered alteration.</p>
				</div>


				<!-- Box 3 -->
				<!-- <div class="col-xs-4 f-box animated" data-animation="fadeIn" data-animation-delay="200">
					<!-- Icon -->
					<!-- <a class="f-icon">
						<i class="fa fa-flask"></i>
					</a>
					<!-- Header -->
				<!-- 	<p class="feature-head">Parallax Design</p>
					<!-- Text -->
			<!-- 		<p class="feature-text light">lorem Ipsum is lorem Ipsum of passages of Lorem Ipsum available, but the majority have suffered alteration.</p>
				</div>
				<div class="clear"></div>

		<!-- 	</div><!-- End Features Boxes -->

	<!-- 	</div> <!-- End Features Inner -->

<!-- 	</section> --><!-- End Features Section -->
    
	<!-- Clients -->
	<section id="clients" class="container">

		<!-- Team Inner -->
		<div class="inner team">

			<!-- Header -->
			<h1 class="header light gray3 fancy"><span class="colored">Our </span> Courses</h1>

			<!-- Description -->
			<p class="h-desc gray4">See what we offer.</p>


			<!-- Members -->
			<div class="team-members inner-details">

				<!-- Member -->
				<div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="0">
					<div class="member-inner">
						<!-- Team Member Image -->
						<a class="team-image">
							<!-- Img -->
							<img src="images/clients/features-image-1.jpg" alt="" />
						</a>
						<div class="member-details">
							<div class="member-details-inner">
								<!-- Name -->
								<h2 class="member-name light">Crossfit Courses</h2>
								<!-- Description -->
								<p class="member-description"></p>
								<!-- Socials -->
								<div class="socials">
									<!-- Link -->
									<a href="#"><i class="fa fa-link"></i></a>
								</div><!-- End Socials -->
							</div> <!-- End Detail Inner -->
						</div><!-- End Details -->
					</div> <!-- End Member Inner -->
				</div><!-- End Member -->


				<!-- Member -->
				<div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="100">
					<div class="member-inner">
						<!-- Team Member Image -->
						<a class="team-image">
							<!-- Img -->
							<img src="images/clients/features-image-2.jpg" alt="" />
						</a>
						<div class="member-details">
							<div class="member-details-inner">
								<!-- Name -->
								<h2 class="member-name light">Personal Training</h2>
								<!-- Description -->
								<p class="member-description"></p>
								<!-- Socials -->
								<div class="socials">
									<!-- Image -->
									<a href="#"><i class="fa fa-camera"></i></a>
								</div><!-- End Socials -->
							</div> <!-- End Detail Inner -->
						</div><!-- End Details -->
					</div> <!-- End Member Inner -->
				</div><!-- End Member -->


				<!-- Member -->
				<div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="200">
					<div class="member-inner">
						<!-- Team Member Image -->
						<a class="team-image">
							<!-- Img -->
							<img src="images/clients/features-image-3.jpg" alt="" />
						</a>
						<div class="member-details">
							<div class="member-details-inner">
								<!-- Name -->
								<h2 class="member-name light">Gymnastic Sports</h2>
								<!-- Description -->
								<p class="member-description"></p>
								<!-- Socials -->
								<div class="socials">
									<!-- Link -->
									<a href="#"><i class="fa fa-link"></i></a>
								</div><!-- End Socials -->
							</div> <!-- End Detail Inner -->
						</div><!-- End Details -->
					</div> <!-- End Member Inner -->
				</div><!-- End Member -->


				<!-- Member -->
				<div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="300">
					<div class="member-inner">
						<!-- Team Member Image -->
						<a class="team-image">
							<!-- Img -->
							<img src="images/clients/features-image-4.jpg" alt="" />
						</a>
						<div class="member-details">
							<div class="member-details-inner">
								<!-- Name -->
								<h2 class="member-name light">Outdoor Activities</h2>
								<!-- Description -->
								<p class="member-description"></p>
								<!-- Socials -->
								<div class="socials">
									<!-- Image -->
									<a href="#"><i class="fa fa-camera"></i></a>
								</div><!-- End Socials -->
							</div> <!-- End Detail Inner -->
						</div><!-- End Details -->
					</div> <!-- End Member Inner -->
				</div><!-- End Member -->


				<!-- Member -->
				<div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="400">
					<div class="member-inner">
						<!-- Team Member Image -->
						<a class="team-image">
							<!-- Img -->
							<img src="images/clients/features-image-5.jpg" alt="" />
						</a>
						<div class="member-details">
							<div class="member-details-inner">
								<!-- Name -->
								<h2 class="member-name light">Women Yoga Fit</h2>
								<!-- Description -->
								<p class="member-description"></p>
								<!-- Socials -->
								<div class="socials">
									<!-- Link -->
									<a href="#"><i class="fa fa-link"></i></a>
								</div><!-- End Socials -->
							</div> <!-- End Detail Inner -->
						</div><!-- End Details -->
					</div> <!-- End Member Inner -->
				</div><!-- End Member -->
                
				<!-- Member -->
				<div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="0">
					<div class="member-inner">
						<!-- Team Member Image -->
						<a class="team-image">
							<!-- Img -->
							<img src="images/clients/features-image-6.jpg" alt="" />
						</a>
						<div class="member-details">
							<div class="member-details-inner">
								<!-- Name -->
								<h2 class="member-name light">Men Muscle Gaining</h2>
								<!-- Description -->
								<p class="member-description"></p>
								<!-- Socials -->
								<div class="socials">
									<!-- Link -->
									<a href="#"><i class="fa fa-link"></i></a>
								</div><!-- End Socials -->
							</div> <!-- End Detail Inner -->
						</div><!-- End Details -->
					</div> <!-- End Member Inner -->
				</div><!-- End Member -->


				<!-- Member -->
				<div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="100">
					<div class="member-inner">
						<!-- Team Member Image -->
						<a class="team-image">
							<!-- Img -->
							<img src="images/clients/features-image-7.jpg" alt="" />
						</a>
						<div class="member-details">
							<div class="member-details-inner">
								<!-- Name -->
								<h2 class="member-name light">Body Strength Workout</h2>
								<!-- Description -->
								<p class="member-description"></p>
								<!-- Socials -->
								<div class="socials">
									<!-- Image -->
									<a href="#"><i class="fa fa-camera"></i></a>
								</div><!-- End Socials -->
							</div> <!-- End Detail Inner -->
						</div><!-- End Details -->
					</div> <!-- End Member Inner -->
				</div><!-- End Member -->


				<!-- Member -->
				<div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="200">
					<div class="member-inner">
						<!-- Team Member Image -->
						<a class="team-image">
							<!-- Img -->
							<img src="images/clients/features-image-8.jpg" alt="" />
						</a>
						<div class="member-details">
							<div class="member-details-inner">
								<!-- Name -->
								<h2 class="member-name light">Home Workout Courses</h2>
								<!-- Description -->
								<p class="member-description">.</p>
								<!-- Socials -->
								<div class="socials">
									<!-- Link -->
									<a href="#"><i class="fa fa-link"></i></a>
								</div><!-- End Socials -->
							</div> <!-- End Detail Inner -->
						</div><!-- End Details -->
					</div> <!-- End Member Inner -->
				</div><!-- End Member -->                

				<!-- Member -->
				<div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="500">
					<div class="member-inner">
						<!-- Team Member Image -->
						<a class="team-image">
							<!-- Img -->
							<img src="images/clients/features-image-1.jpg" alt="" />
						</a>
						<div class="member-details">
							<div class="member-details-inner">
								<!-- Name -->
								<h2 class="member-name light"></h2>
								<!-- Description -->
								<p class="member-description"></p>
								<!-- Socials -->
								<div class="socials">
									<!-- Image -->
									<a href="#"><i class="fa fa-camera"></i></a>
								</div><!-- End Socials -->
							</div> <!-- End Detail Inner -->
						</div><!-- End Details -->
					</div> <!-- End Member Inner -->
				</div><!-- End Member -->
			</div><!-- End Members -->
		</div><!-- End Team Inner -->
	</section><!-- End Team Section -->  


	
    
	<!-- Testimonials -->
	<!-- <section id="testimonial" class="testimonials parallax2">

		<div class="inner">

			<div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
			  <!-- Indicators -->
			  <!-- <ol class="carousel-indicators">
			    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
			    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
			    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
			  </ol>

			  <!-- Wrapper for slides -->
			  <!-- <div class="carousel-inner">
			    <div class="item active">
			    	<ul>
				     <li class="monial">
						<!-- Text -->
						<!-- <h1 class="condensed white">"<span class="colored">Lorem ipsum dolor</span> sit amet, consectetur adipiscing elit. Cras euismod vestibulum orci, mollis vulpute felis dapibus sed. Nam ullamcorper congue elit."</h1>
						<!-- Name -->
						<!-- <p class="light">John Doe</p>
					</li>
					</ul>
			    </div>
			    <div class="item">
			      <ul>
			      <li class="monial">
						<!-- Text -->
						<!-- <h1 class="condensed white"><span class="colored">Lorem ipsum dolor</span> sit amet, consectetur adipiscing elit. Cras euismod vestibulum orci, mollis vulputate felis dapibus sed. Nam ullamcorper congue elit."</h1>
						<!-- Name -->
						<!-- <p class="light">Jane Doe</p>
					</li>
				</ul>	
			    </div>
			    <div class="item">
			    <ul>
			      <li class="monial">
						<!-- Text -->
						<!-- <h1 class="condensed white">"<span class="colored">Lorem ipsum dolor</span> sit amet, consectetur adipiscing elit. Cras euismod vestibulum orci, mollis vulputate felis dapibus sed. Nam ullamcorper congue elit."</h1>
						<!-- Name -->
						<!-- <p class="light">Severe Dane</p>
					</li>
				</ul>	
			    </div>
			  </div>

			 
			</div>  

					</div><!-- End Inner Div -->

	<!-- </section><!-- End Testimonials Section -->

	<!-- Blockquote -->
	<!--<section id="blockquote">

		<div class="inner no-padding">
			<!-- Your Text -->
			<!--<p class="normal white blockquote fancy">This is our Client's motivation, we work with Passion! 
			<a href="#about" class="scroll"><i class="fa fa-arrow-right"></i></a></p>
		</div>

	</section><!-- End Blockquote Section -->
    
	<!-- Contact Section -->
	<section id="contact" class="container parallax4">
		<!-- Contact Inner -->
		<div class="inner contact">

			<!-- Form Area -->
			<div class="contact-form">
            
            	<h4 class="header light gray3 fancy"><span class="colored">Contact</span> Us</h4>
                <p class="h-desc white">Don´t be shy and write us a message!.<br />
                Email us or give us a call at <span class="bold colored">+91-9445777790.</span></p>
				<!-- Form -->
				<%--<form id="contact-us" method="post" action="#">--%>
					<!-- Left Inputs -->
					<div class="col-xs-6 animated" data-animation="fadeInLeft" data-animation-delay="300">
						<!-- Name -->
						<input type="text" name="name" id="name" required="required" class="form" placeholder="Name" />
						<!-- Email -->
						<input type="email" name="mail" id="mail" required="required" class="form" placeholder="Email" />
						<!-- Subject -->
						<input type="text" name="subject" id="subject" required="required" class="form" placeholder="Subject" />
					</div><!-- End Left Inputs -->
					<!-- Right Inputs -->
					<div class="col-xs-6 animated" data-animation="fadeInRight" data-animation-delay="400">
						<!-- Message -->
						<textarea name="message" id="message" class="form textarea"  placeholder="Message"></textarea>
					</div><!-- End Right Inputs -->
					<!-- Bottom Submit -->
					<div class="relative fullwidth col-xs-12">
						<!-- Send Button -->
						<button type="submit" id="submit" name="submit" class="form-btn semibold">Send Message</button> 
					</div><!-- End Bottom Submit -->
					<!-- Clear -->
					<div class="clear"></div>
				<%--</form>--%>

				<!-- Your Mail Message -->
				<div class="mail-message-area">
					<!-- Message -->
					<div class="alert gray-bg mail-message not-visible-message">
						<strong>Thank You !</strong> Your email has been delivered.
					</div>
				</div>

			</div><!-- End Contact Form Area -->
		</div><!-- End Inner -->
	</section><!-- End Contact Section -->



	<!-- Site Socials and Address -->
	<section id="site-socials" class="no-padding white-bg">
		<div class="site-socials inner no-padding">
			<!-- Socials -->
			<div class="socials animated" data-animation="fadeInLeft" data-animation-delay="400">
				<!-- Facebook -->
				<a href="#" target="_blank" class="social">
					<i class="fa fa-facebook"></i>
				</a>
				<!-- Twitter -->
				<a href="#" target="_blank" class="social">
					<i class="fa fa-twitter"></i>
				</a>
				<!-- Instagram -->
				<a href="#" class="social">
					<i class="fa fa-instagram"></i>
				</a>
				<!-- Linkedin -->
				<a href="#" target="_blank" class="social">
					<i class="fa fa-linkedin"></i>
				</a>
				<!-- Vimeo -->
				<a href="#" target="_blank" class="social">
					<i class="fa fa-vimeo-square"></i>
				</a>
				<!-- Youtube -->
				<a href="#" target="_blank" class="social">
					<i class="fa fa-youtube"></i>
				</a>               
				<!-- Google Plus -->
				<a href="#" target="_blank" class="social">
					<i class="fa fa-google-plus"></i>
				</a>                
			</div>
			<!-- Adress, Mail -->
			<div class="address socials animated" data-animation="fadeInRight" data-animation-delay="500">
				<!-- Phone Number, Mail -->
				<p>Phone: +91-9445777790 Email : <a href="mailto:atsaipavipvtltd@gmail.com" class="colored">atsaipavipvtltd@gmail.com</a> Address: No:18 DR Ambethkar Nagar (High School Back Side), Singaperumal Koil, Chennai-603204</p>
				<!-- Top Button -->
				<a href="#home" class="scroll top-button">
					<i class="fa fa-arrow-circle-up fa-2x"></i>
				</a>
			</div><!-- End Adress, Mail -->
		</div><!-- End Inner -->
	</section><!-- End Site Socials and Address -->



	<!-- Footer -->
	<footer id="footer" class="footer">
		<!-- Your Company Name -->
		
        <%--<img src="images/logo-icon.png" width="200" alt="Logo" />--%>
		<!-- Copyright -->
		<p class="copyright normal">© 2016 <span class="colored">AtSaiPavi.</span> All Rights Reserved.</p>
	</footer><!-- End Footer -->

	<!-- JS Files -->
	
	
	<script type="text/javascript" src="js/jquery-1.11.0.min.js"></script>
	<script type="text/javascript" src="js/bootstrap.min.js"></script>
	<script type="text/javascript" src="js/jquery.appear.js"></script>
	<script type="text/javascript" src="js/jquery.prettyPhoto.js"></script>
	<script type="text/javascript" src="js/modernizr-latest.js"></script>
	<script type="text/javascript" src="js/SmoothScroll.js"></script>
	<script type="text/javascript" src="js/jquery.parallax-1.1.3.js"></script>
	<script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
	<script type="text/javascript" src="js/jquery.superslides.js"></script>
	<script type="text/javascript" src="js/jquery.flexslider.js"></script>
	<script type="text/javascript" src="js/jquery.mb.YTPlayer.js"></script>
	<script type="text/javascript" src="js/jquery.fitvids.js"></script>
	<script type="text/javascript" src="js/jquery.slabtext.js"></script>
	<script type="text/javascript" src="js/plugins.js"></script>

	<script>

	    $("a.about-icon").hover(function () {
	        $(this).children("i").addClass("fa-spin");
	    }, function(){
	        $(this).children("i").removeClass("fa-spin");
	    });


	    </script>
  
    </form>
</body>
</html>
