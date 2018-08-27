﻿<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    @Styles.Render("~/Content/css")
   
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
      
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
       
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
