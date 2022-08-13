<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="StudentAffiairs.Calendar" %>

<!DOCTYPE html>
<html>
<head>
    <title>DHXScheduler WebForms sample</title>
    <style>
        body
        {
            background-color:#eee;    
        }
    </style>
</head>
<body>    
    <div style="width:960px;height:800px;margin:0 auto;">
        <%= this.RenderScheduler()%>
    </div>
</body>
</html>

