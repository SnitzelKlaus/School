        <%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CutnGo.Default" %>

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
            <h1>Cut n&#39; Go</h1>
            <p>Best Haircut In Town!</p>
        </div>

        <%--Tabs [Home][Search][Ect]--%>
        <div class="container">
            <ul class="nav nav-tabs">
                <li class="active whitetxt"><a data-toggle="tab" href="#home">Home</a></li>
                <li class="whitetxt"><a data-toggle="tab" href="#appointment">Add appointment</a></li>
                <li class="whitetxt"><a data-toggle="tab" href="#about">About us</a></li>
                <li class="whitetxt"><a data-toggle="tab" href="#contact">Contact</a></li>
            </ul>

            <div class="tab-content">
                <div id="home" class="content tab-pane fade in active whitetxt">
                    <%--Literal for displaying thumbnails--%>
                    <h3>Price listings:</h3>
                    <br />
                        <p>Herre Klip 180,-</p>
                        <p>Dame Klip 250,-</p>
                        <p>Børn klip (under 12 år) 170,-</p>
                        <p>Herre Klip (pensionist) 170,-</p>
                        <p>Dame Klip (pensionist) 230,-</p>
                        <p>Permanent</p>
                        <p>Kort Fra 550,-</p>
                        <p>Mellem 750,-</p>
                        <p>Langt Fra 950,-</p>
                        <p>Striber</p>
                        <p>Kort Fra 550,-</p>
                        <p>Mellem 700,-</p>
                        <p>Langt Fra 850,- Og op</p>
                        <p>Hætte striber 400,-</p>
                        <p>Helfarvning</p>
                        <p>Kort 450,-</p>
                        <p>Mellem 600,-</p>
                        <p>Langt 700 – 1000,-</p>
                        <p>Toning- bund 2-3 cm 350,- </p>
                </div>
                <div id="appointment" class="tab-pane fade whitetxt">
                    <h3>Add appointment</h3>
                    <br />
                    <asp:Label runat="server" Text="Name:"></asp:Label>
                    <asp:TextBox ID="Name" runat="server" class="blacktxt"></asp:TextBox>
                    <br />
                    <asp:Label runat="server" Text="Date:"></asp:Label>
                    <asp:Calendar ID="Date" runat="server" class="whiteback"></asp:Calendar>
                    <br />
                    <asp:Button ID="Order" runat="server" Text="Order" class="blacktxt"/>

                    <%--Search box--%>
                </div>
                <div id="about" class="tab-pane fade whitetxt">
                    <h3>About us</h3>
                    <p>We good quality company and provide good haircut.</p>
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