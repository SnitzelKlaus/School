<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MovieNight</title>
    <link href="Style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" class="" runat="server">

        <%--Gif background--%>
        <%--<img src="https://i.gifer.com/76YS.gif" class="full-img"/>--%>

        <%--Header/Title--%>
        <div class="header whitetxt">
            <h1>Movie Night</h1>
            <p>Search for movies and actors!</p>
        </div>

        <%--Tabs [Home][Search][Ect]--%>
        <div class="container">
            <ul class="nav nav-tabs">
                <li class="active whitetxt"><a data-toggle="tab" href="#home">Home</a></li>
                <li class="whitetxt"><a data-toggle="tab" href="#search">Search</a></li>
                <li class="whitetxt"><a data-toggle="tab" href="#about">About us</a></li>
                <li class="whitetxt"><a data-toggle="tab" href="#contact">Contact</a></li>
            </ul>

            <div class="tab-content">
                <div id="home" class="content tab-pane fade in active">
                    <%--Literal for displaying thumbnails--%>
                    <asp:Literal ID="GetMovies" runat="server"></asp:Literal>
                </div>
                <div id="search" class="tab-pane fade whitetxt">
                    <h3>Search</h3>
                    <p>Search for a movie or actor.</p>

                    <%--Search box--%>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                </div>
                <div id="about" class="tab-pane fade whitetxt">
                    <h3>About us</h3>
                    <p>We good quality company.</p>
                </div>
                <div id="contact" class="tab-pane fade whitetxt">
                    <h3>Contacts</h3>
                    <p> <strong>Email:</strong> SnitzelKl@us.com</p>
                    <p> <strong>Phone:</strong> (420) 696 9696</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>