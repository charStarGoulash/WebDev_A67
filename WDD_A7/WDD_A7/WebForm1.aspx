<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WDD_A7.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <style>
            #ListBoxDiv
            {
                width: 300px;
                height: 700px;
                float:left;
            }

            #TextBoxDiv
            {
                float: right;
            }
            /*div
            {
                display: inline-block;
            }*/
        ul 
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #333;
        }

        li 
        {
            float: left;
        }

        li a, .dropbtn 
        {
            display: inline-block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

        li a:hover, .dropdown:hover .dropbtn 
        {
            background-color: red;
        }

        li.dropdown 
        {
            display: inline-block;
        }

        .dropdown-content 
        {
            display: none;
            position: absolute;
            background-color: #333;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }

        .dropdown-content a 
        {
            color: white;
            padding: 12px 16px;
            text-decoration: none;
            display: block;
            text-align: left;
        }

        .dropdown-content a:hover 
        {
            background-color: red;

        }

        .dropdown:hover .dropdown-content 
        {
            display: block;
        }
        </style>
        <title>A7 Text Editor</title>
    </head>
    <body>
        <form runat="server">
            <ul>
                <li class="dropdown">
                    <a class="dropbtn">File</a>
                    <div class="dropdown-content">
                        <a>Open</a>
                        <a>Save</a>
                        <a>Save As</a>
                    </div>
                </li>
                <li><a>Close</a></li>
            </ul>
            <div id="ListBoxDiv">
                <asp:ListBox ID="ListBox1" runat="server" Height="600px" Width="280px"></asp:ListBox>
            </div>
            <div id="TextBoxDiv">
                <asp:TextBox ID="TextBox1" runat="server" Height="600px" Width="1176px"></asp:TextBox>
            </div>
        </form>
    </body>
</html>
