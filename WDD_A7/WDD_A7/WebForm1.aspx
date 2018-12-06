<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WDD_A7.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <style>
            .ui-menu 
            {
                width: 100px;
            }
        </style>
        <title>A7 Text Editor</title>
            <link href = "https://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel = "stylesheet"/>
            <script src = "https://code.jquery.com/jquery-1.10.2.js"></script>
            <script src = "https://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
        <!-- Javascript -->
        <script>
              $(function ()
              {
                  var menu = $("#mainMenu").menu();
                  $("#mainMenu").menu("focus", null, $("#mainMenu").menu().find(".ui-menu-item:last"));

                 $(menu).mouseleave(function ()
                 {
                     menu.menu('collapseAll');
                  });

              });
        </script>
    </head>
    <body>
        <form runat="server">
            <!-- HTML --> 
            <ul id = "mainMenu" class="mainMenuClass">
                <li><a>File</a>
                    <ul>
                       <li><a>Open</a></li>
                       <li><a>Save</a></li>
                       <li><a>Save As</a></li>
                    </ul>
                 </li>
                 <li><a>Close</a></li>                 
            </ul>
        </form>
    </body>
</html>
